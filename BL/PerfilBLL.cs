using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PerfilBLL
    {
        private readonly PerfilDAL _dataAccessPerfil;
        private readonly PermisoBLL _businessPermiso;

        public PerfilBLL()
        {
            _dataAccessPerfil = new PerfilDAL();
            _businessPermiso = new PermisoBLL();
        }

     

        public int TraerPorUsuario(int dni)
        {
            return _dataAccessPerfil.TraerPorUsuario(dni);
        }

        public BusinessResponse<Perfil> GetByUser(UsuarioBE user)
        {

            Perfil perfil = _dataAccessPerfil.SelectByUser(user);
            perfil.Permisos = _businessPermiso.GetPermisosPerfil(perfil).Data;

            return new BusinessResponse<Perfil>(true, perfil);
        }

        public BusinessResponse<List<Perfil>> GetAll()
        {
            List<Perfil> perfiles = _dataAccessPerfil.SelectAll();

            foreach (Perfil perfil in perfiles)
            {
                perfil.Permisos = _businessPermiso.GetPermisosPerfil(perfil).Data;
            }

            return new BusinessResponse<List<Perfil>>(true, perfiles);
        }

        public BusinessResponse<bool> Create(Perfil perfil)
        {
            bool ok = _dataAccessPerfil.Insert(perfil);
            return new BusinessResponse<bool>(ok, ok, ok ? "Creado correctamente" : "Error al crear");
        }

        public BusinessResponse<bool> Update(Perfil perfil)
        {
            bool ok = _dataAccessPerfil.Update(perfil);
            return new BusinessResponse<bool>(ok, ok, ok ? "Modificado correctamente" : "Error al modificar");
        }

        public BusinessResponse<bool> Delete(Perfil perfil)
        {
            bool ok = _dataAccessPerfil.Delete(perfil);
            return new BusinessResponse<bool>(ok, ok, ok ? "Eliminado correctamente" : "Perfil asignado a un usuario");
        }
    }
}
