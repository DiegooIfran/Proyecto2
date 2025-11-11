namespace Library;
/// <summary>
/// Representa una interacción de tipo mensaje dentro del sistema.
/// Hereda de <see cref="Online"/>, ya que es una comunicación enviada o recibida de forma digital
/// </summary>
public class Mensaje: Online
{
    public Mensaje(DateTime fecha, string tema, string notas, bool enviada) : base(fecha, tema, notas, enviada) { }
}