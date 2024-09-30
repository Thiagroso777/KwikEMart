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
    public class BitacoraEventosDAL
    {
        private readonly DataAccess dataAccess;

        public BitacoraEventosDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public void AgregarEvento(Bitacora Evento)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNIUsuario", Evento.DNIusuario),
                new SqlParameter("@Evento", Evento.Evento),
                new SqlParameter("@FechaHora", Evento.FechaHora),
                new SqlParameter("@Riesgo", Evento.Riesgo)
            };

            string query = "INSERT INTO Bitacora (DNIusuario, Evento, FechaHora, Riesgo) VALUES (@DNIusuario, @Evento, @FechaHora, @Riesgo)";

            dataAccess.WriteWithQuery(query, parameters);
        }

        public DataTable TraerTodosEventos()
        {
            string query = "SELECT * FROM Bitacora WHERE FechaHora >= DATEADD(DAY, -3, GETDATE())";

            DataTable data = new DataTable();

            data = dataAccess.ReadWithQuery(query, null);

            return data;
        }
    }
}
