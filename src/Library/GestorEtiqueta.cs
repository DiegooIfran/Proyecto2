namespace Library;

public static class GestorEtiquetas
{
    public static Etiqueta CrearEtiqueta(string nombre, string descripcion)
    {
        return new Etiqueta(nombre, descripcion);
    }

    public static void AgregarEtiqueta(Cliente cliente, Etiqueta etiqueta)
    {
        cliente.ObtenerEtiquetas().Add(etiqueta);
    }
    
    public static void BorrarEtiqueta(Cliente cliente, Etiqueta etiqueta)
    {
        if (cliente.ObtenerEtiquetas().Contains(etiqueta))
        {cliente.ObtenerEtiquetas().Remove(etiqueta);}
    }
}