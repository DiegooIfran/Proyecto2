namespace Library;
/// <summary>
/// Clase que gestiona las operaciones relacionadas con los clientes del sistema.
/// Hereda de Gestor<Cliente> y agrega funcionalidades específicas
/// como creación, búsqueda, modificación y asignación de clientes a vendedores
/// </summary>
public class GestorCliente : Gestor<Cliente>
{
    /// <summary>
    /// Lista que contiene todos los clientes registrados en el sistema
    /// </summary>
    public List<Cliente> TotalClientes { get; set; } 

    /// <summary>
    /// Constructor del gestor de clientes.
    /// Inicializa la lista de clientes vacía.
    /// </summary>
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

    /// <summary>
    /// Elimina un cliente de la lista utilizando su dirección de email como identificador
    /// </summary>
    /// <param name="email">Correo electrónico del cliente a eliminar.</param>
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
        if (vendedor == null) //Valida que el vendedor no sea nulo
        {throw new ArgumentNullException(nameof(vendedor));} 
        if (cliente == null) //Valida que el cliente no sea nulo
        {throw new ArgumentNullException(nameof(cliente));}
        vendedor.AgregarCliente(cliente);
        
    }

    public void ModificarNombre(string nombre, Cliente cliente) //Modifico el nombre de un cliente
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.CambiarNombre(nombre);
    }

    public void ModificarApellido(string apellido, Cliente cliente) //Modifico el apellido de un cliente
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.CambiarApellido(apellido);
    }

    public void ModificarTelefono(string telefono, Cliente cliente) //Modifico el telefono de un cliente
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.CambiarTelefono(telefono);
    }

    public void ModificarEmail(string email, Cliente cliente) //Modifico el email de un cliente
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
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

