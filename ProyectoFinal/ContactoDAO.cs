using System;
using System.Collections.Generic;
using Conexionbd;
using Microsoft.Data.SqlClient;


public class ContactoDAO
{
    public ContactoDAO()
    {
        ConexionDB.ObtenerConexion();
    }

    public bool AgregarContacto(Contacto c)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            string query = "INSERT INTO Contacto ( Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)";
            SqlCommand comando = new SqlCommand(query,conexion);
            comando.Parameters.AddWithValue("@Nombre", c.Nombre);
            comando.Parameters.AddWithValue("@Email", c.Email);
            comando.Parameters.AddWithValue("@Telefono", c.Telefono);

            return comando.ExecuteNonQuery() > 0;
         
        }
    }

    public bool ModificarContacto(Contacto c)
    {
        using (SqlConnection conexion = ConexionDB.ObtenerConexion())
        {
            string query = "UPDATE Contacto SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono WHERE ID_CONTACTO = @Id";
            SqlCommand comando = new SqlCommand(query,conexion);
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
            string query = "DELETE FROM Contacto WHERE Id = @Id";
            SqlCommand comando = new SqlCommand(query,conexion);
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
                    lector["Nombre"].ToString()!,
                    lector["Email"].ToString()!,
                    lector["Telefono"].ToString()!
                ));
            }
        }
        return lista;
    }
}
