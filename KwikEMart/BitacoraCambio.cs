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
    public partial class BitacoraCambio : Form, IObserver
    {
        public BitacoraCambio()
        {

            InitializeComponent();
            CargarCambios();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
        }


        BitacoraCambiosBLL bitacoraCambiosBLL = new BitacoraCambiosBLL();

        public void CargarCambios()
        {
            DataTable data = new DataTable();

            data = bitacoraCambiosBLL.TraerTodosCambios();

            dgvCambios.DataSource = data;

            DataView dv = ((DataTable)dgvCambios.DataSource).DefaultView;

            dv.Sort = "FechaHora DESC";

            dgvCambios.DataSource = dv.ToTable();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CargarCambios();


            string codigoProducto = txtCodProd.Text.Trim();
            DataTable dt = (DataTable)dgvCambios.DataSource;

            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"CodigoProducto = '{codigoProducto}'";
                dgvCambios.DataSource = dv;
            }

            btnQuitarFiltro.Visible = true;
            txtCodProd.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CargarCambios();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            KwikEMart menu = new KwikEMart();
            menu.Show();
            this.Close();
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
