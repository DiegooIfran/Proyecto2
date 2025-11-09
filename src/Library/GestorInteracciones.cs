namespace Library;

public static class GestorInteracciones
{
    private static List<Interaccion> _todasInteracciones = new List<Interaccion>(); //Creo una lista para ver todas las interacciones
    public static void NuevoMensaje(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) //Creo un nuevo mensaje
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Mensaje mensaje = new Mensaje(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(mensaje);
        _todasInteracciones.Add(mensaje);
    }
    public static void NuevaLlamada(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) //Creo una nueva llamada
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Llamadas llamada = new Llamadas(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(llamada);
        _todasInteracciones.Add(llamada);
    }
    public static void NuevoCorreo(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada) //Creo un nuevo correo
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Correo correo = new Correo(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(correo);
        _todasInteracciones.Add(correo);
    }
    public static void NuevaReunion(Cliente cliente, DateTime fecha, string tema, string notas) //Creo una nueva reunion
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        Reunion reunion = new Reunion(fecha, tema, notas);
        cliente.AgregarInteraccion(reunion);
        _todasInteracciones.Add(reunion);
    }

    public static List<Interaccion> UltimasInteracciones() //Devuelvo una lista de las ultimas interacciones
    {
        return _todasInteracciones
            .OrderByDescending(i => i.Fecha) //Ordena por fecha
            .Take(5) //Toma 5
            .ToList();
    }

    public static void VerInteracciones(Cliente cliente) //Imprimo todas las interacciones
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        foreach (Interaccion interaccion in cliente.ObtenerInteracciones())
        {
            Console.WriteLine($"{interaccion}");
        }
    }

    public static List<Online> InteraccionesPendientes() //Devuelvo una lista de interacciones pendientes
    {
        return _todasInteracciones
            .OfType<Online>() // Solo queremos las de tipo Mensaje, Correo, Llamada
            .Where(ic => ic.ObtenerEnviada() && !ic.ObtenerRespondido()) // Filtra las enviadas pero no respondidas
            .ToList();
    }
}