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
using static System.Net.Mime.MediaTypeNames;

namespace KwikEMart
{
    public partial class frmABMProveedores : Form, IObserver
    {

        private UsuarioBE usuarioActual;
        public frmABMProveedores()
        {
            InitializeComponent();
            usuarioActual = SessionManager.GetInstance().User;
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }
        ProveedorBLL proveedorBLL = new ProveedorBLL();
        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();
        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }
        Proveedor prov = new Proveedor();
        Bitacora evento = new Bitacora();   
        public void CargarProv()
        {
            DataTable dt = proveedorBLL.TraerTodosProv();
            dgvProveedores.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            prov.CUIT = int.Parse(txtCUITprov.Text);
            prov.Nombre = txtNombre.Text;
            prov.Mail = txtEmail.Text;
            prov.Telefono = int.Parse(txtTelefono.Text);
            prov.CBU = int.Parse(txtCBU.Text);
            prov.Alias = txtAlias.Text;

            proveedorBLL.AgregarProveedor(prov);

            evento.DNIusuario = usuarioActual.DNI;
            evento.Evento = "Se registró al proveedor " + prov.CUIT + ", " + prov.Nombre;
            evento.FechaHora = DateTime.Now;
            evento.Riesgo = 3;

            bitacoraEventosBLL.AgregarEventoObj(evento);

            CargarProv();

            txtCUITprov.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtCBU.Text = "";
            txtTelefono.Text = "";
            txtAlias.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCUITprov.Text, out int cuit))
            {
                prov.CUIT = int.Parse(txtCUITprov.Text);
                prov.Nombre = txtNombre.Text;
                prov.Mail = txtEmail.Text;
                prov.Telefono = int.Parse(txtTelefono.Text);
                prov.CBU = int.Parse(txtCBU.Text);
                prov.Alias = txtAlias.Text;

                proveedorBLL.ModificarProv(prov);

                MessageBox.Show("Proveedor actualizado exitosamente");

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se modificó al proveedor " + prov.CUIT + ", " + prov.Nombre;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 1;
                bitacoraEventosBLL.AgregarEventoObj(evento);


                txtCUITprov.Text = "";
                CargarProv();
            }
            else
            {
                MessageBox.Show("CUIT debe ser un número entero");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCUITprov.Text, out int cuit))
            {
                prov.CUIT = int.Parse(txtCUITprov.Text);
                
                proveedorBLL.EliminarProv(prov);

                MessageBox.Show("Proveedor eliminado exitosamente");

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se eliminó al proveedor " + prov.CUIT;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 4;
                bitacoraEventosBLL.AgregarEventoObj(evento);

                txtCUITprov.Text = "";
                CargarProv();
            }
            else
            {
                MessageBox.Show("CUIT debe ser un número entero");
            }
        }
    }
}
