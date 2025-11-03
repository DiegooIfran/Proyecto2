namespace Library;

public class GestorCliente
{
    public List<Cliente> TotalClientes { get; set; }

    public GestorCliente()
    {
        this.TotalClientes = new List<Cliente>();
    }

    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero, DateTime fechaNacimiento)
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
}