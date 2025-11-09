namespace Library;
// Representa una venta registrada como una interacción con el cliente
public class Venta : Interaccion
{
    public int Precio { get; private set; }

    // Constructor que inicializa una venta con su fecha, tema, notas y precio
    public Venta(DateTime fecha, string tema, string notas, int precio)
        : base(fecha, tema, notas)
    {
        if (precio == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(precio));
        }
        if (precio < 0) //Valida que el precio no sea negativo
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }
        Precio = precio;
    }
}