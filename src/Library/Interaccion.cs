namespace Library;
// Clase abstracta base que representa una interacción con el cliente.
// Sirve como clase padre para distintos tipos de interacciones, 
// como ventas o cotizaciones
public abstract class Interaccion
{
    public DateTime Fecha { get; private set; }
    protected string Tema { get; set; }
    protected string Notas { get; set; }
    
    // Constructor protegido para inicializar los datos comunes de toda interacción
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
    
    // Devuelve las notas registradas en la interacción
    public string ObtenerNota()
    {
        return this.Notas;
    }
    
    // Devuelve la fecha de la interacción
    public DateTime ObtenerFecha()
    {
        return this.Fecha;
    }
    
    // Permite modificar la fecha de la interacción
    public void PonerFecha(DateTime fecha)
    {
        this.Fecha = fecha;
    }

    
    // Devuelve el tema de la interacción
    public string ObtenerTema()
    {
        return this.Tema; 
    }
}
