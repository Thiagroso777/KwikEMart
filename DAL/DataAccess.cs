using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DataAccess
    {
        private static DataAccess instance;
        private readonly SqlConnection _connection;

        private DataAccess()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-RTTP11I\\SQLEXPRESS;Initial Catalog=KwikEMart;Integrated Security=True");
        }

        
        private string connectionString = "Data Source=DESKTOP-RTTP11I\\SQLEXPRESS;Initial Catalog=KwikEMart;Integrated Security=True";

        public static DataAccess GetInstance()
        {
            if(instance is null)
            {
                instance = new DataAccess();
            }

            return instance;
        }

        public void OpenDB()
        {
            _connection.Open();
        }

        public void CloseDB()
        {
            _connection.Close();
        }

        public DataTable ReadWithQuery(string query, SqlParameter[] parameters = null)
        {
            OpenDB();

            DataTable dataTable = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = query
                }
            };

            if (parameters != null)
            {
                sqlDataAdapter.SelectCommand.Parameters.Clear();
                sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters);
            }

            sqlDataAdapter.SelectCommand.Connection = _connection;

            
            sqlDataAdapter.Fill(dataTable);

            CloseDB();

            return dataTable;
        }

        public void RestaurarDB(string query)
        {
            string ConnectionString = connectionString;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        public bool WriteWithQuery(string query, SqlParameter[] parameters)
        {
            if (parameters.Length == 0) return false;

            int canInsert = -1;

            OpenDB();
            SqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = query,
                    Connection = _connection,
                    Transaction = transaction
                };

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(parameters);

                canInsert = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }

            CloseDB();

            return canInsert != -1;
        }

        public UsuarioBE ObtenerUsuarioPorDNI(int dni)
        {
            UsuarioBE usuario = null;
            string query = "SELECT * FROM Usuario WHERE DNI = @DNI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DNI", dni);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    usuario = new UsuarioBE
                    {
                        DNI = (int)reader["DNI"],
                        NombreUsuario = (string)reader["NombreUsuario"],
                        ApellidoUsuario = (string)reader["ApellidoUsuario"],
                        Contraseña = (string)reader["Contraseña"],
                        EstaBloqueado = (string)reader["EstaBloqueado"],
                        IntentosFallidos = (int)reader["IntentosFallidos"] 
                    };
                }

                connection.Close();
            }

            return usuario;
        }

        public ClienteBE ObtenerClienteXDNI(int DNICliente)
        {
            ClienteBE cliente = null;
            string query = "SELECT * FROM Cliente WHERE DNI = @DNI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DNI", DNICliente);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new ClienteBE
                    {
                        DNI = (int)reader["DNI"],
                        Nombre = (string)reader["Nombre"],
                        Apellido = (string)reader["Apellido"],
                        Direccion = (string)reader["Direccion"],
                        Telefono = (int)reader["Telefono"]
                    };
                }
                connection.Close();
            }

            return cliente;
        }

        public ProductoBE ObtenerProductoXCodigo(int Codigo)
        {
            ProductoBE producto = null;
            string query = "SELECT * FROM Producto WHERE Codigo = @Codigo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codigo", Codigo);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    producto = new ProductoBE
                    {
                        Codigo = (int)reader["Codigo"],
                        Descripcion = (string)reader["Descripcion"],
                        Stock = (int)reader["Stock"],
                        Precio = (int)reader["Precio"],
                        IDProveedor = (int)reader["IDProveedor"]
                    };
                }
                connection.Close();
            }

            return producto;
        }

        public int ObtenerRolUsuario(int dni)
        {
            int rol = 0;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Rol FROM Usuario WHERE DNI = @DNI";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DNI", dni);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    rol = reader.GetInt32(0);
                }
                connection.Close();
                return rol;
            }

        }

    }
}
