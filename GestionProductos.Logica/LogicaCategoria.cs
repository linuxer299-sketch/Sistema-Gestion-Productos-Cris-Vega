using System;
using System.Collections.Generic;

namespace GestionProductos.Logica
{
    public class LogicaCategoria
    {
        public static List<Categoria> ListarCategorias()
        {
            return AccesoDatos.ObtenerCategorias();
        }

        public static string ValidarCategoria(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
            {
                return "El nombre de la categoría no puede estar vacío.";
            }

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
            {
                return "La descripción no puede estar vacía.";
            }

            return string.Empty;
        }

        public static void GuardarCategoria(Categoria categoria)
        {
            string error = ValidarCategoria(categoria);
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            AccesoDatos.InsertarCategoria(categoria);
        }


        public static void EliminarCategoria(int idCategoria)
        {
            AccesoDatos.EliminarCategoria(idCategoria);
        }
       
        
        public static void ModificarCategoria(Categoria categoria)
        {
            string error = ValidarCategoria(categoria);
            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            AccesoDatos.ModificarCategoria(categoria);
        }

    }
}
