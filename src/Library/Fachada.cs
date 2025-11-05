namespace Library;

public class Fachada
{
    private Vendedor _vendedor { get; set; }

    public Fachada(Vendedor vendedor)
    {
        this._vendedor = vendedor;
    }
    public void AgregarCliente(string name, string apellido, string telefono, string email, string genero, string fechaNacimiento)
    {
        //_vendedor.AgregarCliente(cliente);
    }

    public void ModificarCliente(Cliente cliente)
    {
        int aux = new int();
        Console.WriteLine($"Ingrese la modificacion que le desea realizar a {cliente.ObtenerNombre()}:");
        Console.WriteLine($"1 - Si quiere modificar el nombre");
        Console.WriteLine($"2 - Si quiere modificar el apellido");
        Console.WriteLine($"3 - Si quiere modificar el telefono");
        Console.WriteLine($"4 - Si quiere modificar el email");
        Console.WriteLine($"5 - Si no quiere modificar");
        aux = Console.Read();
        switch (aux)
        {
            case (1): //Modifica nombre
            {
                Console.WriteLine($"Nombre del cliente es {cliente.ObtenerNombre()}, ingrese un nuevo nombre:");
                string nom = Console.ReadLine();
                ModificadorCliente.ModificarNombre(nom, cliente);
                break;
            }
            case (2): //Modifica apellido
            {
                Console.WriteLine($"Apellido del cliente es {cliente.ObtenerApellido()}, ingrese un nuevo apellido:");
                string ap = Console.ReadLine();
                ModificadorCliente.ModificarNombre(ap, cliente);
                break;
            }
            case (3): //Modifica telefono
            {
                Console.WriteLine($"Telefono del cliente es {cliente.ObtenerTelefono()}, ingrese un nuevo telefono:");
                string tel = Console.ReadLine();
                ModificadorCliente.ModificarTelefono(tel, cliente);
                break;
            }
            case (4): //Modifica email
            {
                Console.WriteLine($"Email del cliente es {cliente.ObtenerEmail()}, ingrese un nuevo email:");
                string mail = Console.ReadLine();
                ModificadorCliente.ModificarEmail(mail, cliente);
                break;
            }
            case (5): //No quiere hacer cambios
            {
                break;
            }
            default:
            {
                break;
            }
        }
    }

    public void EliminarCliente(string email)
    {
        //_vendedor.EliminarCliente();
    }
    
    public void BuscarCliente(string email)
    {
        
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