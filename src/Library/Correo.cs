namespace Library;

public class Correo: Online
{
    public Correo(DateTime fecha, string tema, string notas, bool enviada) : base(fecha, tema, notas, enviada) { }
}