using BE;
using BL;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class frmABMClientes : Form, IObserver
    {
        private UsuarioBE usuarioActual;
        public frmABMClientes()
        {
            InitializeComponent();
            usuarioActual = SessionManager.GetInstance().User;
            CargarClientes();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        private bool isEncrypted = true;

        private void EncryptAllDirecciones()
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.Cells["Direccion"].Value != null)
                {
                    string direccion = row.Cells["Direccion"].Value.ToString();
                    row.Cells["Direccion"].Value = CryptoManager.Encrypt(direccion);
                }
            }
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

        private void DecryptAllDirecciones()
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.Cells["Direccion"].Value != null)
                {
                    string direccionEncriptada = row.Cells["Direccion"].Value.ToString();
                    row.Cells["Direccion"].Value = CryptoManager.Decrypt(direccionEncriptada);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }

        ClienteBLL clienteBLL = new ClienteBLL();
        Bitacora evento = new Bitacora();
        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtTelefono.Text))
            {
                string verificardni = txtDNI.Text;
                bool yaexiste = false;
                foreach (DataGridViewRow fila in dgvClientes.Rows)
                {
                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == verificardni)
                    {
                        yaexiste = true;
                        break;
                    }
                }
                if (yaexiste)
                {
                    MessageBox.Show("Ya existe un cliente con ese DNI.");
                }
                else
                {
                    int dni = int.Parse(txtDNI.Text);
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string direccion = txtDireccion.Text;
                    int telefono = int.Parse(txtTelefono.Text);

                    clienteBLL.AgregarCliente(dni, nombre, apellido, direccion, telefono);

                    evento.DNIusuario = usuarioActual.DNI;
                    evento.Evento = "Se registró al cliente: " + dni + ", " + nombre + " " + apellido;
                    evento.FechaHora = DateTime.Now;
                    evento.Riesgo = 3;
                    bitacoraEventosBLL.AgregarEventoObj(evento);

                    CargarClientes();
                }
        }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos");
            }

            txtApellido.Text = null;
            txtDireccion.Text = null;
            txtNombre.Text = null;
            txtDNI.Text = null;
            txtTelefono.Text = null;
        }

        private void CargarClientes()
        {
            DataTable clientes = new DataTable();
            clientes = clienteBLL.ObtenerClientes();
            dgvClientes.DataSource = clientes;
            dgvClientes.Columns[0].Width = 150;
            dgvClientes.Columns[1].Width = 150;
            dgvClientes.Columns[2].Width = 150;
            dgvClientes.Columns[3].Width = 150;
            dgvClientes.Columns[4].Width = 150;

            EncryptAllDirecciones();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDNI.Text, out int dni))
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string direccion = txtDireccion.Text;
                int telefono = int.Parse(txtTelefono.Text);


                clienteBLL.ActualizarCliente(dni, nombre, apellido, direccion, telefono);

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se modificaron los datos del cliente: " + dni + ", " + nombre + " " + apellido;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 3;
                bitacoraEventosBLL.AgregarEventoObj(evento);

                MessageBox.Show("Cliente actualizado exitosamente");


                CargarClientes();
            }
            else
            {
                MessageBox.Show("DNI debe ser un número entero");
            }

            txtApellido.Text = null;
            txtDireccion.Text = null;
            txtNombre.Text = null;
            txtDNI.Text = null;
            txtTelefono.Text = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDNI.Text, out int dni))
            {
                clienteBLL.EliminarCliente(dni);

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se eliminó al cliente: " + dni;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 3;
                bitacoraEventosBLL.AgregarEventoObj(evento);

                MessageBox.Show("Cliente eliminado exitosamente");

                CargarClientes();
            }
            else
            {
                MessageBox.Show("DNI debe ser un número entero");
            }

            txtApellido.Text = null;
            txtDireccion.Text = null;
            txtNombre.Text = null;
            txtDNI.Text = null;
            txtTelefono.Text = null;
        }

        private void btnEncryptDecrypt_Click_1(object sender, EventArgs e)
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
