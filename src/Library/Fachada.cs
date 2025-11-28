namespace Library;

public class Fachada : ISingleton
{
    
    //VA ASI GESTOR INTERACCIONES O NO??????????????????
    //private GestorInteracciones<Interaccion> gi = Singleton<GestorInteracciones<Interaccion>>.Instance
    private GestorEtiquetas<Etiqueta> ge = Singleton<GestorEtiquetas<Etiqueta>>.Instance;
    private GestorVendedor gv = Singleton<GestorVendedor>.Instance;
    private GestorCliente gc = Singleton<GestorCliente>.Instance;
    private GestorAdministrador ga = Singleton<GestorAdministrador>.Instance;

    
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
    public  List<Cliente>  BuscarPorNombre(string nombre)
    {
        return gc.BuscarPorNombre(nombre);
    }
    
    //Buscar por vendedor por nick
    public Usuario BuscarVendedorNick(string nick)
    {
            return gv.BuscarPorNick(nick);
    }
    
    
    //Buscar por nick administrador
    public Usuario BuscarAdministradorNick(string nick)
    {
        return ga.BuscarPorNick(nick);
    }
    
    //Buscar por telefono
    public Cliente BuscarPorTelefono(string telefono)
    {
        return gc.BuscarPorTelefono(telefono);
    }
    
    //Buscar por apellido
    public  List<Cliente>  BuscarPorApellido(string apellido)
    {
        return gc.BuscarPorApellido(apellido);
    }
    
    //Ver todos los clientes
    public void VerTotalClientes(Vendedor vendedor)
    {
        vendedor.VerClientes();
    }

    //Registrar llamada con un cliente
    public void RegistrarLlamada(string nick, string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        vendedor.NuevaLlamada(gc.BuscarPorEmail(correo), fecha, tema, nota, enviada);
    }
    
    //Registrar correo con un cliente
    public void RegistrarCorreo(string nick, string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        vendedor.NuevoCorreo(gc.BuscarPorEmail(correo), fecha, tema, nota, enviada);
    }
    
    //Registrar mensaje con un cliente
    public void RegistrarMensaje(string nick, string correo, DateTime fecha, string tema, string nota, bool enviada)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        vendedor.NuevoMensaje(gc.BuscarPorEmail(correo), fecha, tema, nota, enviada);
    }
    
    //Registrar reunion con un cliente
    public void RegistrarReunion(string nick, string correo, DateTime fecha, string tema, string nota)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        vendedor.NuevaReunion(gc.BuscarPorEmail(correo), fecha, tema, nota);
    }
    
    //Crear una etiqueta
    public void CrearEtiqueta(string nombre, string descripcion)
    {
        ge.CrearEtiqueta(nombre, descripcion);
    }
    
    //Agregar etiqueta a un cliente
    public void AgregarEtiqueta(string correo, string nombreEtiqueta)
    {
        ge.AgregarEtiqueta(gc.BuscarPorEmail(correo), ge.RetornarEtiqueta(nombreEtiqueta));
    }
    
    //Borrar etiqueta a un cliente
    public void BorrarEtiqueta(string correo, string nombreEtiqueta)
    {
        ge.BorrarEtiqueta(gc.BuscarPorEmail(correo), ge.RetornarEtiqueta(nombreEtiqueta));
    }
    
    //Realizar campaña publicitaria
    public void RealizarCampana(string nick, string nombreEtiqueta, string anuncio)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        vendedor.Campana(ge.RetornarEtiqueta(nombreEtiqueta), anuncio);
    }
    
    //Realizar cotizacion de un producto (tema especifica un producto)
    public void RealizarCotizacion(string nick, string correo, DateTime fecha, string tema, string notas, int precio)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        vendedor.NuevaCotizacion(fecha, tema, notas, gc.BuscarPorEmail(correo), precio);
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
    public void CrearVendedor(string nombre, string apellido, string telefono, string email, string nick)
    {
        gv.CrearVendedor(nombre,  apellido, telefono, email, nick);
    }
    
    //Suspender un usuario
    public void SuspenderUsuario(string email)
    {
        gv.SuspenderVendedor(email);
    }
    
    //Eliminar un usuario
    public void EliminarVendedor(string email)
    {
        gv.EliminarVendedor(email);
    }
    
    //Asignar un cliente a otro vendedor
    public void AsignarCliente(string nick, string correo)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        gc.AsignarCliente(vendedor, gc.BuscarPorEmail(correo));
    }
    
    public void VerPanel(string nick)
    {
        Vendedor vendedor = gv.BuscarPorNick(nick);
        vendedor.VerPanel();
    }
    //Crear un Administrador
    public void CrearAdministrador(string nombre, string apellido, string telefono, string email, string nick)
    {
        new Administrador(nombre,  apellido, telefono, email, nick);
    }
}
