using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {
        private readonly DataAccess dataAccess;

        public ClienteDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public void AgregarCliente(ClienteBE cliente)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", cliente.DNI),
                new SqlParameter("@Nombre", cliente.Nombre),
                new SqlParameter("@Apellido", cliente.Apellido),
                new SqlParameter("@Direccion", cliente.Direccion),
                new SqlParameter("@Telefono", cliente.Telefono)
            };

            string query = "INSERT INTO Cliente (DNI, Nombre, Apellido, Direccion, Telefono) VALUES (@DNI, @Nombre, @Apellido, @Direccion, @Telefono)";

            dataAccess.WriteWithQuery(query, parameters);

        }

        public DataTable ObtenerClientes()
        {

            string query = "SELECT * FROM Cliente";

            DataTable clientes = new DataTable();

            clientes = dataAccess.ReadWithQuery(query, null);

            return clientes;
        }

        public void ActualizarCliente(ClienteBE cliente)
        {
            string query = "UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono WHERE DNI = @DNI";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", cliente.DNI),
                new SqlParameter("@Nombre", cliente.Nombre),
                new SqlParameter("@Apellido", cliente.Apellido),
                new SqlParameter("@Direccion", cliente.Direccion),
                new SqlParameter("@Telefono", cliente.Telefono)
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

        public void EliminarCliente(ClienteBE cliente)
        {
            string query = "DELETE FROM Cliente WHERE DNI = @DNI";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", cliente.DNI),
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

        public ClienteBE ObtenerClienteXDNI(int DNICliente) 
        { 
            return dataAccess.ObtenerClienteXDNI(DNICliente);
        }
    }
}
