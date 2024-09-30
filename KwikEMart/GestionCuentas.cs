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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class GestionCuentas : Form, IObserver
    {
        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        private UsuarioBE usuarioActual;

        public GestionCuentas(UsuarioBE usuario)
        {
            InitializeComponent();
            CargarUsuarios();
            usuarioActual = usuario;
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
            iniciarCMB();
        }

        Bitacora evento = new Bitacora();
        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();
        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtRol.Text))
            {
                string verificardni = txtDNI.Text;
                bool yaexiste = false;
                foreach (DataGridViewRow fila in dgvUsuarios.Rows)
                {
                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == verificardni)
                    {
                        yaexiste = true;
                        break;
                    }
                }
                if (yaexiste)
                {
                    MessageBox.Show("Ya existe un usuario con ese DNI.");
                }
                else
                {

                    UsuarioBE usuario = new UsuarioBE
                    {
                        DNI = int.Parse(txtDNI.Text),
                        NombreUsuario = txtNombre.Text,
                        ApellidoUsuario = txtApellido.Text,
                        Contraseña = CryptoManager.EncryptString(Convert.ToString(txtDNI.Text)),
                        EstaBloqueado = "False",
                        Rol = txtRol.SelectedItem as Perfil,
                    };

                    evento.DNIusuario = usuarioActual.DNI;
                    evento.Evento = "Se registró al usuario " + usuario.DNI + ", " + usuario.NombreUsuario + " " + usuario.ApellidoUsuario;
                    evento.FechaHora = DateTime.Now;
                    evento.Riesgo = 3;
                    bitacoraEventosBLL.AgregarEventoObj(evento);

                    usuarioBLL.AgregarUsuario(usuario);

                    CargarUsuarios();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos");
            }

            txtApellido.Text = null;
            txtRol.Text = null;
            txtNombre.Text = null;
            txtDNI.Text = null;
        }
        PerfilBLL perfilBLL = new PerfilBLL();
        private void iniciarCMB()
        {
            txtRol.DataSource = null;
            txtRol.DataSource = perfilBLL.GetAll().Data;
            txtRol.DisplayMember = "Descripcion";
            txtRol.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDNI.Text, out int dni))
            {

                usuarioBLL.DesbloquearUsuario(dni);

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se desbloqueó al usuario " + dni;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 2;
                bitacoraEventosBLL.AgregarEventoObj(evento);

                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("DNI debe ser un número entero");
            }

            txtApellido.Text = null;
            txtRol.Text = null;
            txtNombre.Text = null;
            txtDNI.Text = null;
        }

        private void CargarUsuarios()
        {
            DataTable usuarios = new DataTable();
            usuarios = usuarioBLL.ObtenerUsuarios();
            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Columns[0].Width = 150;
            dgvUsuarios.Columns[1].Width = 150;
            dgvUsuarios.Columns[2].Width = 150;
            dgvUsuarios.Columns[3].Width = 150;
            dgvUsuarios.Columns[4].Width = 150;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDNI.Text, out int dni))
            {
                UsuarioBE usuario = new UsuarioBE
                {
                    DNI = int.Parse(txtDNI.Text),
                    NombreUsuario = txtNombre.Text,
                    ApellidoUsuario = txtApellido.Text,
                    Contraseña = CryptoManager.EncryptString(Convert.ToString(txtDNI.Text)),
                    EstaBloqueado = "False",
                    Rol = txtRol.SelectedItem as Perfil,
                };

                usuarioBLL.ActualizarUsuario(usuario);

                MessageBox.Show("Usuario actualizado exitosamente");

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se modificó al usuario " + usuario.DNI + ", " + usuario.NombreUsuario + " " + usuario.ApellidoUsuario;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 2;
                bitacoraEventosBLL.AgregarEventoObj(evento);

                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("DNI debe ser un número entero");
            }

            txtApellido.Text = null;
            txtRol.Text = null;
            txtNombre.Text = null;
            txtDNI.Text = null;
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
