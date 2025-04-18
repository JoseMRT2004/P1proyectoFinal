public class Contacto
{
    public int id { get; private set; }
    public string Nombre { get; private set; }
    public string Email { get; private set; }
    public string Telefono { get; private set; }
    public Contacto(string nombre, string email, string telefono)
    {
        this.Nombre = nombre;
        this.Email = email;
        this.Telefono = telefono;
    }
    public Contacto(int id, string nombre, string email, string telefono)
    {
        this.id = id;
        this.Nombre = nombre;
        this.Email = email;
        this.Telefono = telefono;
    }
}