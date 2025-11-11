namespace Library;
/// <summary>
/// Clase que gestiona las operaciones relacionadas con los clientes del sistema.
/// Hereda de <see cref="Gestor{Cliente}"/> y agrega funcionalidades específicas
/// como creación, búsqueda, modificación y asignación de clientes a vendedores.
/// </summary>
public class GestorCliente : Gestor<Cliente>
{

    public GestorCliente() 
    {
    }

    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero,
        DateTime fechaNacimiento) 
    {
        Cliente cliente = new Cliente(name, apellido, telefono, email, genero, fechaNacimiento);
        this.Agregar(cliente); 
    }
    
    public void AsignarCliente(Vendedor vendedor, Cliente cliente) 
    {
        if (vendedor == null) 
        {throw new ArgumentNullException(nameof(vendedor));} 
        if (cliente == null) 
        {throw new ArgumentNullException(nameof(cliente));}
        vendedor.AgregarCliente(cliente);
        
    }

    public void ModificarNombre(string nombre, Cliente cliente) 
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.CambiarNombre(nombre);
    }

    public void ModificarApellido(string apellido, Cliente cliente) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.CambiarApellido(apellido);
    }

    public void ModificarTelefono(string telefono, Cliente cliente) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.CambiarTelefono(telefono);
    }

    public void ModificarEmail(string email, Cliente cliente) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.CambiarEmail(email);
    }

    public Cliente BuscarPorNombre(string nombre) 
    {
        foreach (Cliente cliente in this.VerTotal())
        {
            if (nombre == cliente.ObtenerNombre())
            {
                return cliente;
            }
        }
        throw new InvalidOperationException("No se encontró ningún cliente con ese nombre.");
    }

    public Cliente BuscarPorApellido(string apellido) 
    {
        foreach (Cliente cliente in this.VerTotal())
        {
            if (apellido == cliente.ObtenerApellido())
            {
                return cliente;
            }
        }
        throw new InvalidOperationException("No se encontró ningún cliente con ese apellido.");
    }

    public Cliente BuscarPorTelefono(string telefono) 
    {
        foreach (Cliente cliente in this.VerTotal())
        {
            if (telefono == cliente.ObtenerTelefono())
            {
                return cliente;
            }
        }
        throw new InvalidOperationException("No se encontró ningún cliente con ese telefono.");
    }

    public Cliente BuscarPorEmail(string email) 
    {
        foreach (Cliente cliente in this.VerTotal())
        {
            if (email == cliente.ObtenerEmail())
            {
                return cliente;
            }
        }
        throw new InvalidOperationException("No se encontró ningún cliente con ese email.");
    }
}