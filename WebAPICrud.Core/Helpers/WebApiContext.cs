using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICrud.Core.Helpers
{
    /// <summary>
    /// Clase de contexto para la base de datos de la API web.
    /// </summary>
    public class WebApiContext : DbContext
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public WebApiContext() { }

        /// <summary>
        /// Constructor que acepta opciones de contexto de base de datos.
        /// </summary>
        /// <param name="options">Opciones de contexto de base de datos.</param>
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }

        /// <summary>
        /// Constructor que acepta una cadena de conexión.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public WebApiContext(string connectionString) : base(Helpers.ContextConfiguration.GetOptions(connectionString)) { }

        /// <summary>
        /// Método para configurar el contexto de la base de datos.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones de contexto de base de datos.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helpers.ContextConfiguration.ConexionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
        }

    }
}
