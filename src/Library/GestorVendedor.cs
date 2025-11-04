namespace Library;

public class GestorVendedor
{
    private static List<Vendedor> _totalVendedores = new List<Vendedor>(); // Hago una lista estatica la cual contendra todos los Vendedores;
    
    public static void AgregarVendedor(Vendedor vendedor)
    {
        _totalVendedores.Add(vendedor);
    }

    public static List<Vendedor> VerTotalVendedores()
    {
        return _totalVendedores;
    }

    public static void EliminarVendedor(Vendedor vendedor)
    {
        _totalVendedores.Remove(vendedor);
    }
}