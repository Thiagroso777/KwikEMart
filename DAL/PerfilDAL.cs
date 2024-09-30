using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;

namespace DAL
{
    public class PerfilDAL
    {
        private readonly DBConnection _connection;
        private readonly DataAccess dataAccess;

        public PerfilDAL()
        {
            _connection = DBConnection.GetInstance();
            dataAccess = DataAccess.GetInstance();
        }

        
        public int TraerPorUsuario(int dni)
        {
            return dataAccess.ObtenerRolUsuario(dni);
        }

        public Perfil SelectByUser(UsuarioBE user)
        {
            SqlParameter[] paramters = new SqlParameter[]
            {
                new SqlParameter("@In_IdUser", SqlDbType.Int){ Value = user.DNI }
            };

            DataTable data = _connection.Read("SP_SelectUserPerfil", paramters);

            return SqlMapper.MapPerfil(data.Rows[0]);
        }

        public List<Perfil> SelectAll()
        {
            List<Perfil> perfiles = new List<Perfil>();

            DataTable data = _connection.Read("SP_SelectPerfiles");

            foreach (DataRow row in data.Rows)
            {
                perfiles.Add(SqlMapper.MapPerfil(row));
            }

            return perfiles;
        }

        public bool Insert(Perfil perfil)
        {
            bool ok = false;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_descripcion", SqlDbType.NVarChar){ Value = perfil.Descripcion }
            };

            perfil.Id = _connection.WriteWithReturn("SP_CreatePerfil", parameters);

            foreach (IPermiso permiso in perfil.Permisos)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id },
                    new SqlParameter("@In_IdPermiso", SqlDbType.Int){ Value = permiso.Id }
                };

                ok = _connection.Write("SP_CreatePermisoPerfil", parameters);
            }

            return ok;
        }

        public bool Update(Perfil perfil)
        {
            bool ok = false;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id },
                new SqlParameter("@In_Descripcion", SqlDbType.NVarChar){ Value = perfil.Descripcion }
            };

            ok = _connection.Write("SP_UpdatePerfil", parameters);

            parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value =perfil.Id }
            };

            ok = _connection.Write("SP_DeletePermisoPerfil", parameters);

            foreach (IPermiso permiso in perfil.Permisos)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id },
                    new SqlParameter("@In_IdPermiso", SqlDbType.Int){ Value = permiso.Id }
                };

                ok = _connection.Write("SP_CreatePermisoPerfil", parameters);
            }

            return ok;
        }

        public bool Delete(Entidad perfil)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id }
            };

            return _connection.Write("SP_DeletePerfil", parameters);
        }
    }
}
