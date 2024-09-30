using BE;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductoBLL
    {
        private ProductoDAL productoDAL;
        public ProductoBLL()
        {
            productoDAL = new ProductoDAL();
        }

        public DataTable ObtenerProductos()
        {
            DataTable productos = productoDAL.ObtenerProductos();

            return productos;
        }

        public ProductoBE ObtenerProductoXCodigo(int Codigo)
        {
            return productoDAL.ObtenerProductoXCodigo(Codigo);
        }

        public void AgregarProducto(int codigo, string descripcion, int precio, int stock, int idprov)
        {
            ProductoBE nuevoProducto = new ProductoBE()
            {
                Codigo = codigo,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock,
                IDProveedor = idprov
            };

            productoDAL.AgregarProducto(nuevoProducto);
        }

        public void ActualizarProducto(int codigo, string descripcion, int precio, int stock, int idprov)
        {
            ProductoBE producto = new ProductoBE()
            {
                Codigo = codigo,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock,
                IDProveedor = idprov
            };

            productoDAL.ActualizarProducto(producto);
        }

        public void EliminarProducto(int codigo)
        {
            ProductoBE producto = new ProductoBE()
            {
                Codigo = codigo,
            };
            productoDAL.EliminarProducto(producto);
        }

        public void RestarStock(int codigo, int cantidad)
        {
            productoDAL.RestarStock(codigo, cantidad);
        }
    }
}
