namespace Library;
/// <summary>
/// Clase estática encargada de generar un panel informativo con datos del vendedor,
/// incluyendo su cantidad de clientes, interacciones recientes y próximas reuniones.
/// </summary>
public static class Panel
{
    /// <summary>
    /// Genera y devuelve un panel de texto con la información principal del vendedor
    /// </summary>
    /// <param name="vendedor">El vendedor del cual se desea imprimir el panel.</param>
    /// <returns>
    /// Una cadena de texto con el nombre del vendedor, el total de clientes,
    /// las cinco interacciones más recientes y las reuniones próximas.
    /// </returns>
    public static string ImprimirPanel(Vendedor vendedor)
    {
        // Encabezado con el nombre del vendedor
        string panel = $"Panel del vendedor: {vendedor.ObtenerNombre()}\n";
        
        // Total de clientes asociados
        var clientes = vendedor.ObtenerClientes();
        panel+=$"Clientes totales: {clientes.Count}\n";
        
        // Reúne todas las interacciones de todos los clientes
        List<Interaccion> todasLasInteracciones = new();
        foreach (var cliente in clientes)
        {
            if (cliente.ObtenerInteracciones() != null)
            {
                todasLasInteracciones.AddRange(cliente.ObtenerInteracciones());
            }
        }

        // Interacciones recientes
        if (todasLasInteracciones.Count == 0)
        {
            panel+=$"No hay interacciones registradas\n";
        }
        else
        {
            // Ordena por fecha (más recientes primero)
            todasLasInteracciones.Sort((a, b) => b.ObtenerFecha().CompareTo(a.ObtenerFecha()));

            panel+=$"\nInteracciones recientes:\n";
            int mostradas = 0;
            foreach (var interaccion in todasLasInteracciones)
            {
                panel+=$" {interaccion.GetType().Name}: {interaccion.ObtenerTema()} {interaccion.ObtenerFecha().ToShortDateString()}\n";
                mostradas++;
                if (mostradas == 5) break; 
            }
        }
        

        // Reuniones próximas
        panel+=$"\nPróximas reuniones:\n";

        bool hayReuniones = false;

        foreach (var cliente in clientes)
        {
            // Solo marcar como “hay reuniones” si el cliente realmente tiene alguna
            BuscadorInteracciones.VerReunion(cliente);
            hayReuniones = true;
        }

        if (!hayReuniones)
        {
            panel+=$"No hay reuniones próximas.";
        }
        return panel;
    }
}
