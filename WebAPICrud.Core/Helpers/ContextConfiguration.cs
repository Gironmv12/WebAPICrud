using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WebAPICrud.Core.Helpers
{
    public class ContextConfiguration
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        public static string ConexionString { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextConfiguration"/> class.
        /// </summary>
        /// <param name="conexion">The connection string.</param>
        public ContextConfiguration(string conexion)
        {
            ConexionString = conexion;
        }

        #region Metodos

        /// <summary>
        /// Gets the DbContextOptions for the given connection string.
        /// </summary>
        /// <param name="ConexionString">The connection string to the database.</param>
        /// <returns>The DbContextOptions configured with the given connection string.</returns>
        public static DbContextOptions GetOptions(string ConexionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConexionString).Options;
        }

        #endregion

        
        

    }
}
