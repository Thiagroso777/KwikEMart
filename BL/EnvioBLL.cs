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
    public class EnvioBLL
    {
        EnvioDAL envioDAL = new EnvioDAL();

        public void RegistrarEnvio(EnvioBE envio)
        {
            envioDAL.RegistrarEnvio(envio);
        }

        public DataTable TraerEnviosPendientes()
        {
            
            return envioDAL.TraerEnviosPendientes();
        }

        public void Confirmar(int IDVenta)
        {
            envioDAL.Confirmar(IDVenta);
        }

        public void Entregado(int IDVenta)
        {
            envioDAL.Entregado(IDVenta);
        }
    }
}
