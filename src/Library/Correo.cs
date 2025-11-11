namespace Library;
/// <summary>
/// Representa una interacción de tipo correo electrónico dentro del sistema.
/// Hereda de <see cref="Online"/>, ya que se trata de una comunicación realizada por medios digitales
/// </summary>
public class Correo: Online
{
    public Correo(DateTime fecha, string tema, string notas, bool enviada) : base(fecha, tema, notas, enviada) { }
}