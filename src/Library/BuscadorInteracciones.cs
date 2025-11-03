namespace Library
{
    public static class BuscadorInteracciones
    {
        public static void VerCorreo(Cliente cliente)
        {
            Console.WriteLine($"Correos del cliente {cliente.ObtenerNombre()}:");

            bool hayCorreos = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Correo correo)
                {
                    Console.WriteLine($"Tema: {correo.ObtenerTema()} | Fecha: {correo.ObtenerFecha().ToShortDateString()}");

                    if (!string.IsNullOrEmpty(correo.ObtenerNota()))
                        Console.WriteLine($"  Nota: {correo.ObtenerNota()}");

                    hayCorreos = true;
                }
            }

            if (!hayCorreos)
                Console.WriteLine("No hay correos registrados.\n");
        }

        public static void VerReunion(Cliente cliente)
        {
            Console.WriteLine($"Reuniones del cliente {cliente.ObtenerNombre()}:");

            bool hayReuniones = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Reunion reunion)
                {
                    Console.WriteLine($"Tema: {reunion.ObtenerTema()} | Fecha: {reunion.ObtenerFecha().ToShortDateString()}");

                    if (!string.IsNullOrEmpty(reunion.ObtenerNota()))
                        Console.WriteLine($"  Nota: {reunion.ObtenerNota()}");

                    hayReuniones = true;
                }
            }

            if (!hayReuniones)
                Console.WriteLine("No hay reuniones registradas.\n");
        }

        public static void VerMensaje(Cliente cliente)
        {
            Console.WriteLine($"Mensajes del cliente {cliente.ObtenerNombre()}:");

            bool hayMensajes = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Mensaje mensaje)
                {
                    Console.WriteLine($"Tema: {mensaje.ObtenerTema()} | Fecha: {mensaje.ObtenerFecha().ToShortDateString()}");

                    if (!string.IsNullOrEmpty(mensaje.ObtenerNota()))
                        Console.WriteLine($"  Nota: {mensaje.ObtenerNota()}");

                    hayMensajes = true;
                }
            }

            if (!hayMensajes)
                Console.WriteLine("No hay mensajes registrados.\n");
        }

        public static void VerLlamadas(Cliente cliente)
        {
            Console.WriteLine($"Llamadas del cliente {cliente.ObtenerNombre()}:");

            bool hayLlamadas = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Llamadas llamada)
                {
                    Console.WriteLine($"Tema: {llamada.ObtenerTema()} | Fecha: {llamada.ObtenerFecha().ToShortDateString()}");

                    if (!string.IsNullOrEmpty(llamada.ObtenerNota()))
                        Console.WriteLine($"  Nota: {llamada.ObtenerNota()}");

                    hayLlamadas = true;
                }
            }

            if (!hayLlamadas)
                Console.WriteLine("  No hay llamadas registradas.\n");
        }
    }
}
