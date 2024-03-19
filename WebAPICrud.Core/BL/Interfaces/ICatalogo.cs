using System;
using System.Collections.Generic;
using System.Text;
using WebAPICrud.Models.Api.Response;

namespace WebAPICrud.Core.BL.Interfaces
{
    /// <summary>
    /// Interfaz ICatalogo para la gestión de productos.
    /// </summary>
    public interface ICatalogo
    {
        /// <summary>
        /// Método para obtener una lista de productos.
        /// </summary>
        /// <returns>Devuelve una lista de productos.</returns>
        Task<List<ProductosResponseViewModel>> ObtenerProductos();
    }
}
