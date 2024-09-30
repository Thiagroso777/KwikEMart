using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        private readonly DataAccess dataAccess;


        public UsuarioDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public UsuarioBE ObtenerUsuarioXDNI(int dni)
        {
            return dataAccess.ObtenerUsuarioPorDNI(dni);
        }

        public void ActualizarUsuarioNuevo(UsuarioBE usuario)
        {

            string query = "UPDATE Usuario SET NombreUsuario = @NombreUsuario, ApellidoUsuario = @ApellidoUsuario, Contraseña = @Contraseña, EstaBloqueado = @EstaBloqueado, IntentosFallidos = @IntentosFallidos WHERE DNI = @DNI";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", usuario.NombreUsuario),
                new SqlParameter("@ApellidoUsuario", usuario.ApellidoUsuario),
                new SqlParameter("@Contraseña", usuario.Contraseña),
                new SqlParameter("@EstaBloqueado", usuario.EstaBloqueado),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos),
                new SqlParameter("@DNI", usuario.DNI)
            };

            dataAccess.WriteWithQuery(query, parameters);
        }



        public void DesbloquearUsuarioNuevo(UsuarioBE usuario)
        {
            
            string query = "UPDATE Usuario SET EstaBloqueado = 'False', IntentosFallidos = 0 WHERE DNI = @DNI";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", usuario.DNI)
            };

            dataAccess.WriteWithQuery(query, parameters);
            
        }


        public void AgregarUsuarioNuevo(UsuarioBE usuario)
        {
          
            string query = "INSERT INTO Usuario (DNI, NombreUsuario, ApellidoUsuario, Contraseña, Rol, EstaBloqueado, IntentosFallidos) VALUES (@DNI, @NombreUsuario, @ApellidoUsuario, @Contraseña, @Rol, @EstaBloqueado, @IntentosFallidos)";
                
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", usuario.NombreUsuario),
                new SqlParameter("@ApellidoUsuario", usuario.ApellidoUsuario),
                new SqlParameter("@Contraseña", usuario.Contraseña),
                new SqlParameter("@Rol",  usuario.Rol.Id),
                new SqlParameter("@EstaBloqueado", usuario.EstaBloqueado),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos),
                new SqlParameter("@DNI", usuario.DNI)
            };

            dataAccess.WriteWithQuery(query, parameters);
            
        }

        public DataTable ObtenerUsuarios()
        {

            string query = "SELECT DNI, NombreUsuario, ApellidoUsuario, Rol, EstaBloqueado FROM Usuario";

            DataTable usuarios = new DataTable();

            usuarios = dataAccess.ReadWithQuery(query, null);

            return usuarios;
        }

        public int ObtenerRol(int dni)
        {
            return dataAccess.ObtenerRolUsuario(dni);
        }
        
        
    }
}
