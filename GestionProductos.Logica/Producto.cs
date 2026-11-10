using System;
using System.Collections.Generic;
using System.Text;

namespace GestionProductos.Logica
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; } = string.Empty;

        public decimal ValorInventario => Precio * Stock;

        public Producto()
        {
        }

        public Producto(int idProducto, string nombre, decimal precio, int stock, DateTime fechaRegistro, int idCategoria)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            FechaRegistro = fechaRegistro;
            IdCategoria = idCategoria;
        }
    }
}