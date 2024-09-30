using BE;
using BL;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class KwikEMart : Form, IObserver
    {
        private UsuarioBE usuarioActual;
        private UsuarioBLL usuarioBLL = new UsuarioBLL();

        private SessionManager _sessionManager;
        public KwikEMart()
        {
            InitializeComponent();
            PersonalizarDiseño();
            usuarioActual = SessionManager.GetInstance().User;
            this.Name = "KwikEMart";
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
            _sessionManager = SessionManager.GetInstance();
            CheckPermissions();
            
        }
        
        private void PersonalizarDiseño()
        {
            panelAdminSub.Visible = false;
            panelOpcionesSub.Visible = false;
            panelMaestrosSub.Visible = false;
            
        }

        private void EsconderSubMenu()
        {
            
            if (panelAdminSub.Visible == true)
            {
                panelAdminSub.Visible = false;
            }
            if (panelOpcionesSub.Visible == true)
            {
                panelOpcionesSub.Visible = false;
            }
            if (panelMaestrosSub.Visible == true)
            {
                panelMaestrosSub.Visible = false;
            }
            
        }

        private void MostrarSubMenu(Panel submenu)
        {
            if(submenu .Visible == false) {
                //EsconderSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelOpcionesSub);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            int rolUsuario = usuarioBLL.ObtenerRolUsuario(usuarioActual.DNI);

            if (rolUsuario == 1)
            {
                MostrarSubMenu(panelAdminSub);
            }
            else
            {
                MessageBox.Show("Funciones exclusivas para administradores", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnMaestros_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelMaestrosSub);
        }

        

        private void btnCambContra_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCambiarContraseña cambiar = new frmCambiarContraseña(usuarioActual);
            cambiar.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogout salir = new frmLogout();
            salir.Show();
        }

        private void btnGestCuentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionCuentas gestion = new GestionCuentas(usuarioActual);
            gestion.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLlenarCarrito carrito = new FormLlenarCarrito();
            carrito.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDespachar despacho = new FormDespachar();
            despacho.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proximamente...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnCargProd_Click(object sender, EventArgs e)
        {
            this.Close();
            frmABMProductos productos = new frmABMProductos();
            productos.Show();
        }

        private void btnReporte1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmABMClientes clientes = new frmABMClientes();
            clientes.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmABMProveedores pro = new frmABMProveedores();
            pro.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnGestPerfiles_Click(object sender, EventArgs e)
        {
            frmGestionPerfiles frm = new frmGestionPerfiles();
            frm.Show();
            this.Close();
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            frmCambiarIdioma idioma = new frmCambiarIdioma();
            idioma.Show();
            this.Hide();
        }
        
        private void CheckPermissions()
        {
            btnAdmin.Visible = _sessionManager.HasPermission(10);
            btnMaestros.Visible = _sessionManager.HasPermission(6);
            button2.Visible = _sessionManager.HasPermission(5);
            button3.Visible = _sessionManager.HasPermission(9);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            BitacoraEventos bita = new BitacoraEventos();
            bita.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BitacoraCambio bita = new BitacoraCambio();
            bita.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BackUpRestore back = new BackUpRestore();
            back.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmSerializacion serializacion = new frmSerializacion();
            serializacion.Show();
            this.Close();
        }
    }
}
