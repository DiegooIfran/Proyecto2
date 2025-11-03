namespace Library;

public class Fachada
{
    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero, string fechaNacimiento)
    {
    }

    public void ModificarCliente(Cliente cliente)
    {
        int aux = new int();
        Console.WriteLine($"Ingrese la modificacion que le desea realizar a {cliente.ObtenerNombre()}:");
        Console.WriteLine($"1 - Si quiere modificar el nombre");
        Console.WriteLine($"2 - Si quiere modificar el apellido");
        Console.WriteLine($"3 - Si quiere modificar el telefono");
        Console.WriteLine($"4 - Si quiere modificar el email");
        Console.WriteLine($"5 - Si no quiere modificar");
        aux = Console.Read();
        switch (aux)
        {
            case (1): //Modifica nombre
            {
                Console.WriteLine($"Nombre del cliente es {cliente.ObtenerNombre()}, ingrese un nuevo nombre:");
                string nom = Console.ReadLine();
                ModificadorCliente.ModificarNombre(nom, cliente);
                break;
            }
            case (2): //Modifica apellido
            {
                Console.WriteLine($"Apellido del cliente es {cliente.ObtenerNombre()}, ingrese un nuevo apellido:");
                string ap = Console.ReadLine();
                ModificadorCliente.ModificarNombre(ap, cliente);
                break;
            }
            case (3): //Modifica telefono
            {
                Console.WriteLine($"Telefono del cliente es {cliente.ObtenerNombre()}, ingrese un nuevo telefono:");
                string tel = Console.ReadLine();
                ModificadorCliente.ModificarTelefono(tel, cliente);
                break;
            }
            case (4): //Modifica email
            {
                Console.WriteLine($"Email del cliente es {cliente.ObtenerEmail()}, ingrese un nuevo email:");
                string mail = Console.ReadLine();
                ModificadorCliente.ModificarEmail(mail, cliente);
                break;
            }
            case (5): //No quiere hacer cambios
            {
                break;
            }
            default:
            {
                break;
            }
        }
    }
}