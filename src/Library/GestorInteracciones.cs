namespace Library;
/// <summary>
/// Clase estática que gestiona todas las interacciones entre el sistema y los clientes.
/// Permite crear nuevas interacciones (mensajes, llamadas, correos y reuniones),
/// registrar las existentes y obtener información sobre ellas.
/// </summary>
public static class GestorInteracciones
{
    private static List<Interaccion> _todasInteracciones = new List<Interaccion>(); 
    public static void NuevoMensaje(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Mensaje mensaje = new Mensaje(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(mensaje);
        _todasInteracciones.Add(mensaje);
    }
    public static void NuevaLlamada(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Llamadas llamada = new Llamadas(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(llamada);
        _todasInteracciones.Add(llamada);
    }
    public static void NuevoCorreo(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) 
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Correo correo = new Correo(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(correo);
        _todasInteracciones.Add(correo);
    }
    public static void NuevaReunion(Cliente cliente, DateTime fecha, string tema, string notas)
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
    public static List<Interaccion> UltimasInteracciones() 
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
    public static void VerInteracciones(Cliente cliente)
    {
        if (cliente == null) 
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        foreach (Interaccion interaccion in cliente.ObtenerInteracciones())
        {
            Console.WriteLine($"{interaccion}");
        }
    }

    /// <summary>
    /// Devuelve una lista de interacciones en línea (mensajes, correos, llamadas)
    /// que fueron enviadas pero aún no respondidas.
    /// </summary>
    /// <returns>Lista de interacciones pendientes de respuesta</returns>
    public static List<Online> InteraccionesPendientes() 
    {
        return _todasInteracciones
            .OfType<Online>() 
            .Where(ic => ic.ObtenerEnviada() && !ic.ObtenerRespondido()) 
            .ToList();
    }
}