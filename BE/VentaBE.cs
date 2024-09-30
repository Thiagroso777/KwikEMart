using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class VentaBE
    {
        public int IDVenta { get; set; }
        public int NumFactura { get; set; }
        public int DNICliente { get; set; }
        public int DNI { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public string MetodoPago { get; set; }
        public int IDEnvio { get; set; }
    }
}
