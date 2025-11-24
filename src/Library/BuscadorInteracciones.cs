namespace Library
    /// <summary>
    /// Utilidades para visualizar las interacciones de un cliente por tipo (correo, reunión, mensaje, llamada).
    /// </summary>
{
    public static class BuscadorInteracciones
    {
        public static string VerCorreo(Cliente cliente)
        {
            if (cliente == null) //Valida que el cliente no sea nulo
                throw new ArgumentNullException(nameof(cliente));

            string resultado = $"Correos del cliente {cliente.ObtenerNombre()}:\n";

            bool hayCorreos = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Correo correo)
                {
                    resultado += $"Tema: {correo.ObtenerTema()} | Fecha: {correo.ObtenerFecha().ToShortDateString()}\n";

                    if (!string.IsNullOrEmpty(correo.ObtenerNota()))
                        resultado += $"  Nota: {correo.ObtenerNota()}\n";

                    hayCorreos = true;
                }
            }

            if (!hayCorreos)
                resultado += "No hay correos registrados.\n";

            return resultado;
        }


        public static string VerReunion(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            string resultado = $"Reuniones del cliente {cliente.ObtenerNombre()}:\n";
            bool hayReuniones = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Reunion reunion)
                {
                    resultado +=
                        $"Tema: {reunion.ObtenerTema()} | Fecha: {reunion.ObtenerFecha().ToShortDateString()}\n";

                    if (!string.IsNullOrEmpty(reunion.ObtenerNota()))
                        resultado += $"  Nota: {reunion.ObtenerNota()}\n";

                    hayReuniones = true;
                }
            }

            if (!hayReuniones)
                resultado += "No hay reuniones registradas.\n";

            return resultado;
        }


        public static string VerMensaje(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            string resultado = $"Mensajes del cliente {cliente.ObtenerNombre()}:\n";
            bool hayMensajes = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Mensaje mensaje)
                {
                    resultado +=
                        $"Tema: {mensaje.ObtenerTema()} | Fecha: {mensaje.ObtenerFecha().ToShortDateString()}\n";

                    if (!string.IsNullOrEmpty(mensaje.ObtenerNota()))
                        resultado += $"  Nota: {mensaje.ObtenerNota()}\n";

                    hayMensajes = true;
                }
            }

            if (!hayMensajes)
                resultado += "No hay mensajes registrados.\n";

            return resultado;
        }


        public static string VerLlamadas(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            string resultado = $"Llamadas del cliente {cliente.ObtenerNombre()}:\n";
            bool hayLlamadas = false;

            foreach (var interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Llamada llamada)
                {
                    resultado +=
                        $"Tema: {llamada.ObtenerTema()} | Fecha: {llamada.ObtenerFecha().ToShortDateString()}\n";

                    if (!string.IsNullOrEmpty(llamada.ObtenerNota()))
                        resultado += $"  Nota: {llamada.ObtenerNota()}\n";

                    hayLlamadas = true;
                }
            }

            if (!hayLlamadas)
                resultado += "No hay llamadas registradas.\n";

            return resultado;
        }

    }
}