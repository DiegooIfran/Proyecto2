namespace Library;

public static class BuscadorCliente
{
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