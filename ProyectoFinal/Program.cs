public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ContactoDAO contactos = new ContactoDAO();
        bool salir = true;
        string Nombre, Email, telefono;

        do
        {

            int opcion = Menu.MostrarMenu(); 

            switch (opcion)
            {
                case 1:
                    System.Console.WriteLine("Nombre: ");
                    Nombre = Console.ReadLine()!;
                    System.Console.WriteLine("Email: ");
                    Email = Console.ReadLine()!;
                    System.Console.WriteLine("Telefono: ");
                    telefono = Console.ReadLine()!;

                    Contacto contacto = new Contacto(Nombre, Email, telefono);
                    System.Console.WriteLine(contactos.AgregarContacto(contacto) ? "Usuario agregado correctamente" : "No se pudo agregar intente de nuevo");
                    break;
                case 2:
                    System.Console.WriteLine("Nombre: ");
                    Nombre = Console.ReadLine()!;
                    System.Console.WriteLine("Email: ");
                    Email = Console.ReadLine()!;
                    System.Console.WriteLine("Telefono: ");
                    telefono = Console.ReadLine()!;
                    Contacto contactoModificado = new Contacto(Nombre, Email, telefono);

                    contactos.ModificarContacto(contactoModificado);
                    break;
                case 3:
                    System.Console.WriteLine("Elimine el Usuario con el ID: ");
                    int EliminarContacto = int.Parse(Console.ReadLine()!);
                    contactos.EliminarContacto(EliminarContacto);
                    break;
                case 4:
                    foreach (var c in contactos.ListarContactos())
                    {
                        Console.WriteLine($"Nombre: {c.Nombre} | Email: {c.Email} | Teléfono: {c.Telefono}");
                    }
                    
                    Console.ReadKey();
                    break;
                case 5:
                    salir = false;
                    break;
                default:
                    break;
            }
            Console.Clear();

        }
        while (salir);

        Console.WriteLine("¡Gracias por usar la Agenda de Contactos!");
    }
}