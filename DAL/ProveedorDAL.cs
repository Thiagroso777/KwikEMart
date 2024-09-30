using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDAL
    {

        private readonly DataAccess dataAccess;

        public ProveedorDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }
        public void AgregarProveedor(Proveedor prov)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CUIT", prov.CUIT),
                new SqlParameter("@Nombre", prov.Nombre),
                new SqlParameter("@Mail", prov.Mail),
                new SqlParameter("@Telefono", prov.Telefono),
                new SqlParameter("@CBU", prov.CBU),
                new SqlParameter("@Alias", prov.Alias)
            };

            string query = "INSERT INTO Proveedor (CUIT, Nombre, Mail, Telefono, CBU, Alias) VALUES (@CUIT, @Nombre, @Mail, @Telefono, @CBU, @Alias)";

            dataAccess.WriteWithQuery(query, parameters);
        }

        public DataTable TraerTodosProv()
        {
            string query = "SELECT * FROM Proveedor";

            DataTable data = new DataTable();

            data = dataAccess.ReadWithQuery(query, null);

            return data;
        }

        public void ModificarProv(Proveedor prov)
        {
            string query = "UPDATE Proveedor SET Alias = @Alias, Nombre = @Nombre, Mail = @Mail, Telefono = @Telefono, CBU = @CBU WHERE CUIT = @CUIT";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", prov.Nombre),
                new SqlParameter("@Mail", prov.Mail),
                new SqlParameter("@Telefono", prov.Telefono),
                new SqlParameter("@CBU", prov.CBU),
                new SqlParameter("@Alias", prov.Alias),
                new SqlParameter("@CUIT", prov.CUIT)
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

        public void EliminarProv(Proveedor prov)
        {
            string query = "Delete from Proveedor WHERE CUIT = @CUIT";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CUIT", prov.CUIT)
            };

            dataAccess.WriteWithQuery(query, parameters);
        }
    }
}
