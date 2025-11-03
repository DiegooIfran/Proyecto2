namespace Library;

public static class GestorInteracciones
{
    private static List<Interaccion> _todasInteracciones = new List<Interaccion>();
    public static void NuevoMensaje(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada)
    {
        Mensaje mensaje = new Mensaje(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(mensaje);
        _todasInteracciones.Add(mensaje);
    }
    public static void NuevaLlamada(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada)
    {
        Llamadas llamada = new Llamadas(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(llamada);
        _todasInteracciones.Add(llamada);
    }
    public static void NuevoCorreo(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada)
    {
        Correo correo = new Correo(fecha, tema, notas, enviada);
        cliente.AgregarInteraccion(correo);
        _todasInteracciones.Add(correo);
    }
    public static void NuevaReunion(Cliente cliente, DateTime fecha, string tema, string notas)
    {
        Reunion reunion = new Reunion(fecha, tema, notas);
        cliente.AgregarInteraccion(reunion);
        _todasInteracciones.Add(reunion);
    }

    public static List<Interaccion> UltimasInteracciones()
    {
        return _todasInteracciones
            .OrderByDescending(i => i.Fecha)
            .Take(5)
            .ToList();
    }

    public static void VerInteracciones(Cliente cliente)
    {
        foreach (Interaccion interaccion in cliente.ObtenerInteracciones())
        {
            Console.WriteLine($"{interaccion}");
        }
    }

    public static List<Online> InteraccionesPendientes()
    {
        return _todasInteracciones
            .OfType<Online>() // Solo queremos las de tipo Mensaje, Correo, Llamada
            .Where(ic => ic.ObtenerEnviada() && !ic.ObtenerRespondido()) // Filtra las enviadas pero no respondidas
            .ToList();
    }
}