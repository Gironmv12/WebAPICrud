using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICrud.Models.Api.Response
{
    /// <summary>
    /// Modelo de vista de respuesta de producto
    /// </summary>
    public class ProductoResponseViewModel
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }

        public decimal precio { get; set; }
        public int cantidad_stock { get; set; }
        public int IdProveedor { get; set; }
    }

    /// <summary>
    /// Modelo de vista de respuesta de productos
    /// </summary>
    public class ProductosResponseViewModel
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad_stock { get; set; }
        public int IdProveedor { get; set; }
    }

    /// <summary>
    /// Modelo de vista de respuesta de proveedores
    /// </summary>
    public class ProveedoresResponseViewModel
    {

    }

}
