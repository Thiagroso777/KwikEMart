using BE;
using BL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Xml.Linq;
using Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KwikEMart
{
    public partial class FormLlenarCarrito : Form, IObserver
    {
        private int facturaNumero;
        private int total=0;
        private UsuarioBE usuarioActual;

        public int cantproductos = 0;
        public FormLlenarCarrito()
        {
            InitializeComponent();
            panel7.Hide();
            facturaNumero = ObtenerNumeroFactura();
            lblTotal.Text = Convert.ToString(total);
            usuarioActual = SessionManager.GetInstance().User;
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        ProductoBLL productoBLL = new ProductoBLL(); 
        ClienteBLL clienteBLL = new ClienteBLL();
        UsuarioBLL usuarioBLL = new UsuarioBLL();

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Codigo = int.Parse(txtCodigoProd.Text);
            ProductoBE producto = productoBLL.ObtenerProductoXCodigo(Codigo);

            if (producto == null)
            {
                MessageBox.Show("Producto no registrado");
            }
            else
            {
                string verificar = txtCodigoProd.Text;
                bool yaexiste = false;
                foreach (DataGridViewRow fila in dgvCarrito.Rows)
                {
                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == verificar)
                    {
                        yaexiste = true;
                        break;
                    }
                }

                if (yaexiste)
                {

                    foreach (DataGridViewRow fila in dgvCarrito.Rows)
                    {
                        int ID = int.Parse(verificar);

                        if (fila.Cells["Codigo"].Value != null && (int)fila.Cells["Codigo"].Value == ID)
                        {
                            int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);

                            fila.Cells["Cantidad"].Value = cantidadActual + 1;

                            break;
                        }
                    }
                }
                else
                {
                    dgvCarrito.Rows.Add(producto.Codigo, producto.Descripcion, producto.Precio, 1);
                    cantproductos++;
                }

                total += producto.Precio;

                lblTotal.Text = total.ToString();
            }   

            txtCodigoProd.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int DNICliente = int.Parse(txtDNICliente.Text);
            
            ClienteBE cliente = clienteBLL.ObtenerClienteXDNI(DNICliente);
            
            if (cliente == null)
            {
                MessageBox.Show("El cliente no se encuentra registrado");
                frmABMClientes abm = new frmABMClientes();
                abm.Show();
                this.Hide();
            }
            else
            {
                panel7.Show();
                button6.Hide();
                NomApe.Text = cliente.Nombre + " " +cliente.Apellido;

                              
            }            
        }

        public string SaberDireccion()
        {
            int DNICliente = int.Parse(txtDNICliente.Text);

            ClienteBE cliente = clienteBLL.ObtenerClienteXDNI(DNICliente);

            string DireccionCliente = cliente.Direccion;

            return DireccionCliente;
        }

        public int SaberCantidadProductos()
        {
            return cantproductos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            int DNICliente = int.Parse(txtDNICliente.Text);

            ClienteBE cliente = clienteBLL.ObtenerClienteXDNI(DNICliente);

            string datosCliente = "DNI: " + cliente.DNI + "\nNombre: " + cliente.Nombre + "\nApellido: " + cliente.Apellido + "\nDirección: " + cliente.Direccion + "\nTelefono: " + cliente.Telefono;

            string datosVendedor = "DNI: " + usuarioActual.DNI + "\nNombre: " + usuarioActual.NombreUsuario + "\nApellido: " + usuarioActual.ApellidoUsuario;

            Document doc = new Document();
            string pdfPath = $"Facturas/facturaNro{facturaNumero}.pdf";

            using (FileStream stream = new FileStream(pdfPath, FileMode.OpenOrCreate))
            {
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                doc.Add(new Paragraph("Datos del cliente:"));
                doc.Add(new Paragraph(datosCliente));
                doc.Add(new Paragraph("\n\n"));

                doc.Add(new Paragraph("Datos del vendedor:"));
                doc.Add(new Paragraph(datosVendedor));
                doc.Add(new Paragraph("\n"));

                string fechayhora = Convert.ToString(DateTime.Now);

                doc.Add(new Paragraph(fechayhora));

                doc.Add(new Paragraph("\n"));


                PdfPTable carrito = new PdfPTable(dgvCarrito.Columns.Count);

               
                foreach (DataGridViewColumn column in dgvCarrito.Columns)
                {
                    carrito.AddCell(new Phrase(column.HeaderText));
                }

               
                foreach (DataGridViewRow row in dgvCarrito.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        carrito.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                    }
                }

                doc.Add(carrito);

                if (chkEnvio.Checked)
                {
                    doc.Add(new Paragraph("Subtotal: $" + total));
                    doc.Add(new Paragraph("Envío: $1200"));
                    doc.Add(new Paragraph("\nTotal: $" + (total+1200)));

                    doc.Add(new Paragraph("\n\nEnvío a domicilio a la dirección: " + cliente.Direccion));          
                }
                else
                {
                    doc.Add(new Paragraph("Total: $" + total));
                }

                facturaNumero++;
                GuardarNumeroFactura(facturaNumero);

                doc.Close();
                stream.Close();
            }

            frmCobrar cobro = new frmCobrar(this, total);
            cobro.Show();
        }

        public int returnTotal()
        {
            return total;
        }

        private int ObtenerNumeroFactura()
        {
            try
            {
                string configPath = "config.xml";

                
                if (!File.Exists(configPath))
                {
                    
                    CrearConfiguracionInicial(configPath);
                }

                XDocument doc = XDocument.Load(configPath);
                int numero = int.Parse(doc.Root.Element("facturaNumero").Value);
                return numero;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el número de factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1; 
            }
        }

        private void GuardarNumeroFactura(int numero)
        {
            try
            {
                string configPath = "config.xml";
                XDocument doc = XDocument.Load(configPath);
                doc.Root.Element("facturaNumero").Value = numero.ToString();
                doc.Save(configPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el número de factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearConfiguracionInicial(string configPath)
        {
            
            XDocument doc = new XDocument(
                new XElement("config",
                    new XElement("facturaNumero", 1)
                )
            );
            doc.Save(configPath);
        }

        public string DniCliente
        {
            get { return txtDNICliente.Text; }
        }

        public string Total
        {
            get { return lblTotal.Text; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KwikEMart menu = new KwikEMart();
            menu.Show();
            this.Close();
        }

        private void chkEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnvio.Checked)
            {
                int totalparcial = int.Parse(lblTotal.Text);
                int totalconenvio = totalparcial + 1200;
                lblTotal.Text = Convert.ToString(totalconenvio);
            }
            else
            {
                int totalparcial = int.Parse(lblTotal.Text);
                int totalsinenvio = totalparcial - 1200;
                lblTotal.Text = Convert.ToString(totalsinenvio);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCarrito.SelectedRows)
                {
                    DataGridViewRow filaSeleccionada = dgvCarrito.SelectedRows[0];

                    object valorPrecio = filaSeleccionada.Cells["Precio"].Value;

                    int precio = Convert.ToInt32(valorPrecio);


                    total = total - precio;

                    lblTotal.Text = total.ToString();
                    
                    dgvCarrito.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.", "Producto no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
