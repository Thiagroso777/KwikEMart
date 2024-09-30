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
    public class BitacoraEventosBLL
    {
        BitacoraEventosDAL bitacoraEventosDAL = new BitacoraEventosDAL();

        public void AgregarEvento(int dni, string evento, DateTime fechahora, int riesgo)
        {
            Bitacora Evento = new Bitacora()
            {
                DNIusuario = dni,
                Evento = evento,
                FechaHora = fechahora,
                Riesgo = riesgo
            };

            bitacoraEventosDAL.AgregarEvento(Evento);
        }

        public void AgregarEventoObj(Bitacora Evento)
        {
            bitacoraEventosDAL.AgregarEvento(Evento);
        }

        public DataTable TraerTodosEventos()
        {
            return bitacoraEventosDAL.TraerTodosEventos();
        }
    }
}
