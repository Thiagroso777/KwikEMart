using BE;
using DAL;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioBLL
    {
        
        private UsuarioDAL usuarioDAL;


        public UsuarioBLL()
        {
            usuarioDAL = new UsuarioDAL();
        }
 
        public bool ValidarUsuario(int dni, string contraseña)
        {
            UsuarioBE usuario = usuarioDAL.ObtenerUsuarioXDNI(dni);
            if (usuario == null || usuario.EstaBloqueado == "True")
            {
                return false;
            }

            string hashContraseña = CryptoManager.EncryptString(contraseña);

            return usuario.Contraseña == hashContraseña;
        }

        public UsuarioBE ObtenerUsuarioPorDNI(int dni)
        {
            return usuarioDAL.ObtenerUsuarioXDNI(dni);
        }

        public void ActualizarUsuario(UsuarioBE usuario)
        {
            usuarioDAL.ActualizarUsuarioNuevo(usuario);
        }


        public void DesbloquearUsuario(int dni)
        {
            UsuarioBE usuario = ObtenerUsuarioPorDNI(dni);

            usuarioDAL.DesbloquearUsuarioNuevo(usuario);
        }

        public void AgregarUsuario(UsuarioBE usuario)
        {
            

            usuarioDAL.AgregarUsuarioNuevo(usuario);

           
        }

        public DataTable ObtenerUsuarios()
        {
            

            DataTable usuarios = usuarioDAL.ObtenerUsuarios();

            return usuarios;
        }

        public void BloquearUsuario(int dni)
        {
            UsuarioBE usuario = ObtenerUsuarioPorDNI(dni);
            if (usuario != null)
            {
                usuario.EstaBloqueado = "True";
                ActualizarUsuario(usuario);
            }
        }

        public void ActualizarUsuario(int dni, string nombre, string apellido, Perfil rol)
        {
            UsuarioBE usuario = ObtenerUsuarioPorDNI(dni);
            if (usuario != null)
            {
                usuario.NombreUsuario = nombre;
                usuario.ApellidoUsuario = apellido;
                usuario.Rol = rol;
                ActualizarUsuario(usuario);
            }
        }

        public int ObtenerRolUsuario(int dni)
        {     
            return usuarioDAL.ObtenerRol(dni);
        }
    }
}
