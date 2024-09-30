using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoVentaDAL
    {
        private readonly DataAccess dataAccess;


        public ProductoVentaDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public void RegistrarProductoVenta(ProductoVentaBE productoventa)
        {
            string query = "INSERT INTO ProductoVenta (IDProductoVenta, IDVenta, Codigo, Cantidad, Precio, PrecioTotProd) VALUES (@IDProductoVenta, @IDVenta, @Codigo, @Cantidad, @Precio, @PrecioTotProd)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IDProductoVenta", productoventa.IDProductoVenta),
                new SqlParameter("@IDVenta", productoventa.IDVenta),
                new SqlParameter("@Codigo", productoventa.Codigo),
                new SqlParameter("@Cantidad", productoventa.Cantidad),
                new SqlParameter("@Precio", productoventa.Precio),
                new SqlParameter("@PrecioTotProd", productoventa.PrecioTotProd),
            };

            dataAccess.WriteWithQuery(query, parameters);
        }
    }
}
