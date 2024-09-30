using BE;
using BL;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class frmLogout : Form, IObserver
    {
        private UsuarioBE usuarioActual;

        public frmLogout()
        {
            InitializeComponent();
            usuarioActual = SessionManager.GetInstance().User;
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
         BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            Bitacora evento = new Bitacora();    
            evento.DNIusuario = usuarioActual.DNI;
            evento.Evento = "Cierre de sesión del usuario " + usuarioActual.DNI + ", " + usuarioActual.NombreUsuario + " " + usuarioActual.ApellidoUsuario;
            evento.FechaHora = DateTime.Now;
            evento.Riesgo = 5;
            bitacoraEventosBLL.AgregarEventoObj(evento);

            SessionManager.Logout();



            this.Close();        
            frmLogin login = new frmLogin();
            login.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }
    }
}
