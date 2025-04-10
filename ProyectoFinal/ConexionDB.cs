using Microsoft.Data.SqlClient;  
using System;
using System.Configuration;

namespace Conexionbd
{
    public class ConexionDB
    {
       

static string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

       
        private static SqlConnection conexion;


        public static SqlConnection ObtenerConexion()
        {
           
            if (conexion == null)
                conexion = new SqlConnection(cadenaConexion);

            try
            {
                
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception)
            {
                
            }

            return conexion;
        }

        // Método estático para cerrar la conexión
        public static void CerrarConexion()
        {
           
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    conexion.Close();
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
