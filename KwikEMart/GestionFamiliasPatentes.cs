using BE;
using BL;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class GestionFamiliasPatentes : Form, IObserver
    {
        private Familia EditedFamily;
        public GestionFamiliasPatentes()
        {
            InitializeComponent();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
            FillData();
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGestionPerfiles gestion = new frmGestionPerfiles();
            gestion.Show();
            this.Close();
        }

        PermisoBLL permisoBLL= new PermisoBLL();
        private void FillData()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = permisoBLL.GetFamiliaPermisos().Data;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.SelectedIndex = -1;

        }

        private void panelGestionFamiliasPatentes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            IPermiso familiaSeleccionada = comboBox1.SelectedItem as IPermiso;

            EditedFamily = permisoBLL.GetFamiliaPermisos().Data.First(p => p.Id == familiaSeleccionada.Id) as Familia;

            TxtNombreFamilia.Text = familiaSeleccionada.Nombre;
            ShowPanelData();
        }

        private void ShowPanelData()
        {
            ConfigListBox();
        }

        private void ConfigListBox()
        {
            // Configuracion listbox 
            ListBoxFamilias.DataSource = null;
            ListBoxFamilias.DataSource =
                permisoBLL.GetFamiliaPermisos().Data
                .Where(p => !EditedFamily.Permisos.Any(ef => ef.Id == p.Id) && p.Id != EditedFamily?.Id)
                .ToList();
            ListBoxFamilias.DisplayMember = "Nombre";
            ListBoxFamilias.SelectedIndex = -1;

            ListBoxPermisos.DataSource = null;
            ListBoxPermisos.DataSource =
                permisoBLL.GetPermisos().Data
                .Where(p => !EditedFamily.Permisos.Any(ef => ef.Id == p.Id))
                .ToList();
            ListBoxPermisos.DisplayMember = "Nombre";
            ListBoxPermisos.SelectedIndex = -1;

            if (EditedFamily != null)
            {
                ListBoxPermisosFamilia.DataSource = null;
                ListBoxPermisosFamilia.DataSource = EditedFamily.Permisos;
                ListBoxPermisosFamilia.DisplayMember = "Nombre";
                ListBoxPermisosFamilia.SelectedIndex = -1;
            }
        }

        private void HidePanelData()
        {

            TxtNombreFamilia.Text = string.Empty;

            ListBoxFamilias.DataSource = null;
            ListBoxPermisos.DataSource = null;
            ListBoxPermisosFamilia.DataSource = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TxtNombreFamilia.Text = string.Empty;


            comboBox1.SelectedIndex = -1;
            EditedFamily = new Familia();
            EditedFamily.Permisos = new List<IPermiso>();
            ShowPanelData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPermiso familia = comboBox1.SelectedItem as IPermiso;

            BusinessResponse<bool> response = permisoBLL.DeleteFamilia(familia);
            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                comboBox1.SelectedIndex = -1;
                HidePanelData();
                FillData();
            }
        }

        protected void RevisarRespuestaServicio<T>(BusinessResponse<T> respuesta)
        {
            if (!respuesta.Ok)
            {
                MessageBox.Show(respuesta.Mensaje, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (respuesta.Ok && !string.IsNullOrEmpty(respuesta.Mensaje))
            {
                MessageBox.Show(respuesta.Mensaje, "Great!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            IPermiso permisoSelected;

            if (ListBoxPermisos.SelectedIndex == -1 && ListBoxFamilias.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar permiso o familia de permisos"));
                return;
            }

            permisoSelected = ListBoxPermisos.SelectedIndex != -1 ? ListBoxPermisos.SelectedItem as IPermiso : ListBoxFamilias.SelectedItem as IPermiso;

            IPermiso permisoAgregar = permisoSelected is Familia
                ?
                permisoBLL.GetFamiliaPermisos().Data
                .First(p => p.Id == permisoSelected.Id)
                :
                permisoBLL.GetPermisos().Data
                .First(p => p.Id == permisoSelected.Id);


            bool permisoExists = ExistsPermiso(permisoSelected.Id);

            if (permisoAgregar is Familia familiaPermisos && !permisoExists)
            {
                permisoExists = familiaPermisos.Permisos.Any(item => ExistsPermiso(item.Id));
            }

            if (permisoExists)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Ya se tiene el permiso en la familia de permisos a crear"));
                return;
            }

            EditedFamily.Permisos.Add(permisoAgregar);

            ConfigListBox();
        }
        private bool ExistsPermiso(int idPermiso, List<IPermiso> permisos = null)
        {
            if (permisos == null) permisos = EditedFamily.Permisos;

            foreach (var permiso in permisos)
            {
                if (permiso is Familia permisoFamilia)
                {
                    return ExistsPermiso(idPermiso, permisoFamilia.Permisos);
                }
                if (permiso.Id == idPermiso) return true;
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ListBoxPermisosFamilia.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar permiso o familia de permisos"));
                return;
            }

            IPermiso permisoSelected = ListBoxPermisosFamilia.SelectedItem as IPermiso;

            EditedFamily.Permisos.Remove(permisoSelected);
            ConfigListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(TxtNombreFamilia.Text))
            {
                MessageBox.Show("No ingreso datos");
                return;
            }

            if (EditedFamily.Permisos.Count == 0)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar permisos o familias de permisos"));
                return;
            }

            EditedFamily.Nombre = TxtNombreFamilia.Text.Trim();

            BusinessResponse<bool> response = EditedFamily.Id == 0 ? permisoBLL.CreateFamilia(EditedFamily) : permisoBLL.UpdateFamilia(EditedFamily);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                FillData();
                HidePanelData();
            }
        }
    }
}
