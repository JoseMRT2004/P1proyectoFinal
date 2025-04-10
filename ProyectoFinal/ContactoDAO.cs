using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


public class ContactoDAO
{
    private string cadenaConexion;

    public ContactoDAO(string cadenaConexion)
    {
        this.cadenaConexion = cadenaConexion;
    }

    public bool AgregarContacto(Contacto c)
    {
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            string query = "INSERT INTO Contactos (Id, Nombre, Email, Telefono) VALUES (@Id, @Nombre, @Email, @Telefono)";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Id", c.Id);
            comando.Parameters.AddWithValue("@Nombre", c.Nombre);
            comando.Parameters.AddWithValue("@Email", c.Email);
            comando.Parameters.AddWithValue("@Telefono", c.Telefono);

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }
    }

    public bool ModificarContacto(Contacto c)
    {
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            string query = "UPDATE Contactos SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono WHERE Id = @Id";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Nombre", c.Nombre);
            comando.Parameters.AddWithValue("@Email", c.Email);
            comando.Parameters.AddWithValue("@Telefono", c.Telefono);
            comando.Parameters.AddWithValue("@Id", c.Id);

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }
    }

    public bool EliminarContacto(int id)
    {
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            string query = "DELETE FROM Contactos WHERE Id = @Id";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@Id", id);

            conexion.Open();
            return comando.ExecuteNonQuery() > 0;
        }
    }

    public List<Contacto> ListarContactos()
    {
        List<Contacto> lista = new List<Contacto>();
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            string query = "SELECT * FROM Contactos";
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                lista.Add(new Contacto(
                    Convert.ToInt32(lector["Id"]),
                    lector["Nombre"].ToString()!,
                    lector["Email"].ToString()!,
                    lector["Telefono"].ToString()!
                ));
            }
        }
        return lista;
    }
}
