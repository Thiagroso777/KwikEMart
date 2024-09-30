using BL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BE;
using Service;

namespace KwikEMart
{
    public partial class BitacoraEventos : Form, IObserver
    {
        private UsuarioBE usuarioActual;
        public BitacoraEventos()
        {
            InitializeComponent();
            usuarioActual = SessionManager.GetInstance().User;
            CargarEventos();
            dgvEventos.Columns["Evento"].Width = 250;
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }

        BitacoraEventosBLL bitacoraEventosBLL = new BitacoraEventosBLL();

        public void CargarEventos()
        {
            DataTable data = new DataTable();

            data = bitacoraEventosBLL.TraerTodosEventos();

            dgvEventos.DataSource = data;

            DataView dv = ((DataTable)dgvEventos.DataSource).DefaultView;

            dv.Sort = "FechaHora DESC";
            
            dgvEventos.DataSource = dv.ToTable();


        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            KwikEMart menu = new KwikEMart();

            menu.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CargarEventos();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CargarEventos();

            string Riesgo = cmbRiesgo.Text.Trim();
            DataTable dt = (DataTable)dgvEventos.DataSource;

            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"Riesgo = '{Riesgo}'";
                dgvEventos.DataSource = dv;
            }

            btnQuitarFiltro.Visible = true;
            cmbRiesgo.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            string pdfPath = $"Auditoría Eventos/Eventos al {DateTime.Now.DayOfWeek} {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}.pdf";

            using (FileStream stream = new FileStream(pdfPath, FileMode.OpenOrCreate))
            {
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                doc.Add(new Paragraph("Eventos registrados en el sistema al: " + Convert.ToString(DateTime.Now)));
                doc.Add(new Paragraph("\n"));

                PdfPTable eventos = new PdfPTable(dgvEventos.Columns.Count);


                foreach (DataGridViewColumn column in dgvEventos.Columns)
                {
                    eventos.AddCell(new Phrase(column.HeaderText));
                }


                foreach (DataGridViewRow row in dgvEventos.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        eventos.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                    }
                }

                doc.Add(eventos);

                doc.Add(new Paragraph("Informe descargado por: " + usuarioActual.DNI + ", " + usuarioActual.NombreUsuario + " " + usuarioActual.ApellidoUsuario));

                doc.Close();
                stream.Close();
            }
            MessageBox.Show("Archivo descargado!");
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
