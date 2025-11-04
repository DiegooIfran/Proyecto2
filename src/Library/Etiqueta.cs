namespace Library;

// Representa una etiqueta que puede asociarse a un cliente
public class Etiqueta
{
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }
    
    //Crea una nueva etiqueta con su nombre y descripción
    public Etiqueta(string nombre, string descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }
    
    //Asocia una etiqueta a un cliente
    public static void AgregarEtiqueta(Cliente cliente, Etiqueta etiqueta)
    {
        cliente.ObtenerEtiquetas().Add(etiqueta);
    }
    
    // Elimina una etiqueta de un cliente si ya la tiene
    public static void BorrarEtiqueta(Cliente cliente, Etiqueta etiqueta)
    {
        if (cliente.ObtenerEtiquetas().Contains(etiqueta))
        {
            cliente.ObtenerEtiquetas().Remove(etiqueta);
        }
    }
}