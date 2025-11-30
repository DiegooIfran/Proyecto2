namespace Library;
/// <summary>
/// Clase que gestiona todas las interacciones entre el sistema y los clientes.
/// Permite crear nuevas interacciones (mensajes, llamadas, correos y reuniones),
/// registrar las existentes y obtener información sobre ellas.
/// Patrón Creator: es responsable de crear objetos de tipo Interaccion
/// Aplica el principio OCP ya que se puede extender sin modificar lo ya hecho
/// SRP: se encarga de gestionar las interacciones
/// </summary>
public class GestorInteracciones : ISingleton
{
    private  List<Interaccion> _todasInteracciones = new List<Interaccion>(); 
    public void NuevoMensaje(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Mensaje mensaje = new Mensaje(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(mensaje);
        _todasInteracciones.Add(mensaje);
    }
    public void NuevaLlamada(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Llamada llamada = new Llamada(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(llamada);
        _todasInteracciones.Add(llamada);
    }
    public void NuevoCorreo(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Correo correo = new Correo(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(correo);
        _todasInteracciones.Add(correo);
    }
    public void NuevaReunion(Cliente cliente, DateTime fecha, string tema, string notas)
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Reunion reunion = new Reunion(fecha, tema, notas);
        cliente.AgregarInteraccion(reunion);
        _todasInteracciones.Add(reunion);
    }
    /// <summary>
    /// Devuelve las cinco interacciones más recientes registradas en el sistema
    /// </summary>
    public List<Interaccion> UltimasInteracciones() 
    {
        return _todasInteracciones
            .OrderByDescending(i => i.Fecha) 
            .Take(5) 
            .ToList();
    }
    
    /// <summary>
    /// Muestra todas las interacciones de un cliente específico
    /// </summary>
    /// <param name="cliente">Cliente cuyas interacciones se desean ver</param>
    /// <exception cref="ArgumentNullException">Si el cliente es nulo</exception>
    public List<string> VerInteracciones(Cliente cliente)
    {
        if (cliente == null)
            throw new ArgumentNullException(nameof(cliente));

        return cliente.ObtenerInteracciones()
            .Select(i => i.ToString())
            .ToList()!;
    }

    /// <summary>
    /// Devuelve una lista de interacciones en línea (mensajes, correos, llamadas)
    /// que fueron enviadas pero aún no respondidas.
    /// </summary>
    /// <returns>Lista de interacciones pendientes de respuesta</returns>
    public List<Online> InteraccionesPendientes() 
    {
        return _todasInteracciones
            .OfType<Online>() 
            .Where(ic => ic.ObtenerEnviada() && !ic.ObtenerRespondido()) 
            .ToList();
    }
}