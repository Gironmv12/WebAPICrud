using System;
using System.Collections.Generic;
using System.Text;
using WebAPICrud.Models.Api.Response;
using Microsoft.Data.SqlClient;
using WebAPICrud.Core.BL.Interfaces;

namespace WebAPICrud.Core.BL.Services
{
    /// <summary>
    /// Clase de servicio para el catálogo.
    /// Implementa la interfaz ICatalogo.
    /// </summary>
    public class CatalogoService : ICatalogo
    {
        /// <summary>
        /// Método asincrónico para obtener productos.
        /// </summary>
        /// <returns>
        /// Una lista de productos en formato de vista de modelo de respuesta.
        /// </returns>
        public async Task<List<ProductosResponseViewModel>> ObtenerProductos()
        {

            /// <summary>
            /// Establece una nueva conexión SQL utilizando la cadena de conexión de la configuración del contexto.
            /// </summary>
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                /// <summary>
                /// Crea una nueva lista de productos.
                /// </summary>
                List<ProductosResponseViewModel> productos = new List<ProductosResponseViewModel>();

                /// <summary>
                /// Crea un nuevo comando SQL.
                /// </summary>
                var command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "[Catalogos].[ObtenerProductos]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();

                /// <summary>
                /// Ejecuta el comando SQL de forma asincrónica y lee los resultados.
                /// </summary>
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            /// <summary>
                            /// Agrega un nuevo producto a la lista de productos.
                            /// </summary>
                            productos.Add(new ProductosResponseViewModel
                            {
                                id_producto = reader.GetInt32(reader.GetOrdinal("id_producto")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                cantidad_stock = reader.GetInt32(reader.GetOrdinal("cantidad_stock")),
                                IdProveedor = reader.GetInt32(reader.GetOrdinal("IdProveedor"))
                            });
                        }
                        catch (Exception ex)
                        {
                            /// <summary>
                            /// Captura cualquier excepción y guarda el mensaje de error.
                            /// </summary>
                            var error = ex.Message.ToString();
                        }
                    }
                }
                /// <summary>
                /// Cierra la conexión a la base de datos.
                /// </summary>
                conexion.Close();
                /// <summary>
                /// Devuelve la lista de productos obtenidos de la base de datos.
                /// </summary>
                return productos;
            }
        }
    }
}
