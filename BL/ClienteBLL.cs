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
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL;



        public ClienteBLL()
        {
            clienteDAL = new ClienteDAL();
        }

        public void AgregarCliente(int dni, string nombre, string apellido, string direccion, int telefono)
        {
            ClienteBE nuevoCliente = new ClienteBE()
            {
                DNI = dni,
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Telefono = telefono
            };

            clienteDAL.AgregarCliente(nuevoCliente);


        }

        public DataTable ObtenerClientes()
        {
            DataTable clientes = clienteDAL.ObtenerClientes();

            return clientes;
        }


        public void ActualizarCliente(int dni, string nombre, string apellido, string direccion, int telefono)
        {
            ClienteBE cliente = new ClienteBE()
            {
                DNI = dni,
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Telefono = telefono

            };
            clienteDAL.ActualizarCliente(cliente);
        }
       
        public void EliminarCliente(int dni)
        {
            ClienteBE cliente = new ClienteBE()
            {
                DNI = dni,
            };
            clienteDAL.EliminarCliente(cliente);
        }

        public ClienteBE ObtenerClienteXDNI(int DNICliente)
        {
            return clienteDAL.ObtenerClienteXDNI(DNICliente);
        }
    }
}
