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

    internal Fachada(GestorCliente gc)
    {
        ArgumentNullException.ThrowIfNull(gc);
            
        this.gc = gc;
    }

    
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
        gc.BuscarPorEmail(email).CambiarNombre(nombreNuevo);
    }
    
    //Modificar apellido de un cliente
    public void ModificarApellido(string email, string apellidoNuevo)
    {
        gc.BuscarPorEmail(email).CambiarApellido(apellidoNuevo);
    }
    
    //Modificar telefono de un cliente
    public void ModificarTelefono(string email, string telefonoNuevo)
    {
        gc.BuscarPorEmail(email).CambiarTelefono(telefonoNuevo);
    }
    
    //Modificar email de un cliente
    public void ModificarEmail(string email, string emailNuevo)
    {
        gc.BuscarPorEmail(email).CambiarEmail(emailNuevo);
    }

    //Eliminar un cliente
    public void EliminarCliente(string email)
    {
        gc.Eliminar(gc.BuscarPorEmail(email));
    }
    
    //Buscar un cliente por email
    public Cliente BuscarPorEmail(string email)
    {
        return gc.BuscarPorEmail(email);
    }
    
    //Buscar por nombre
    public Cliente BuscarPorNombre(string nombre)
    {
        return gc.BuscarPorNombre(nombre);
    }
    
    //Buscar por telefono
    public Cliente BuscarPorTelefono(string telefono)
    {
        return gc.BuscarPorTelefono(telefono);
    }
    
    //Buscar por apellido
    public Cliente BuscarPorApellido(string apellido)
    {
        return gc.BuscarPorApellido(apellido);
    }
    
    //Ver todos los clientes
    public void VerTotalClientes()
    {
        _vendedor.VerClientes();
    }

    //Registrar llamada con un cliente
    public void RegistrarLlamada(string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        _vendedor.NuevaLlamada(gc.BuscarPorEmail(correo), fecha, tema, nota, enviada);
    }
    
    //Registrar correo con un cliente
    public void RegistrarCorreo(string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        _vendedor.NuevoCorreo(gc.BuscarPorEmail(correo), fecha, tema, nota, enviada);
    }
    
    //Registrar mensaje con un cliente
    public void RegistrarMensaje(string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        _vendedor.NuevoMensaje(gc.BuscarPorEmail(correo), fecha, tema, nota, enviada);
    }
    
    //Registrar reunion con un cliente
    public void RegistrarReunion(string correo, DateTime fecha, string tema, string nota)
    {
        _vendedor.NuevaReunion(gc.BuscarPorEmail(correo), fecha, tema, nota);
    }
    
    //Crear una etiqueta
    public void CrearEtiqueta(string nombre, string descripcion)
    {
        Etiqueta etiqueta = new Etiqueta(nombre, descripcion);
    }
    
    //Agregar etiqueta a un cliente
    public void AgregarEtiqueta(string correo, Etiqueta etiqueta)
    {
        etiqueta.AgregarEtiqueta(gc.BuscarPorEmail(correo));
    }
    
    //Realizar campaña publicitaria
    public void RealizarCampana(Etiqueta etiqueta, string anuncio)
    {
        _vendedor.Campana(etiqueta, anuncio);
    }
    
    //Realizar cotizacion de un producto (tema especifica un producto)
    public void RealizarCotizacion(string correo, DateTime fecha, string tema, string notas, int precio)
    {
        _vendedor.NuevaCotizacion(fecha, tema, notas, gc.BuscarPorEmail(correo), precio);
    }
    
    //Realizar venta de una cotizacion previa (tema especifica un producto)
    public void RealizarVenta(string correo, string tema)
    {
        foreach (Cotizacion cotizacion in gc.BuscarPorEmail(correo).ObtenerInteracciones())
        {
            if (cotizacion.ObtenerTema() == tema)
            {
                cotizacion.CerrarVenta();
                break;
            }
        }
    }
    
    //Ver interacciones con los clientes
    public void VerInteraccionesCliente(string correo)
    {
        gc.BuscarPorEmail(correo).ObtenerInteracciones();
    }

    //Crear un usuario
    public void CrearVendedor(string nombre, string apellido, string telefono, string email, Administrador admin)
    {
        admin.CrearVendedor(nombre,  apellido, telefono, email);
    }
    
    //Para añadir un vendedor a la fachada
    public void AsignarVendedor(Vendedor vendedor)
    {
        this._vendedor = vendedor;
    }
    
    //Suspender un usuario
    public void SuspenderUsuario(string email, Administrador admin)
    {
        admin.SuspenderVendedor(email);
    }
    
    //Eliminar un usuario
    public void EliminarUsuario(string email, Administrador admin)
    {
        admin.EliminarVendedor(email);
    }
    
    //Asignar un cliente a otro vendedor
    public void AsignarCliente(Vendedor vendedor, string correo)
    {
        gc.AsignarCliente(_vendedor, gc.BuscarPorEmail(correo));
    }
    
    public void VerPanel()
    {
        _vendedor.VerPanel();
    }
}