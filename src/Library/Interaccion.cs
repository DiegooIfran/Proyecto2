using System.Runtime.InteropServices.JavaScript;

namespace Library;

public abstract class Interaccion
{
    public DateTime Fecha { get; set; }
    private string Tema { get; set; }
    private string Notas { get; set; }
    
    protected Interaccion(DateTime fecha, string tema, string notas)
    {
        Fecha = fecha;
        Tema = tema;
        Notas = notas;
    }

    public string ObtenerNota()
    {
        return this.Notas;
    }
    public DateTime ObtenerFecha()
    {
        return this.Fecha;
    }
    
    public void PonerFecha(DateTime fecha)
    {
        this.Fecha = fecha;
    }

    public string ObtenerTema()
    {
        return this.Tema; 
    }
}
