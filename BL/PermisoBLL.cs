using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PermisoBLL
    {
        private readonly PermisoDAL permisoDAL;

        public PermisoBLL()
        {
            permisoDAL = new PermisoDAL();
        }

        public BusinessResponse<List<IPermiso>> GetPermisosPerfil(Entidad perfil)
        {
            return new BusinessResponse<List<IPermiso>>(true, permisoDAL.SelectPermisosPerfil(perfil));
        }

        public BusinessResponse<List<IPermiso>> GetFamiliaPermisos()
        {
            return new BusinessResponse<List<IPermiso>>(true, permisoDAL.SelectAllFamilias());
        }

        public BusinessResponse<List<IPermiso>> GetPermisos()
        {
            return new BusinessResponse<List<IPermiso>>(true, permisoDAL.SelectAllPermisos());
        }

        public BusinessResponse<bool> CreateFamilia(IPermiso familia)
        {
            bool ok = permisoDAL.InsertFamilia(familia);
            return new BusinessResponse<bool>(ok, ok, ok ? "Creado correctamente" : "Error al crear");
        }

        public BusinessResponse<bool> UpdateFamilia(IPermiso familia)
        {
            bool ok = permisoDAL.UpdateFamilia(familia);
            return new BusinessResponse<bool>(ok, ok, ok ? "Modificado correctamente" : "Error al modificar");
        }

        public BusinessResponse<bool> DeleteFamilia(IPermiso familia)
        {
            bool ok = permisoDAL.DeleteFamilia(familia);
            return new BusinessResponse<bool>(ok, ok, ok ? "Eliminado correctamente" : "Familia asignada a un perfil");
        }
    }
}
