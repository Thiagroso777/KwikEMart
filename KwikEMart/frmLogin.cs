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
    public partial class frmLogin : Form, IObserver
    {
        private UsuarioBLL usuarioBLL = new UsuarioBLL();

        public frmLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Formulario_KeyDown);
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        private int intentosFallidos = 0;

        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();

        PerfilBLL perfilBLL = new PerfilBLL();
        PermisoBLL permisoBLL = new PermisoBLL();

        private void button1_Click(object sender, EventArgs e)
        {


            if (int.TryParse(txtDNI.Text, out int dni))
            {
                string contraseña = txtContraseña.Text;

                bool esValido = usuarioBLL.ValidarUsuario(dni, contraseña);



                if (esValido)
                {
                    UsuarioBE usuario = usuarioBLL.ObtenerUsuarioPorDNI(dni);

                    usuario.Rol = perfilBLL.GetByUser(usuario).Data;

                    try
                    {
                        SessionManager.Login(usuario);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    Bitacora evento = new Bitacora();
                    evento.DNIusuario = usuario.DNI;
                    evento.Evento = "Inicio de sesión";
                    evento.FechaHora = DateTime.Now;
                    evento.Riesgo = 3;

                    if (usuario.Rol.Descripcion == "ADMIN")
                    {
                        evento.Riesgo = 1;
                        evento.Evento = "Inicio de sesión de un ADMIN";
                    }

                    bitacoraEventosBLL.AgregarEventoObj(evento);


                    this.Hide();
                    KwikEMart menu = new KwikEMart();
                    menu.Show();
                }
                else
                {
                    intentosFallidos++;

                    Bitacora evento = new Bitacora();
                    evento.DNIusuario = int.Parse(txtDNI.Text);
                    evento.Evento = "Inicio de sesión fallido";
                    evento.FechaHora = DateTime.Now;
                    evento.Riesgo = 2;


                    bitacoraEventosBLL.AgregarEventoObj(evento);

                    if (intentosFallidos >= 3)
                    {

                        Bitacora eventoB = new Bitacora();
                        eventoB.DNIusuario = int.Parse(txtDNI.Text);
                        eventoB.Evento = "Se bloqueó al usuario";
                        eventoB.FechaHora = DateTime.Now;
                        eventoB.Riesgo = 2;


                        bitacoraEventosBLL.AgregarEventoObj(eventoB);

                        usuarioBLL.BloquearUsuario(dni);
                    }

                    MessageBox.Show("Credenciales incorrectas o usuario bloqueado");

                }
            }
            else
            {


                MessageBox.Show("DNI debe ser un número entero");
            }

            SessionManager.GetInstance().IdiomaActual = "Español";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '●';
            }
        }

        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (int.TryParse(txtDNI.Text, out int dni))
                {
                    string contraseña = txtContraseña.Text;

                    bool esValido = usuarioBLL.ValidarUsuario(dni, contraseña);

                    if (esValido)
                    {
                        UsuarioBE usuario = usuarioBLL.ObtenerUsuarioPorDNI(dni);

                        usuario.Rol = perfilBLL.GetByUser(usuario).Data;

                        SessionManager.Login(usuario);

                        Bitacora evento = new Bitacora();
                        evento.DNIusuario = usuario.DNI;
                        evento.Evento = "Inicio de sesión";
                        evento.FechaHora = DateTime.Now;
                        evento.Riesgo = 3;

                        if (usuario.Rol.Descripcion == "ADMIN")
                        {
                            evento.Riesgo = 1;
                            evento.Evento = "Inicio de sesión de un ADMIN";
                        }

                        bitacoraEventosBLL.AgregarEventoObj(evento);

                        this.Hide();
                        KwikEMart menu = new KwikEMart();
                        menu.Show();
                    }
                    else
                    {
                        intentosFallidos++;

                        Bitacora evento = new Bitacora();
                        evento.DNIusuario = int.Parse(txtDNI.Text);
                        evento.Evento = "Inicio de sesión fallido";
                        evento.FechaHora = DateTime.Now;
                        evento.Riesgo = 2;


                        bitacoraEventosBLL.AgregarEventoObj(evento);

                        if (intentosFallidos >= 3)
                        {

                            usuarioBLL.BloquearUsuario(dni);

                            Bitacora eventoB = new Bitacora();
                            eventoB.DNIusuario = int.Parse(txtDNI.Text);
                            eventoB.Evento = "Se bloqueó al usuario";
                            eventoB.FechaHora = DateTime.Now;
                            eventoB.Riesgo = 2;


                            bitacoraEventosBLL.AgregarEventoObj(eventoB);
                        }

                        MessageBox.Show("Credenciales incorrectas o usuario bloqueado");

                    }
                }
                else
                {
                    MessageBox.Show("DNI debe ser un número entero");
                }
                SessionManager.GetInstance().IdiomaActual = "Español";

            }
        }

       

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
