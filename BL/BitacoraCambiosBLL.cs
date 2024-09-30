using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BitacoraCambiosBLL
    {
        BitacoraCambiosDAL bitacoraCambiosDAL = new BitacoraCambiosDAL();

        public void AgregarCambio(int dni, string cambio, int codigo, string valor, DateTime fechahora)
        {
            BitacoraCambios nuevocambio = new BitacoraCambios()
            {
                DNIusuario = dni,
                Cambio = cambio,
                CodigoProducto = codigo,
                Valor = valor,
                FechaHora = fechahora
            };

            bitacoraCambiosDAL.AgregarCambio(nuevocambio);
        }

        public void AgregarCambioObj(BitacoraCambios cambio)
        {
            bitacoraCambiosDAL.AgregarCambio(cambio);
        }

        public DataTable TraerTodosCambios()
        {
            return bitacoraCambiosDAL.TraerTodosCambios();
        }
    }
}
