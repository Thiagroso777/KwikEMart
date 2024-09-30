using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAL
    {

        private readonly DataAccess dataAccess;

        public ProductoDAL()
        {
            dataAccess = DataAccess.GetInstance();
        }

        public DataTable ObtenerProductos()
        {

            string query = "SELECT * FROM Producto";

            DataTable productos = new DataTable();

            productos = dataAccess.ReadWithQuery(query, null);

            return productos;
        }

        public ProductoBE ObtenerProductoXCodigo(int Codigo)
        {
            return dataAccess.ObtenerProductoXCodigo(Codigo);
        }

        public void AgregarProducto(ProductoBE producto)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", producto.Codigo),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@IDProveedor", producto.IDProveedor)
            };

            string query = "INSERT INTO Producto (Codigo, Descripcion, Precio, Stock, IDProveedor) VALUES (@Codigo, @Descripcion, @Precio, @Stock, @IDProveedor)";

            dataAccess.WriteWithQuery(query, parameters);

        }

        public void ActualizarProducto(ProductoBE producto)
        {
            string query = "UPDATE Producto SET Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock, IDProveedor = @IDProveedor WHERE Codigo = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", producto.Codigo),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@IDProveedor", producto.IDProveedor)
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

        public void EliminarProducto(ProductoBE producto)
        {
            string query = "DELETE FROM Producto WHERE Codigo = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", producto.Codigo),
            };

            dataAccess.WriteWithQuery(query, parameters);
        }

        public void RestarStock(int codigo, int cantidad)
        {
            string query = "UPDATE Producto SET Stock = Stock - @Cantidad WHERE Codigo = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", codigo),
                new SqlParameter("@Cantidad", cantidad),
            };
            dataAccess.WriteWithQuery(query, parameters);
        }
    }
}
