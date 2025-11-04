namespace Library;

public class GestorAdministrador
{
    private static List<Administrador> _totalAdministrador = new List<Administrador>(); // Hago una lista estatica la cual contendra todos los Administradores
    
    public static void AgregarAdministrador(Administrador administrador)
    {
        _totalAdministrador.Add(administrador);
    }

    public static List<Administrador> VerTotalAdministradores()
    {
        return _totalAdministrador;
    }

    public static void EliminarAdministrador(Administrador administrador)
    {
        _totalAdministrador.Remove(administrador);
    }
}