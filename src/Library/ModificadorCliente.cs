namespace Library;

public static class ModificadorCliente
{
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
}