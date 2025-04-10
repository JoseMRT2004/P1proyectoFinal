public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Contacto(int id, string nombre, string email, string telefono)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Email = email;
        this.Telefono = telefono;
    }
}