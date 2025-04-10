public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; //  ! Configura la terminal para soportar caracteres especiales

        bool salir = false;
        while (!salir)
        {
            int opcion = Menu.MostrarMenu(); // Captura la opción seleccionada


            /*
        Flujo del programa:
        1. Se muestra el menú y el usuario selecciona una opción.
        2. Dependiendo de la opción seleccionada, se ejecuta la lógica correspondiente:
            - Opción 1: Agregar contacto
            - Opción 2: Modificar contacto
            - Opción 3: Eliminar contacto
            - Opción 4: Mostrar contactos
            - Opción 5: Termina el programa
        3. Si se selecciona la opción de salir, el programa termina y muestra un mensaje de despedida.
        */

            switch (opcion)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    salir = true;
                    break;
                default:
                    break;
            }
            Console.Clear();
        }

        Console.WriteLine("¡Gracias por usar la Agenda de Contactos!");
    }
}