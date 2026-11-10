using System;
using System.Collections.Generic;

namespace GestionProductos.Logica
{
    public class LogicaProducto
    {
        public static List<Producto> ListarProductos()
        {
            return AccesoDatos.ObtenerProductos();
        }

        public static List<Producto> BuscarProductos(string nombre)
        {
            return AccesoDatos.BuscarProductosPorNombre(nombre);
        }

        public static string ValidarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                return "El nombre del producto no puede estar vacío.";
            }

            if (producto.Precio <= 0)
            {
                return "El precio debe ser mayor que cero.";
            }
            if (producto.Stock < 0)
{
                return "El stock no puede ser negativo.";
            }



            if (producto.IdCategoria <= 0)
            {
                return "Debe seleccionar una categoría.";
            }

            return string.Empty;
        }

        public static void GuardarProducto(Producto producto)
        {
            string error = ValidarProducto(producto);
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            producto.FechaRegistro = DateTime.Now;
            AccesoDatos.InsertarProducto(producto);
        }

        public static void ModificarProducto(Producto producto)
        {
            string error = ValidarProducto(producto);
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            AccesoDatos.ModificarProducto(producto);
        }

        public static void EliminarProducto(int idProducto)
        {
            AccesoDatos.EliminarProducto(idProducto);
        }
    }
}