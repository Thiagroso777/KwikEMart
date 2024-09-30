using BE;
using BL;
using Service;
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

namespace KwikEMart
{
    public partial class BackUpRestore : Form, IObserver
  
    {

        /// CAMBIAR ESTO CUANDO SE CAMBIE DE EQUIPO
        /// Direccion de los BackUps
        string pathBackUps = "X:/Restores";



        private UsuarioBE usuarioActual;
        public BackUpRestore()
        {
            InitializeComponent();
            usuarioActual = SessionManager.GetInstance().User;
            CargarBackUps();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        RestoreBLL restoreBLL = new RestoreBLL();
        Bitacora evento = new Bitacora();
        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();

        public void CargarBackUps()
        {
            string path = pathBackUps;

            string[] BakFiles = Directory.GetFiles(path, "*.bak");

            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre archivo", typeof (string));
            dt.Columns.Add("Tamaño en bytes", typeof (long));
            
            foreach (string BakFile in BakFiles)
            {
                FileInfo fileinfo = new FileInfo(BakFile);
                
                dt.Rows.Add(fileinfo.Name, fileinfo.Length);
            }


            dgvVersiones.DataSource = dt;
            dgvVersiones.Columns["Nombre archivo"].Width = 250;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            restoreBLL.GenerarBackUp();

            evento.DNIusuario = usuarioActual.DNI;
            evento.Evento = "Se guardó un BackUp de la Base de datos";
            evento.FechaHora = DateTime.Now;
            evento.Riesgo = 3;

            bitacoraEventosBLL.AgregarEventoObj(evento);

            MessageBox.Show("Backup hecho!");
            CargarBackUps();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KwikEMart menu = new KwikEMart();
            menu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dgvVersiones.SelectedRows.Count > 0)
            {
                string BackUpFileName = dgvVersiones.SelectedRows[0].Cells["Nombre archivo"].Value.ToString();

                string directorio = pathBackUps;

                string BackUpFilePath = Path.Combine(directorio, BackUpFileName);
                
                string fecha = BackUpFileName.Substring(11, BackUpFileName.Length - 11 - 4);

                restoreBLL.RestaurarBase(BackUpFilePath);

                evento.DNIusuario = usuarioActual.DNI;
                evento.Evento = "Se restauró la base de datos a la fecha: " + fecha;
                evento.FechaHora = DateTime.Now;
                evento.Riesgo = 1;

                bitacoraEventosBLL.AgregarEventoObj(evento);

                MessageBox.Show("Se restauró la base con éxito!");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una versión");
            }

            
        }
        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
