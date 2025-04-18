using Microsoft.Data.SqlClient;
public class ConexionDB
{
    static string cadenaConexion = @"Server=BERSERK;
                                        Database=agendaDeContactos;
                                        Trusted_Connection=True;
                                        Encrypt=False;";
    private static SqlConnection conexion;

    public static SqlConnection ObtenerConexion()
    {

        conexion = new SqlConnection(cadenaConexion);
        conexion.Open();
        return conexion;

    }


}

