using BE;
using BL;
using System;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Service;
using System.IO;
using System.Diagnostics.Tracing;

namespace KwikEMart
{
    public partial class frmCobrar : Form, IObserver
    {
        private UsuarioBE usuarioActual;
        private int numeroIDProductoVenta;
        public frmCobrar(FormLlenarCarrito formLlenarCarrito, int total)
        {
            InitializeComponent();
            usuarioActual = SessionManager.GetInstance().User;
            this.formLlenarCarrito = formLlenarCarrito;
            numeroIDProductoVenta = ObtenerNumeroProductoVenta();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }



        private FormLlenarCarrito formLlenarCarrito;

        public int cantproductos;

        ClienteBLL clienteBLL = new ClienteBLL();
        VentaBLL ventaBLL = new VentaBLL();
        ProductoVentaBLL productoVentaBLL = new ProductoVentaBLL();
        EnvioBLL enviobll = new EnvioBLL();
        ProductoBLL productobll = new ProductoBLL();
        BitacoraCambiosBLL bitacoraCambiosBLL = new BitacoraCambiosBLL();
        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();

        private int ObtenerNumeroFactura()
        {
            string configPath = "config.xml";

            XDocument doc = XDocument.Load(configPath);
            int numero = int.Parse(doc.Root.Element("facturaNumero").Value);
            return numero;
        }

        public int SaberCantProd()
        {
            return formLlenarCarrito.SaberCantidadProductos();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            VentaBE venta = new VentaBE();
            ProductoVentaBE productoventa = new ProductoVentaBE();
            EnvioBE enviobe = new EnvioBE();
            ProductoBE producto = new ProductoBE();
            BitacoraCambios cambio = new BitacoraCambios();
            Bitacora evento = new Bitacora();

            if (cmbMetodoPago.Text == "")
            {
                MessageBox.Show("Ingrese el metodo de pago!");
            }
            else
            {
                venta.NumFactura = ObtenerNumeroFactura()-1;
                venta.IDVenta = ObtenerNumeroFactura()-1;
                venta.DNICliente = int.Parse(formLlenarCarrito.DniCliente);
                venta.DNI = usuarioActual.DNI;
                venta.Fecha = DateTime.Now;
                venta.Total = formLlenarCarrito.returnTotal();
                venta.MetodoPago = cmbMetodoPago.Text;

                bool envio = formLlenarCarrito.chkEnvio.Checked;

                if (envio)
                {
                    venta.IDEnvio = venta.NumFactura;
                    enviobe.IDEnvio = ObtenerNumeroFactura() - 1;
                    enviobe.IDVenta = venta.IDVenta;
                    enviobe.Direccion = Convert.ToString(formLlenarCarrito.SaberDireccion());
                    
                    ///
                    Random random = new Random();
                    int randomNumber = random.Next(1, 4);
                    if (randomNumber == 1) { enviobe.DNI = 77777777; }
                    if (randomNumber == 2) { enviobe.DNI = 88888888; }
                    if (randomNumber == 3) { enviobe.DNI = 99999999; }
                    ///
                  
                    
                    enviobe.Pendiente = "True";

                    enviobll.RegistrarEnvio(enviobe);
                }

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se realizó una venta por un total de " + formLlenarCarrito.returnTotal();
                evento.FechaHora = DateTime.Now;
                if (venta.Total >= 10000) 
                {
                    evento.Riesgo = 3;
                }
                else
                {
                    evento.Riesgo = 4;
                }
                bitacoraEventosBLL.AgregarEventoObj(evento);
                
                ventaBLL.RegistrarVenta(venta);


                cantproductos = SaberCantProd();

                for(int i = 0; i < cantproductos; i++) 
                {
                    productoventa.IDVenta = ObtenerNumeroFactura() - 1;
                    productoventa.IDProductoVenta = ObtenerNumeroProductoVenta();
                    productoventa.Codigo = Convert.ToInt32(formLlenarCarrito.dgvCarrito[0,i].Value);
                    productoventa.Cantidad = Convert.ToInt32(formLlenarCarrito.dgvCarrito[3,i].Value);
                    productoventa.Precio = Convert.ToInt32(formLlenarCarrito.dgvCarrito[2,i].Value);
                    productoventa.PrecioTotProd = productoventa.Precio * productoventa.Cantidad;

                    productoVentaBLL.RegistrarProductoVenta(productoventa);
                    numeroIDProductoVenta++;

                    cambio.DNIusuario = usuarioActual.DNI;
                    cambio.Cambio = "Venta de Producto";
                    cambio.CodigoProducto = productoventa.Codigo;
                    cambio.Valor = Convert.ToString(productoventa.Cantidad);
                    cambio.FechaHora = DateTime.Now;

                    bitacoraCambiosBLL.AgregarCambioObj(cambio);

                    productobll.RestarStock(productoventa.Codigo, productoventa.Cantidad);
                }


                
                GuardarNumeroProductoVenta(numeroIDProductoVenta);

                MessageBox.Show("Venta registrada con éxito");



                this.Close();
                formLlenarCarrito.Close();

                KwikEMart menu = new KwikEMart();
                menu.Show();
            }


           
            


        }
        ///
        private int ObtenerNumeroProductoVenta()
        {
            try
            {
                string configPath = "configprod.xml";


                if (!File.Exists(configPath))
                {

                    CrearConfiguracionInicial(configPath);
                }

                XDocument doc = XDocument.Load(configPath);
                int numero = int.Parse(doc.Root.Element("numeroIDProductoVenta").Value);
                return numero;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el número de ProductoVenta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        private void GuardarNumeroProductoVenta(int numero)
        {
            try
            {
                string configPath = "configprod.xml";
                XDocument doc = XDocument.Load(configPath);
                doc.Root.Element("numeroIDProductoVenta").Value = numero.ToString();
                doc.Save(configPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el número de ProductoVenta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearConfiguracionInicial(string configPath)
        {

            XDocument doc = new XDocument(
                new XElement("config",
                    new XElement("numeroIDProductoVenta", 1)
                )
            );
            doc.Save(configPath);
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
