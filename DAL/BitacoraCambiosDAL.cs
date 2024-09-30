using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BitacoraCambiosDAL
    {
        private readonly DataAccess dataAccess;

        public BitacoraCambiosDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public void AgregarCambio(BitacoraCambios nuevocambio)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNIUsuario", nuevocambio.DNIusuario),
                new SqlParameter("@Cambio", nuevocambio.Cambio),
                new SqlParameter("@CodigoProducto", nuevocambio.CodigoProducto),
                new SqlParameter("@Valor", nuevocambio.Valor),
                new SqlParameter("@FechaHora", nuevocambio.FechaHora)
            };

            string query = "INSERT INTO BitacoraCambios (DNIusuario, Cambio, CodigoProducto, Valor, FechaHora) VALUES (@DNIusuario, @Cambio, @CodigoProducto, @Valor, @FechaHora)";

            dataAccess.WriteWithQuery(query, parameters);
        }

        public DataTable TraerTodosCambios()
        {
            string query = "SELECT * FROM BitacoraCambios";

            DataTable data = new DataTable();

            data = dataAccess.ReadWithQuery(query, null);

            return data;
        }
    }
}
