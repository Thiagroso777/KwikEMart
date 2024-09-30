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
    public partial class frmABMProductos : Form, IObserver
    {
        private UsuarioBE usuarioActual;

        public frmABMProductos()
        {
            InitializeComponent();
            CargarProductos();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
            usuarioActual = SessionManager.GetInstance().User;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            KwikEMart menu = new KwikEMart();
            menu.Show();
        }

        ProductoBLL productoBLL = new ProductoBLL();
        BitacoraCambiosBLL bitacoraCambiosBLL = new BitacoraCambiosBLL();

        private void CargarProductos()
        {
            DataTable productos = new DataTable();
            productos = productoBLL.ObtenerProductos();
            dgvProductos.DataSource = productos;
            dgvProductos.Columns[0].Width = 100;
            dgvProductos.Columns[1].Width = 500;
            dgvProductos.Columns[2].Width = 50;
            dgvProductos.Columns[3].Width = 50;
            dgvProductos.Columns[4].Width = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtPrecio.Text) && !string.IsNullOrEmpty(txtStock.Text) && !string.IsNullOrEmpty(txtIDProveedor.Text))
            {

                string verificarprod = txtCodigo.Text;
                bool yaexiste = false;
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == verificarprod)
                    {
                        yaexiste = true;
                        break;
                    }
                }
                if (yaexiste)
                {
                    MessageBox.Show("Ya existe un producto con ese código.");
                }
                else
                {
                    int codigo = int.Parse(txtCodigo.Text);
                    string descripcion = txtDescripcion.Text;
                    int precio = int.Parse(txtPrecio.Text);
                    int stock = int.Parse(txtStock.Text);
                    int idprov = int.Parse(txtIDProveedor.Text);

                    productoBLL.AgregarProducto(codigo, descripcion, precio, stock, idprov);

                    int DNIUsuario = usuarioActual.DNI;
                    string Cambio = "Registro de producto";
                    int CodigoProducto = codigo;
                    string Valor = Convert.ToString(precio);
                    DateTime FechaHora = DateTime.Now;

                    bitacoraCambiosBLL.AgregarCambio(DNIUsuario, Cambio, CodigoProducto, Valor, FechaHora);

                    CargarProductos();
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos");
            }

            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtIDProveedor.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigo.Text, out int codigo))
            {
                string descripcion = txtDescripcion.Text;
                int precio = int.Parse(txtPrecio.Text);
                int stock = int.Parse(txtStock.Text);
                int idprov = int.Parse(txtIDProveedor.Text);


                productoBLL.ActualizarProducto(codigo, descripcion, precio, stock, idprov);

                MessageBox.Show("Producto actualizado exitosamente");

                int DNIUsuario = usuarioActual.DNI;
                string Cambio = "Actualización de producto";
                int CodigoProducto = codigo;
                string Valor = $"{descripcion} :: {precio} :: {stock} :: {idprov}";
                DateTime FechaHora = DateTime.Now;

                bitacoraCambiosBLL.AgregarCambio(DNIUsuario, Cambio, CodigoProducto, Valor, FechaHora);

                CargarProductos();
            }
            else
            {
                MessageBox.Show("Codigo debe ser un número entero");
            }

            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtIDProveedor.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigo.Text, out int codigo))
            {
                productoBLL.EliminarProducto(codigo);

                MessageBox.Show("Producto eliminado exitosamente");

                int DNIUsuario = usuarioActual.DNI;
                string Cambio = "Eliminación de producto";
                int CodigoProducto = codigo;
                string Valor = "-";
                DateTime FechaHora = DateTime.Now;

                bitacoraCambiosBLL.AgregarCambio(DNIUsuario, Cambio, CodigoProducto, Valor, FechaHora);

                CargarProductos();
            }
            else
            {
                MessageBox.Show("Código debe ser un número entero");
            }

            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtIDProveedor.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
    }
}
