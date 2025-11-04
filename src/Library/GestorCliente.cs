namespace Library;

public class GestorCliente
{
    public List<Cliente> TotalClientes { get; set; }

    public GestorCliente()
    {
        this.TotalClientes = new List<Cliente>();
    }

    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero,
        DateTime fechaNacimiento)
    {
        Cliente cliente = new Cliente(name, apellido, telefono, email, genero, fechaNacimiento);
        this.TotalClientes.Add(cliente);
    }

    public void EliminarCliente(string email)
    {
        foreach (Cliente cliente in this.TotalClientes.ToList())
        {
            if (cliente.ObtenerEmail() == email)
            {
                this.TotalClientes.Remove(cliente);
            }
        }
    }

    public List<Cliente> VerTotalClientes()
    {
        return this.TotalClientes;
    }

    public void AsignarCliente(Vendedor vendedor, Cliente cliente)
    {
        vendedor.AgregarCliente(cliente);
    }

    public static void ModificarNombre(string nombre, Cliente cliente)
    {
        cliente.CambiarNombre(nombre);
    }

    public static void ModificarApellido(string apellido, Cliente cliente)
    {
        cliente.CambiarApellido(apellido);
    }

    public static void ModificarTelefono(string telefono, Cliente cliente)
    {
        cliente.CambiarTelefono(telefono);
    }

    public static void ModificarEmail(string email, Cliente cliente)
    {
        cliente.CambiarEmail(email);
    }

    public static Cliente BuscarPorNombre(string nombre, List<Cliente> clientes)
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

    public static Cliente BuscarPorApellido(string apellido, List<Cliente> clientes)
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

    public static Cliente BuscarPorTelefono(string telefono, List<Cliente> clientes)
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

    public static Cliente BuscarPorEmail(string email, List<Cliente> clientes)
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