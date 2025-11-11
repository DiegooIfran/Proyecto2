namespace Library;
/// <summary>
/// Representa una reunión presencial entre un cliente y un vendedor o representante del sistema.
/// Hereda de <see cref="Presencial"/>, ya que se trata de una interacción física.
/// </summary>
public class Reunion: Presencial
{
    public Reunion(DateTime fecha, string tema, string notas) : base(fecha, tema, notas) { }
}