namespace Library;
/// <summary>
/// Clase abstracta que representa una interacción digital entre el sistema y un cliente.
/// Hereda de <see cref="Interaccion"/> y agrega información sobre si la interacción fue enviada y/o respondida
/// </summary>
public class Online: Interaccion
{
    private bool Enviada { get; set;}
    private bool Respondidas { get; set; }
    
    /// <summary>
    /// Constructor protegido utilizado por las subclases (<see cref="Correo"/>, <see cref="Mensaje"/>, <see cref="Llamada"/>).
    /// </summary>
    /// <param name="fecha">Fecha en la que se realizó la interacción.</param>
    /// <param name="tema">Tema o asunto de la interacción.</param>
    /// <param name="notas">Contenido o información adicional.</param>
    /// <param name="enviada">Indica si fue enviada (<c>true</c>) o no (<c>false</c>).</param>
    protected Online(DateTime fecha, string tema, string notas, bool enviada)
        : base(fecha, tema, notas)
    {
        Enviada = enviada;
        Respondidas = false;
    }

    public void Respondida()
    {
        this.Respondidas = true;
    }

    public bool ObtenerEnviada()
    {
        return this.Enviada;
    }
    public bool ObtenerRespondido()
    {
        return this.Respondidas;
    }
}