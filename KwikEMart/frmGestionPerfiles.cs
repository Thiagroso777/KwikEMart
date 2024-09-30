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
    public partial class frmGestionPerfiles : Form, IObserver
    {
        public frmGestionPerfiles()
        {
            InitializeComponent();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
            FillData();
        }
        private Perfil EditedPerfil;
        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
        PerfilBLL perfilBLL = new PerfilBLL();

        private void FillData()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = perfilBLL.GetAll().Data;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.SelectedIndex = -1;
        }

        private void ShowPanelData()
        {
            ConfigListBox();
        }
        PermisoBLL permisoBLL = new PermisoBLL();
        private void ConfigListBox()
        {
            // Configuracion listbox 
            ListBoxFamilias.DataSource = null;
            ListBoxFamilias.DataSource =
                permisoBLL.GetFamiliaPermisos().Data
                .Where(p => !EditedPerfil.Permisos.Any(ef => ef.Id == p.Id))
                .ToList();
            ListBoxFamilias.DisplayMember = "Nombre";
            ListBoxFamilias.SelectedIndex = -1;

            ListBoxPermisos.DataSource = null;
            ListBoxPermisos.DataSource =
                permisoBLL.GetPermisos().Data
                .Where(p => !EditedPerfil.Permisos.Any(ef => ef.Id == p.Id))
                .ToList();
            ListBoxPermisos.DisplayMember = "Nombre";
            ListBoxPermisos.SelectedIndex = -1;

            if (EditedPerfil != null)
            {
                ListBoxPermisosPerfil.DataSource = null;
                ListBoxPermisosPerfil.DataSource = EditedPerfil.Permisos;
                ListBoxPermisosPerfil.DisplayMember = "Nombre";
                ListBoxPermisosPerfil.SelectedIndex = -1;
            }
        }

        private void HidePanelData()
        {
            TxtNombrePerfil.Text = string.Empty;

            ListBoxFamilias.DataSource = null;
            ListBoxPermisos.DataSource = null;
            ListBoxPermisosPerfil.DataSource = null;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            KwikEMart kwik = new KwikEMart();
            kwik.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionFamiliasPatentes gestion = new GestionFamiliasPatentes();
            gestion.Show();
            this.Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            Perfil perfil = comboBox1.SelectedItem as Perfil;

            EditedPerfil = perfilBLL.GetAll().Data.First(p => p.Id == perfil.Id) as Perfil;

            TxtNombrePerfil.Text = EditedPerfil.Descripcion;

            ShowPanelData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TxtNombrePerfil.Text = string.Empty;


            comboBox1.SelectedIndex = -1;
            EditedPerfil = new Perfil();
            EditedPerfil.Permisos = new List<IPermiso>();
            ShowPanelData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Perfil perfil = comboBox1.SelectedItem as Perfil;

            BusinessResponse<bool> response = perfilBLL.Delete(perfil);
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

            EditedPerfil.Permisos.Add(permisoAgregar);

            ConfigListBox();
        }

        private bool ExistsPermiso(int idPermiso, List<IPermiso> permisos = null)
        {
            if (permisos == null) permisos = EditedPerfil.Permisos;

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
            if (ListBoxPermisosPerfil.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar permiso o familia de permisos"));
                return;
            }

            IPermiso permisoSelected = ListBoxPermisosPerfil.SelectedItem as IPermiso;

            EditedPerfil.Permisos.Remove(permisoSelected);
            ConfigListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(TxtNombrePerfil.Text))
            {
                MessageBox.Show("No ingreso datos");
                return;
            }

            if (EditedPerfil.Permisos.Count == 0)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar permisos o familias de permisos"));
                return;
            }

            EditedPerfil.Descripcion = TxtNombrePerfil.Text.Trim();

            BusinessResponse<bool> response = EditedPerfil.Id == 0 ? perfilBLL.Create(EditedPerfil) : perfilBLL.Update(EditedPerfil);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                FillData();
                HidePanelData();
            }
        }
    }
}
