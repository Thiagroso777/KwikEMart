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
    public class EnvioDAL
    {
        private readonly DataAccess dataAccess;

        public EnvioDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }


        public void RegistrarEnvio(EnvioBE envio)
        {
            string query = "INSERT INTO Envio (IDEnvio, IDVenta, Direccion, DNI, Pendiente, Verificado) VALUES (@IDEnvio, @IDVenta, @Direccion, @DNI, @Pendiente, @Verificado)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IDEnvio", envio.IDEnvio),
                new SqlParameter("@IDVenta", envio.IDVenta),
                new SqlParameter("@Direccion", envio.Direccion),
                new SqlParameter("@DNI", envio.DNI),
                new SqlParameter("@Pendiente", envio.Pendiente),
                new SqlParameter("@Verificado", "False"),
            };

            dataAccess.WriteWithQuery(query, parameters);
        }
        public DataTable TraerEnviosPendientes()
        {
            string query = "SELECT \r\n    e.IDEnvio,\r\n    e.DNI,\r\n    e.Direccion,\r\n    pv.Codigo,\r\n    pv.Cantidad,\r\n    e.Pendiente,\r\n    e.Verificado\r\nFROM \r\n    Envio e\r\nINNER JOIN \r\n    ProductoVenta pv\r\nON \r\n    e.IDVenta = pv.IDVenta\r\nWHERE \r\n    e.Pendiente = 'True'";

            DataTable pendientes = new DataTable();

            pendientes = dataAccess.ReadWithQuery(query, null);

            return pendientes;
        }

        public void Confirmar(int IDVenta)
        {  
            string query = "UPDATE Envio SET Verificado = 'True' WHERE IDVenta = @IDVenta";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IDVenta", IDVenta),
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

        public void Entregado(int IDVenta)
        {
            string query = "UPDATE Envio SET Pendiente = 'False' WHERE IDVenta = @IDVenta";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IDVenta", IDVenta),
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

            
        
    }
}
