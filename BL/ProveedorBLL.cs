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
    public class ProveedorBLL
    {
        ProveedorDAL proveedorDAL = new ProveedorDAL();

        public void AgregarProveedor(Proveedor prov)
        {
            proveedorDAL.AgregarProveedor(prov);
        }

        public DataTable TraerTodosProv()
        {
            return proveedorDAL.TraerTodosProv();
        }

        public void ModificarProv(Proveedor prov)
        {
            proveedorDAL.ModificarProv(prov);
        }

        public void EliminarProv(Proveedor prov)
        {
            proveedorDAL.EliminarProv(prov);
        }
    }
}
