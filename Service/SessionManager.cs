using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public class SessionManager
    {
        public UsuarioBE User { get; private set; }

        private static SessionManager _instance;

        private SessionManager()
        {
        }

        public static SessionManager GetInstance()
        {
            if (_instance is null) throw new Exception("Sesion no iniciada");

            return _instance;
        }

        public static SessionManager Login(UsuarioBE user)
        {
            if (_instance != null) throw new Exception("Hay una sesión en curso");

            if (_instance is null)
            {
                _instance = new SessionManager
                {
                    User = user
                };
            }

            return _instance;
        }

        public static void Logout()
        {
            if (_instance != null)
            {
                _instance = null;
            }
        }

        public string idiomaActual;

        public string IdiomaActual
        {
            get { return idiomaActual; }
            set
            {
                idiomaActual = value;
                LenguageManager.ObtenerInstancia().CargarIdioma();
                LenguageManager.ObtenerInstancia().Notificar();
            }

        }

        public bool HasPermission(int idPermiso, List<IPermiso> permisos = null)
        {

            if (permisos == null) permisos = User.Rol.Permisos;

            foreach (var permiso in permisos)
            {
                if (permiso is Familia permisoFamilia)
                {
                    return HasPermission(idPermiso, permisoFamilia.Permisos);
                }
                if (permiso.Id == idPermiso) return true;
            }

            return false;
        }
    }
}
