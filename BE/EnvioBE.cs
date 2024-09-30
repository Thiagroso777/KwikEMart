using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EnvioBE
    {
        public int IDEnvio { get; set; }
        public int IDVenta { get; set; }
        public string Direccion { get; set; }
        public int DNI { get; set; }
        public string Pendiente { get; set; }
    }
}
