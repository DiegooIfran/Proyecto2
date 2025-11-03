namespace Library;

public class Cotizacion
{
    public string Producto { get; set; }
    public int Precio { get; set; }
    public DateTime Fecha { get; set; }
    public string Estado { get; set; }
    public Cliente Cliente { get; set; }

    public Cotizacion(Cliente cliente, int precio, string producto)
    {
        Cliente = cliente;
        Precio = precio;
        Producto = producto;
        Fecha = DateTime.Today;
        Estado = "Abierta";
    }

    public void CerrarVenta()
    {
        Estado = "Cerrada";
        Venta nuevaVenta = new Venta(this.Producto, this.Precio);
        this.Cliente.AgregarVenta(nuevaVenta); 
    }
}