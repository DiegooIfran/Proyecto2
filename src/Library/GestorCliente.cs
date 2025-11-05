namespace Library;

public class GestorCliente
{
    public List<Cliente> TotalClientes { get; set; } //Lista de todos los clientes

    public GestorCliente() //Constructor del gestor
    {
        this.TotalClientes = new List<Cliente>();
    }

    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero,
        DateTime fechaNacimiento) //Creo un cliente
    {
        Cliente cliente = new Cliente(name, apellido, telefono, email, genero, fechaNacimiento);
        this.TotalClientes.Add(cliente);
    }

    public void EliminarCliente(string email) //Elimino un cliente
    {
        foreach (Cliente cliente in this.TotalClientes.ToList())
        {
            if (cliente.ObtenerEmail() == email)
            {
                this.TotalClientes.Remove(cliente);
            }
        }
    }

    public List<Cliente> VerTotalClientes() //Devuelvo una lista con todos los clientes
    {
        return this.TotalClientes;
    }

    public void AsignarCliente(Vendedor vendedor, Cliente cliente) //Le asigno un cliente a otro vendedor
    {
        vendedor.AgregarCliente(cliente);
    }

    public void ModificarNombre(string nombre, Cliente cliente) //Modifico el nombre de un cliente
    {
        cliente.CambiarNombre(nombre);
    }

    public void ModificarApellido(string apellido, Cliente cliente) //Modifico el apellido de un cliente
    {
        cliente.CambiarApellido(apellido);
    }

    public void ModificarTelefono(string telefono, Cliente cliente) //Modifico el telefono de un cliente
    {
        cliente.CambiarTelefono(telefono);
    }

    public void ModificarEmail(string email, Cliente cliente) //Modifico el email de un cliente
    {
        cliente.CambiarEmail(email);
    }

    public Cliente BuscarPorNombre(string nombre, List<Cliente> clientes) //Busco un cliente por nombre
    {
        foreach (Cliente cliente in clientes)
        {
            if (nombre == cliente.ObtenerNombre())
                
            {
                return cliente;
            }
        }

        throw new InvalidOperationException("No se encontró ningún cliente con ese nombre.");
    }

    public Cliente BuscarPorApellido(string apellido, List<Cliente> clientes) //Busco un cliente por apellido
    {
        foreach (Cliente cliente in clientes)
        {
            if (apellido == cliente.ObtenerApellido())
            {
                return cliente;
            }
        }

        throw new InvalidOperationException("No se encontró ningún cliente con ese apellido.");
    }

    public Cliente BuscarPorTelefono(string telefono, List<Cliente> clientes) //Busco un cliente por telefono
    {
        foreach (Cliente cliente in clientes)
        {
            if (telefono == cliente.ObtenerTelefono())
            {
                return cliente;
            }
        }

        throw new InvalidOperationException("No se encontró ningún cliente con ese telefono.");
    }

    public Cliente BuscarPorEmail(string email, List<Cliente> clientes) //Busco un cliente por email
    {
        foreach (Cliente cliente in clientes)
        {
            if (email == cliente.ObtenerEmail())
            {
                return cliente;
            }
        }

        throw new InvalidOperationException("No se encontró ningún cliente con ese email.");
    }
}