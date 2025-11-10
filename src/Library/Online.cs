namespace Library;
/// <summary>
/// Clase abstracta que representa una interacción digital entre el sistema y un cliente.
/// Hereda de Interaccion y agrega información sobre si la interacción fue enviada y/o respondida
/// </summary>
public class Online: Interaccion
{
    /// <summary>
    /// Indica si la interacción fue enviada 
    /// </summary>
    private bool Enviada { get; set;}
    
    /// <summary>
    /// Indica si la interacción recibió una respuesta
    /// </summary>
    private bool Respondidas { get; set; }
    
    /// <summary>
    /// Constructor protegido utilizado por las subclases (<see cref="Correo"/>, <see cref="Mensaje"/>, <see cref="Llamadas"/>).
    /// </summary>
    /// <param name="fecha">Fecha en la que se realizó la interacción</param>
    /// <param name="tema">Tema o asunto de la interacción</param>
    /// <param name="notas">Contenido o información adicional</param>
    /// <param name="enviada">Indica si fue enviada (<c>true</c>) o no (<c>false</c>).</param>
    protected Online(DateTime fecha, string tema, string notas, bool enviada)
        : base(fecha, tema, notas)
    {
        Enviada = enviada;
        Respondidas = false;
    }

    /// <summary>
    /// Marca la interacción como respondida
    /// </summary>
    public void Respondida()
    {
        this.Respondidas = true;
    }

    /// <summary>
    /// Indica si la interacción fue enviada
    /// </summary>
    public bool ObtenerEnviada()
    {
        return this.Enviada;
    }
    
    /// <summary>
    /// Indica si la interacción ha sido respondida
    /// </summary>
    public bool ObtenerRespondido()
    {
        return this.Respondidas;
    }
}