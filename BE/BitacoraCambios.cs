using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BitacoraCambios
    {
        public int IDCambio { get; set; }
        public int DNIusuario { get; set; }
        public string Cambio { get; set; }
        public DateTime FechaHora { get; set; }
        public string Valor { get; set; }
        public int CodigoProducto { get; set; }
    }
}
