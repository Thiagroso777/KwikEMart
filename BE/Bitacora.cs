using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int IDEvento { get; set; }
        public int DNIusuario { get; set; }
        public string Evento { get; set; }
        public DateTime FechaHora { get; set; }
        public int Riesgo { get; set; }
    }
}
