public class Contacto
{
    public int id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Contacto(string nombre, string email, string telefono)
    {
        this.Nombre = nombre;
        this.Email = email;
        this.Telefono = telefono;
    }
    public Contacto(int id,string nombre, string email, string telefono)
    {
        this.id = id;
        this.Nombre = nombre;
        this.Email = email;
        this.Telefono = telefono;
    }
}