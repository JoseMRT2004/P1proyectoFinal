using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace Conexionbd
{
    public class ConexionDB
    {


        static string cadenaConexion = "Server=DESKTOP-91VF8H7\\SQLEXPRESS;Database=agendaDeContactos;Trusted_Connection=True;Encrypt=False;";


        private static SqlConnection conexion;


        public static SqlConnection ObtenerConexion()
        {

            conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;

        }

      
    }
}
