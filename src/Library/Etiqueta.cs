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
    public void AgregarEtiqueta(Cliente cliente)
    {
        cliente.ObtenerEtiquetas().Add(this);
    }
    
    // Elimina una etiqueta de un cliente si ya la tiene
    public void BorrarEtiqueta(Cliente cliente, Etiqueta etiqueta)
    {
        if (cliente.ObtenerEtiquetas().Contains(etiqueta))
        {
            cliente.ObtenerEtiquetas().Remove(etiqueta);
        }
    }
}