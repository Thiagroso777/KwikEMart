using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VentaDAL
    {
        private readonly DataAccess dataAccess;


        public VentaDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public void RegistrarVenta(VentaBE venta)
        {
            string query = "INSERT INTO Venta (IDVenta, NumFactura, DNICliente, DNI, Fecha, Total, MetodoPago, IDEnvio) VALUES (@IDVenta, @NumFactura, @DNICliente, @DNI, @Fecha, @Total, @MetodoPago, @IDEnvio)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IDVenta", venta.IDVenta),
                new SqlParameter("@NumFactura", venta.NumFactura),
                new SqlParameter("@DNICliente", venta.DNICliente),
                new SqlParameter("@DNI", venta.DNI),
                new SqlParameter("@Fecha", venta.Fecha),
                new SqlParameter("@Total", venta.Total),
                new SqlParameter("@MetodoPago", venta.MetodoPago),
                new SqlParameter("@IDEnvio", venta.IDEnvio)
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

    }
}
