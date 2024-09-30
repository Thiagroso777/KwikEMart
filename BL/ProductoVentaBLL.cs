using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductoVentaBLL
    {
        ProductoVentaDAL productoventaDAL = new ProductoVentaDAL();

        public void RegistrarProductoVenta(ProductoVentaBE productoventa)
        {
            productoventaDAL.RegistrarProductoVenta(productoventa);
        }

    }
}
