using Microsoft.Data.SqlClient;
public class ContactoDAO : IValidacion
{
    public ContactoDAO()
    {
    }

    public bool AgregarContacto(Contacto c)
    {
        string telefonoSinCaracteres = ValidarTelefono(c.Telefono);
        if (telefonoSinCaracteres.Length != 10)
        {
            return false;
        }
        else
        {
            using (SqlConnection conexion = ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Contacto ( Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", c.Nombre);
                comando.Parameters.AddWithValue("@Email", c.Email);
                comando.Parameters.AddWithValue("@Telefono", telefonoSinCaracteres);

                return comando.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool ModificarContacto(Contacto c)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            string query = "UPDATE Contacto SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono WHERE ID_CONTACTO = @Id";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Nombre", c.Nombre);
            comando.Parameters.AddWithValue("@Email", c.Email);
            comando.Parameters.AddWithValue("@Telefono", c.Telefono);
            comando.Parameters.AddWithValue("@Id", c.id);


            return comando.ExecuteNonQuery() > 0;
        }
    }

    public bool EliminarContacto(int id)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            string query = "DELETE FROM Contacto WHERE ID_CONTACTO = @Id";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Id", id);


            return comando.ExecuteNonQuery() > 0;
        }
    }

    public List<Contacto> ListarContactos()
    {
        List<Contacto> lista = new List<Contacto>();
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            string query = "SELECT * FROM Contacto";
            SqlCommand comando = new SqlCommand(query, conexion);

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                lista.Add(new Contacto(
                    Convert.ToInt32(lector["ID_CONTACTO"]),
                    lector["Nombre"].ToString()!,
                    lector["Email"].ToString()!,
                    lector["Telefono"].ToString()!
                ));
            }
        }
        return lista;
    }

    public string ValidarTelefono(string telefono)
    {
        string telefonoSinCaracteres = "";
        foreach (var c in telefono)
        {
            if (char.IsDigit(c))
            {
                telefonoSinCaracteres += c;
            }
        }
        return telefonoSinCaracteres;
    }
}
