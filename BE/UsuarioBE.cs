using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE : Entidad
    {
        public int DNI { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string Contraseña { get; set; }
        public Perfil Rol { get; set; }
        public string EstaBloqueado { get; set; }
        public int IntentosFallidos { get; set; }
    }
}
