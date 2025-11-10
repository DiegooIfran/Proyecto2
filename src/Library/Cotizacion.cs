namespace Library;
// Representa una cotización ofrecida a un cliente.
// Hereda de Interaccion porque también forma parte del historial de contacto
public class Cotizacion : Interaccion
{
    public int Precio { get; private set; }
    public string Estado { get; private set; }
    public Cliente Cliente { get; private set; }

    // Constructor que inicializa una cotización con sus datos principales
    public Cotizacion(DateTime fecha, string tema, string notas, Cliente cliente, int precio)
        : base(fecha, tema, notas)
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        if (precio == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(precio));
        }

        if (precio < 0) //Valida que el precio no sea negativo
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }
        Cliente = cliente;
        Precio = precio;
        Estado = "Abierta";
    }
    
    // Cierra la cotización y genera automáticamente una nueva venta 
    // asociada al cliente
    public void CerrarVenta()
    {
        Estado = "Cerrada";
        
        Venta nuevaVenta = new Venta(DateTime.Now, "Venta cerrada", "Conversión desde cotización", Precio);
        Cliente.AgregarInteraccion(nuevaVenta);
        
        
    }
}