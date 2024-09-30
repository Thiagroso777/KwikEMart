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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class frmCambiarContraseña : Form, IObserver
    {
        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        private UsuarioBE usuarioActual;

        public frmCambiarContraseña(UsuarioBE usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        private bool ValidarContraseña(string contraseña)
        {
            //1 letra mayus, 1 letra minusc, y 1 num.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(contraseña, pattern);
        }

        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();

        private void button1_Click(object sender, EventArgs e)
        {
            string contraseñaActual = txtContraseñaActual.Text;
            string nuevaContraseña = txtNuevaContraseña.Text;
            string confirmarNuevaContraseña = txtConfirmarNuevaContraseña.Text;

            if (nuevaContraseña != confirmarNuevaContraseña)
            {
                MessageBox.Show("Las nuevas contraseñas no coinciden");
                return;
            }

            if (!usuarioBLL.ValidarUsuario(usuarioActual.DNI, contraseñaActual))
            {
                MessageBox.Show("La contraseña actual es incorrecta");
                return;
            }

            string contraseña = txtNuevaContraseña.Text;

            if (ValidarContraseña(contraseña))
            {
                UsuarioBE usuario = new UsuarioBE
                {
                    DNI = usuarioActual.DNI,
                    NombreUsuario = usuarioActual.NombreUsuario,
                    ApellidoUsuario = usuarioActual.ApellidoUsuario,
                    EstaBloqueado = "False",
                    Rol = usuarioActual.Rol as Perfil,
                    Contraseña = CryptoManager.EncryptString(nuevaContraseña),
                    IntentosFallidos=usuarioActual.IntentosFallidos,
                };
                
                usuarioBLL.ActualizarUsuario(usuario);

                Bitacora evento = new Bitacora();

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se modificó la contraseña del usuario " + usuarioActual.DNI + ", " + usuarioActual.NombreUsuario + " " + usuarioActual.ApellidoUsuario;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 2;
                bitacoraEventosBLL.AgregarEventoObj(evento);

                MessageBox.Show("Contraseña cambiada exitosamente");
                ////
                this.Close();
                SessionManager.Logout();
                frmLogin login = new frmLogin();
                login.Show();
            }
            else
            {
                MessageBox.Show("La contraseña debe contener al menos una letra mayúscula, una letra minúscula y un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContraseñaActual.PasswordChar = '\0';
                txtNuevaContraseña.PasswordChar = '\0';
                txtConfirmarNuevaContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseñaActual.PasswordChar = '●';
                txtNuevaContraseña.PasswordChar = '●'; ;
                txtConfirmarNuevaContraseña.PasswordChar = '●'; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
