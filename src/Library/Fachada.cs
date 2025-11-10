namespace Library;

public class Fachada
{
    private Vendedor _vendedor { get; set; }
    private GestorCliente gc { get; set; }
    private static Fachada instance;
    
    // Este constructor privado impide que otras clases puedan crear instancias
    // de esta.
    private Fachada()
    {
        this.gc = new GestorCliente();
    }
    
    // Este constructor es interno para que en las pruebas se pueda injectar
    // un mock del repositorio de usuarios en lugar de un repositorio real.
    /*
    internal Fachada(GestorCliente gc)
    {
        ArgumentNullException.ThrowIfNull(gc);
            
        this.gc = gc;
    }
    */
    
    /// <summary>
    /// Obtiene la única instancia de la clase <see cref="Fachada"/>.
    /// </summary>
    public static Fachada Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Fachada();
            }

            return instance;
        }
    }
    
    //Agregar un cliente
    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero, DateTime fechaNacimiento)
    {
        gc.AgregarCliente(name, apellido, telefono, email, genero, fechaNacimiento);
    }

    //Modificar nombre de un cliente
    public void ModificarNombre(string email, string nombreNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarNombre(nombreNuevo);
    }
    
    //Modificar apellido de un cliente
    public void ModificarApellido(string email, string apellidoNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarApellido(apellidoNuevo);
    }
    
    //Modificar telefono de un cliente
    public void ModificarTelefono(string email, string telefonoNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarTelefono(telefonoNuevo);
    }
    
    //Modificar email de un cliente
    public void ModificarEmail(string email, string emailNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarEmail(emailNuevo);
    }

    //Eliminar un cliente
    public void EliminarCliente(string email)
    {
        gc.EliminarCliente(email);
    }
    
    //Buscar un cliente
    public void BuscarCliente(string email)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes);
    }
    
    //Ver todos los clientes
    public void VerTotalClientes()
    {
        _vendedor.VerClientes();
    }

    //Registrar llamada con un cliente
    public void RegistrarLlamada(string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        //_vendedor.NuevaLlamada(gc.BuscarPorEmail(correo, gc.TotalClientes), fecha, tema, nota, enviada);
    }
    
    //Registrar correo con un cliente
    public void RegistrarCorreo(string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        //_vendedor.NuevoCorreo(gc.BuscarPorEmail(correo, gc.TotalClientes), fecha, tema, nota, enviada);
    }
    
    //Registrar mensaje con un cliente
    public void RegistrarMensaje(string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        //_vendedor.NuevoMensaje(gc.BuscarPorEmail(correo, gc.TotalClientes), fecha, tema, nota, enviada);
    }
    
    //Registrar reunion con un cliente
    public void RegistrarReunion(string correo, DateTime fecha, string tema, string nota)
    {
        //_vendedor.NuevaReunion(gc.BuscarPorEmail(correo, gc.TotalClientes), fecha, tema, nota, enviada);
    }
    
    //Crear una etiqueta
    public void CrearEtiqueta(string nombre, string descripcion)
    {
        Etiqueta etiqueta = new Etiqueta(nombre, descripcion);
    }
    
    //Agregar etiqueta a un cliente
    public void AgregarEtiqueta(string correo, Etiqueta etiqueta)
    {
        etiqueta.AgregarEtiqueta(gc.BuscarPorEmail(correo, gc.TotalClientes));
    }
    
    //Realizar campaña publicitaria
    public void RealizarCampana(Etiqueta etiqueta, string anuncio)
    {
        _vendedor.Campana(etiqueta, anuncio);
    }
    
    //Realizar cotizacion de un producto (tema especifica un producto)
    public void RealizarCotizacion(DateTime fecha, string tema, string notas, string correo, int precio)
    {
        _vendedor.NuevaCotizacion(fecha, tema, notas, gc.BuscarPorEmail(correo, gc.TotalClientes), precio);
    }
    
    //Realizar venta de una cotizacion previa (tema especifica un producto)
    public void RealizarVenta(string correo, string tema)
    {
        foreach (Cotizacion interaccion in gc.BuscarPorEmail(correo, gc.TotalClientes).ObtenerInteracciones())
        {
            if (interaccion.ObtenerTema() == tema)
            {
                interaccion.CerrarVenta();
            }
        }
    }
    
    //Ver interacciones con los clientes
    public void VerInteraccionesCliente(string correo)
    {
        gc.BuscarPorEmail(correo, gc.TotalClientes).ObtenerInteracciones();
    }

    //Crear un usuario
    public void CrearUsuario(string nombre, string apellido, string telefono, string email)
    {
        Vendedor vendedor = new Vendedor(nombre, apellido, telefono, email);
    }
    
    //Suspender un usuario
    public void SuspenderUsuario(string email)
    {
        //admin.GestorVendedor().SuspenderVendedor(email);
    }
    
    //Eliminar un usuario
    public void EliminarUsuario(string email)
    {
        //admin.GestorVendedor().EliminarVendedor(email);
    }
    
    //Asignar un cliente a otro vendedor
    public void AsignarCliente(Vendedor vendedor, string correo)
    {
        gc.AsignarCliente(_vendedor, gc.BuscarPorEmail(correo, gc.TotalClientes));
    }
    
    public void VerPanel()
    {
        _vendedor.VerPanel();
    }
}