namespace Library;
/// <summary>
/// Clase abstracta base que representa una interacción con el cliente.
/// Sirve como clase padre para distintos tipos de interacciones, 
/// como ventas o cotizaciones
/// </summary>
public abstract class Interaccion
{
    public DateTime Fecha { get; private set; }
    protected string Tema { get; set; }
    protected string Notas { get; set; }
    
    /// <summary>
    /// Constructor protegido para inicializar los datos comunes de toda interacción
    /// </summary>
    /// <param name="fecha"></param>
    /// <param name="tema"></param>
    /// <param name="notas"></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected Interaccion(DateTime fecha, string tema, string notas)
    {
        if (fecha == null)
            throw new ArgumentNullException(nameof(fecha));
        if (tema == null)
            throw new ArgumentNullException(nameof(tema));
        if (notas == null)
            throw new ArgumentNullException(nameof(notas));
        Fecha = fecha;
        Tema = tema;
        Notas = notas;
        
    }
    
    /// <summary>
    /// Devuelve las notas registradas en la interacción
    /// </summary>
    /// <returns></returns>
    public string ObtenerNota()
    {
        return this.Notas;
    }
    
    /// <summary>
    /// Devuelve la fecha de la interacción
    /// </summary>
    /// <returns></returns>
    public DateTime ObtenerFecha()
    {
        return this.Fecha;
    }
    
    /// <summary>
    /// Permite modificar la fecha de la interacción
    /// </summary>
    /// <param name="fecha"></param>
    public void PonerFecha(DateTime fecha)
    {
        this.Fecha = fecha;
    }

    /// <summary>
    /// Devuelve el tema de la interacción
    /// </summary>
    /// <returns></returns>
    public string ObtenerTema()
    {
        return this.Tema; 
    }
}
