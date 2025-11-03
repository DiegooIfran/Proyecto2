namespace Library;

public class Mensaje: Online
{
    public Mensaje(DateTime fecha, string tema, string notas, bool enviada) : base(fecha, tema, notas, enviada) { }
}