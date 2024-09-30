using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal static class SqlMapper
    {
        public static Perfil MapPerfil(DataRow row) => new Perfil()
        {
            Id = Convert.ToInt32(row["IdPerfil"]),
            Descripcion = row["Descripcion"].ToString()
        };

        public static Patente MapPatente(DataRow row) => new Patente()
        {
            Id = Convert.ToInt32(row["IdPermiso"]),
            Nombre = row["Nombre"].ToString()
        };

        public static Familia MapFamilia(DataRow row) => new Familia()
        {
            Id = Convert.ToInt32(row["IdPermiso"]),
            Nombre = row["Nombre"].ToString()
        };


    }
}
