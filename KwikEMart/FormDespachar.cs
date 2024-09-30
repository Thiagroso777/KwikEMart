using BE;
using BL;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class FormDespachar : Form, IObserver
    {

        private UsuarioBE usuarioActual;
        public FormDespachar()
        {
            InitializeComponent();
            usuarioActual = SessionManager.GetInstance().User;
            TraerEnviosPendientes();
            EncryptAllDirecciones();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        private void EncryptAllDirecciones()
        {
            foreach (DataGridViewRow row in dgvEnviosPendientes.Rows)
            {
                if (row.Cells["Direccion"].Value != null)
                {
                    string direccion = row.Cells["Direccion"].Value.ToString();
                    row.Cells["Direccion"].Value = CryptoManager.Encrypt(direccion);
                }
            }
        }

        private void DecryptAllDirecciones()
        {
            foreach (DataGridViewRow row in dgvEnviosPendientes.Rows)
            {
                if (row.Cells["Direccion"].Value != null)
                {
                    string direccionEncriptada = row.Cells["Direccion"].Value.ToString();
                    row.Cells["Direccion"].Value = CryptoManager.Decrypt(direccionEncriptada);
                }
            }
        }

        private bool isEncrypted = true;

        EnvioBLL envioBLL = new EnvioBLL();

        public void TraerEnviosPendientes()
        {
            DataTable pendientes = envioBLL.TraerEnviosPendientes();

            dgvEnviosPendientes.DataSource = pendientes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }

        private void btnConfirmarTicket_Click(object sender, EventArgs e)
        {
            int IDVenta = int.Parse(txtIDVenta.Text);

            envioBLL.Confirmar(IDVenta);
            TraerEnviosPendientes();
            txtIDVenta.Text = "";
        }

        string Verificado;
        
        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            TraerEnviosPendientes();

            int IDVenta = int.Parse(txtIDVenta.Text);

            foreach (DataGridViewRow fila in dgvEnviosPendientes.Rows)
            {
                if (Convert.ToInt32(fila.Cells["IDEnvio"].Value) == IDVenta)
                {                  
                    Verificado = Convert.ToString(fila.Cells["Verificado"].Value);
                }
            }

            if (Verificado != "True")
            {
                MessageBox.Show("Primero debe confirmar los datos del envío");
            }
            else
            {
                envioBLL.Entregado(IDVenta);
                Bitacora evento = new Bitacora();
                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se despachó la venta " + IDVenta;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 5;

                bitacoraEventosBLL.AgregarEventoObj(evento);

            }

            TraerEnviosPendientes();
        }

        private void btnEncryptDecrypt_Click(object sender, EventArgs e)
        {
            if (isEncrypted)
            {
                DecryptAllDirecciones();
                btnEncryptDecrypt.Text = "Encriptar Direcciones";
            }
            else
            {
                EncryptAllDirecciones();
                btnEncryptDecrypt.Text = "Desencriptar Direcciones";
            }
            isEncrypted = !isEncrypted;
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
