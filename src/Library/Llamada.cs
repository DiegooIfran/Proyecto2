namespace Library;
/// <summary>
/// Representa una interacción de tipo llamada telefónica dentro del sistema.
/// Hereda de <see cref="Online"/> ya que se trata de una comunicación que puede ser realizada o recibida de manera remota
/// </summary>
public class Llamada: Online
{
    public Llamada(DateTime fecha, string tema, string notas, bool enviada) : base(fecha, tema, notas, enviada) { }
}