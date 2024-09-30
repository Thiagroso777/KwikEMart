using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductoVentaBE
    {
        public int IDProductoVenta { get; set; }
        public int IDVenta { get; set; }
        public int Codigo { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int PrecioTotProd { get; set; }
    }
}
