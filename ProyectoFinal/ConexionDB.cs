using Microsoft.Data.SqlClient;
public class ConexionDB
{
    static string cadenaConexion = @"Server=BERSERK;
                                        Database=agendaDeContactos;
                                        Trusted_Connection=True;
                                        Encrypt=False;";

    public static SqlConnection ObtenerConexion()
    {
        SqlConnection conexion = new SqlConnection(cadenaConexion);
        conexion.Open();
        return conexion;
    }


}

