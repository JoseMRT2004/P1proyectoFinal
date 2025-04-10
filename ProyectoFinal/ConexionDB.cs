using Microsoft.Data.SqlClient;  
using System;

namespace Conexionbd
{
    public class ConexionDB
    {
       
        private static readonly string cadenaConexion = "Server=Laptop12;Database=agendaDeContactos;Trusted_Connection=True;Encrypt=False;";

       
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
