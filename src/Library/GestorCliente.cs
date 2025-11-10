namespace Library;

public class GestorCliente : Gestor<Cliente>
{

    public GestorCliente() //Constructor del gestor
    {
    }

    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero,
        DateTime fechaNacimiento) //Creo un cliente
    {
        Cliente cliente = new Cliente(name, apellido, telefono, email, genero, fechaNacimiento);
        this.Agregar(cliente); 
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

    public Cliente BuscarPorNombre(string nombre) //Busco un cliente por nombre
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

    public Cliente BuscarPorApellido(string apellido) //Busco un cliente por apellido
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

    public Cliente BuscarPorTelefono(string telefono) //Busco un cliente por telefono
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

    public Cliente BuscarPorEmail(string email) //Busco un cliente por email
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

//Esta clase implementa lo mismo que gestor pero unicamente cuando T es cliente, a su vez se encarga de hacer las busquedas y modificaciones pertinentes ya que es la experta.