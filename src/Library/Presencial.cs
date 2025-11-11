namespace Library;
/// <summary>
/// Representa una interacción presencial entre el sistema (o vendedor) y un cliente.
/// Hereda de <see cref="Interaccion"/> y sirve como clase base para interacciones como reuniones u otros encuentros físicos
/// </summary>
public class Presencial: Interaccion
{
    protected Presencial(DateTime fecha, string tema, string notas) : base(fecha, tema, notas) { }
}