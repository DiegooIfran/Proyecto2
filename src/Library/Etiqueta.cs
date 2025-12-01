using System.Text.RegularExpressions;

namespace Library;
/// <summary>
/// Representa una etiqueta que puede asociarse a un cliente
/// Aplica el principio SRP: su responsabilidad es contener la informacion de la etiqueta
/// </summary>
public class Etiqueta : ISingleton
{
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }
    
    /// <summary>
    /// Crea una nueva etiqueta con su nombre y descripción
    /// </summary>
    /// <param name="nombre"></param>
    /// <param name="descripcion"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Etiqueta(string nombre, string descripcion)
    {
        if (nombre == null) //Valida que el nombre no sea nulo
        {
            throw new ArgumentNullException(nombre);
        }
        if (descripcion == null) //Valida que la descripción no sea nula
        {
            throw new ArgumentNullException(descripcion);
        }
        Nombre = nombre;
        Descripcion = descripcion;
    }
}