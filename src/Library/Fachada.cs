namespace Library;

public class Fachada
{
    private Vendedor _vendedor { get; set; }
    private GestorCliente gc { get; set; }

    public Fachada(Vendedor vendedor)
    {
        this._vendedor = vendedor;
        this.gc = new GestorCliente();
    }
    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero, DateTime fechaNacimiento)
    {
        gc.AgregarCliente(name, apellido, telefono, email, genero, fechaNacimiento);
    }

    public void ModificarNombre(string email, string nombreNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarNombre(nombreNuevo);
    }
    
    public void ModificarApellido(string email, string apellidoNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarNombre(apellidoNuevo);
    }
    
    public void ModificarTelefono(string email, string telefonoNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarNombre(telefonoNuevo);
    }
    
    public void ModificarEmail(string email, string emailNuevo)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes).CambiarNombre(emailNuevo);
    }

    public void EliminarCliente(string email)
    {
        gc.EliminarCliente(email);
    }
    
    public void BuscarCliente(string email)
    {
        gc.BuscarPorEmail(email, gc.TotalClientes);
    }
    
    public void VerTotalClientes()
    {
        _vendedor.VerClientes();
    }
    
    public void RegistrarLlamada(Cliente cliente, DateTime fecha, string tema, string nota, bool enviada)
    {
        //_vendedor.NuevaLlamada(cliente, fecha, tema, nota, enviada);
    }
    
    public void RegistrarCorreo(Cliente cliente, DateTime fecha, string tema, string nota, bool enviada)
    {
        //_vendedor.NuevoCorreo(cliente, fecha, tema, nota, enviada);
    }
    
    public void RegistrarMensaje(Cliente cliente, DateTime fecha, string tema, string nota, bool enviada)
    {
        //_vendedor.NuevoMensaje(cliente, fecha, tema, nota, enviada);
    }
    
    public void RegistrarReunion(Cliente cliente, DateTime fecha, string tema, string nota)
    {
        //_vendedor.NuevaReunion(cliente, fecha, tema, nota, enviada);
    }
    
    public void CrearEtiqueta(string nombre, string descripcion)
    {
        Etiqueta etiqueta = new Etiqueta(nombre, descripcion);
    }
    
    public void AgregarEtiqueta(Cliente cliente, Etiqueta etiqueta)
    {
        etiqueta.AgregarEtiqueta(cliente);
    }
    
    public void RealizarCampana(Etiqueta etiqueta, string anuncio)
    {
        _vendedor.Campana(etiqueta, anuncio);
    }
    
    public void RealizarCotizacion(Cliente cliente, int precio, string producto)
    {
        //Cotizacion cotizacion = new Cotizacion(cliente, precio, producto);
    }
    
    public void RealizarVenta(int precio, string producto)
    {
        //Cotizacion cotizacion = new Cotizacion(cliente, precio, producto);
        //cotizacion.CerrarVenta();
    }
    
    public void VerInteraccionesCliente(Cliente cliente)
    {
        //_vendedor.VerInteracciones(cliente);
    }

    public void CrearUsuario(string nombre, string apellido, string telefono, string email)
    {
        Vendedor vendedor = new Vendedor(nombre, apellido, telefono, email);
    }
    
    public void SuspenderUsuario(string email)
    {
        //admin.GestorVendedor().SuspenderVendedor(email);
    }
    
    public void EliminarUsuario(string email)
    {
        //admin.GestorVendedor().EliminarVendedor(email);
    }
    
    public void AsignarCliente(Vendedor vendedor, Cliente cliente)
    {
        //_vendedor.GestorCliente().AsignarCliente(vendedor, cliente);
    }
    
    public void VerPanel()
    {
        _vendedor.VerPanel();
    }
}