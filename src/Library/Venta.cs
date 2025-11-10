namespace Library;
/// <summary>
/// Representa una venta registrada como una interacción con el cliente
/// </summary>
public class Venta : Interaccion
{
    public int Precio { get; private set; }

    /// <summary>
    /// Constructor que inicializa una venta con su fecha, tema, notas y precio
    /// </summary>
    /// <param name="fecha"></param>
    /// <param name="tema"></param>
    /// <param name="notas"></param>
    /// <param name="precio"></param>
    /// <exception cref="ArgumentNullException"></exception>Si alguno de los parámetros es nulo
    /// <exception cref="ArgumentException"></exception>Si el precio es negativo.
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