namespace Library;

public static class Panel
{
    public static void ImprimirPanel(Vendedor vendedor)
    {
        string panel = $"Panel del vendedor: {vendedor.ObtenerNombre()}\n";
        
        // total de clientes
        var clientes = vendedor.ObtenerClientes();
        panel+=$"Clientes totales: {clientes.Count}";

        //interacciones recientes de todos los clientes
        List<Interaccion> todasLasInteracciones = new();
        foreach (var cliente in clientes)
        {
            if (cliente.ObtenerInteracciones() != null)
            {
                todasLasInteracciones.AddRange(cliente.ObtenerInteracciones());
            }
        }

        if (todasLasInteracciones.Count == 0)
        {
            panel+="No hay interacciones registradas\n";
        }
        else
        {
            // Ordeno por fecha descendente
            todasLasInteracciones.Sort((a, b) => b.ObtenerFecha().CompareTo(a.ObtenerFecha()));

            panel+="Interacciones recientes:\n";
            int mostradas = 0;
            foreach (var interaccion in todasLasInteracciones)
            {
                panel+=$" {interaccion.GetType().Name}: {interaccion.ObtenerTema()} {interaccion.ObtenerFecha().ToShortDateString()}\n";
                mostradas++;
                if (mostradas == 5) break; // mostrar solo 5 más recientes
            }
        }
        

        // reuniones próximas (usando BuscadorInteracciones)
        panel+="\nPróximas reuniones:\n";

        bool hayReuniones = false;

        foreach (var cliente in clientes)
        {
            BuscadorInteracciones.VerReunion(cliente);
            hayReuniones = true;
        }

        if (!hayReuniones)
        {
            panel+="No hay reuniones próximas.";
        }

    }
}
