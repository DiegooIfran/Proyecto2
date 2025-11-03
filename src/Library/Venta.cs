namespace Library;

public class Venta
{
    public string Producto { get; set; }
    public int Precio { get; set; }
    public DateTime Fecha { get; set; }

    public Venta(string producto, int precio)
    {
        Producto = producto;
        Precio = precio;
        Fecha = DateTime.Today;
    }
}