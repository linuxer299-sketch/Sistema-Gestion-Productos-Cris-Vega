using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace GestionProductos.Logica
{
    public class AccesoDatos
    {
        private static string cadenaConexion = @"Server=localhost\SQLEXPRESS;Database=GestionProductosDB;Trusted_Connection=True;TrustServerCertificate=True;";


        public static List<Categoria> ObtenerCategorias()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "SELECT IdCategoria, Nombre, Descripcion FROM Categorias";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Categoria cat = new Categoria(
                        (int)lector["IdCategoria"],
                        lector["Nombre"].ToString(),
                        lector["Descripcion"].ToString()
                    );
                    lista.Add(cat);
                }
            }

            return lista;
        }

        public static void InsertarCategoria(Categoria categoria)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                comando.ExecuteNonQuery();
            }
        }

        public static void ModificarCategoria(Categoria categoria)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IdCategoria = @Id";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                comando.Parameters.AddWithValue("@Id", categoria.IdCategoria);
                comando.ExecuteNonQuery();
            }
        }

        public static void EliminarCategoria(int idCategoria)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "DELETE FROM Categorias WHERE IdCategoria = @Id";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", idCategoria);
                comando.ExecuteNonQuery();
            }
        }


        public static List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = "SELECT P.IdProducto, P.Nombre, P.Precio, P.Stock, P.FechaRegistro, P.IdCategoria, C.Nombre AS NombreCategoria FROM Productos P INNER JOIN Categorias C ON P.IdCategoria = C.IdCategoria";

                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto prod = new Producto(
                        (int)lector["IdProducto"],
                        lector["Nombre"].ToString(),
                        (decimal)lector["Precio"],
                        (int)lector["Stock"],
                        (DateTime)lector["FechaRegistro"],
                        (int)lector["IdCategoria"]
                    );

                    prod.NombreCategoria =
                        lector["NombreCategoria"]?.ToString() ?? string.Empty;

                    lista.Add(prod);
                }
            }

            return lista;
        }

        public static List<Producto> BuscarProductosPorNombre(string nombre)
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string sql = "SELECT P.IdProducto, P.Nombre, P.Precio, P.Stock, P.FechaRegistro, P.IdCategoria, C.Nombre AS NombreCategoria FROM Productos P INNER JOIN Categorias C ON P.IdCategoria = C.IdCategoria WHERE P.Nombre LIKE @Nombre";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto prod = new Producto(
                        (int)lector["IdProducto"],
                        lector["Nombre"].ToString(),
                        (decimal)lector["Precio"],
                        (int)lector["Stock"],
                        (DateTime)lector["FechaRegistro"],
                        (int)lector["IdCategoria"]
                    );

                    prod.NombreCategoria =
                        lector["NombreCategoria"]?.ToString() ?? string.Empty;

                    lista.Add(prod);
                }
            }

            return lista;
        }

        public static void InsertarProducto(Producto producto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "INSERT INTO Productos (Nombre, Precio, Stock, FechaRegistro, IdCategoria) VALUES (@Nombre, @Precio, @Stock, @FechaRegistro, @IdCategoria)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                comando.Parameters.AddWithValue("@FechaRegistro", producto.FechaRegistro);
                comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                comando.ExecuteNonQuery();
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock, IdCategoria = @IdCategoria WHERE IdProducto = @Id";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                comando.Parameters.AddWithValue("@Id", producto.IdProducto);
                comando.ExecuteNonQuery();
            }
        }

        public static void EliminarProducto(int idProducto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "DELETE FROM Productos WHERE IdProducto = @Id";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Id", idProducto);
                comando.ExecuteNonQuery();
            }
        }
    }
}