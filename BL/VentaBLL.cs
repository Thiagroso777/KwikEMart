using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VentaBLL
    {
        VentaDAL ventaDAL = new VentaDAL();

        public void RegistrarVenta(VentaBE venta)
        {
            ventaDAL.RegistrarVenta(venta);
        }
    }
}
