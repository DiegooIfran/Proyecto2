using System.Globalization;
using System.Runtime.InteropServices;
namespace Library;
/// <summary>
/// Representa un vendedor del sistema.
/// Hereda de Usuario y gestiona una lista de clientes asociados,
/// además de realizar acciones como enviar campañas o generar cotizaciones.
/// SRP: Su razon de cambio es si modificas las funciones de vendedor
/// </summary>
public class Vendedor : Usuario, IPersona
{
    Fachada fachada = Singleton<Fachada>.Instance;
    private GestorInteracciones gi = Singleton<GestorInteracciones>.Instance;

    /// <summary>
    /// Lista de clientes a cargo del vendedor.
    /// </summary> 
    private List<Cliente> Clientes { get; set; }
    
    /// <summary>
    /// Indica si el vendedor está activo en el sistema.
    /// </summary>
    public bool Activo { get; set; }
    
    /// <summary>
    /// Constructor de la clase Vendedor
    /// Inicializa el vendedor con sus datos personales, lo marca como activo y crea su lista de clientes.
    /// </summary>
    public Vendedor(string nombre, string apellido, string telefono, string email, string nickname) //Constructor de vendedor
        : base(nombre, apellido, telefono, email, nickname)
    {
        this.Activo = true;
        this.Clientes = new List<Cliente>();
    }

    public List<Cliente> ObtenerClientes() //Obtener clientes
    { 
        return this.Clientes;
    }

    /// <summary>
    /// Agrega un cliente a la lista del vendedor, si no está ya incluido.
    /// </summary>
    /// <param name="cliente">El cliente a agregar.</param>
    /// <exception cref="ArgumentNullException">Si el cliente es nulo.</exception>
    public void AgregarCliente(Cliente cliente) //Agregar cliente a la lista
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }

        if (!Clientes.Contains(cliente))
        {
            this.Clientes.Add(cliente);
        }
    }
    
    public List<Cliente> VerClientes()
    {
        return this.Clientes;
    }


    /// <summary>
    /// Envía un mensaje de cumpleaños a los clientes cuya fecha de nacimiento coincide con la fecha actual
    /// </summary>
    public void FestejarCumpleanos() 
    {
        foreach (Cliente cliente in Clientes)
        {
            if (cliente.ObtenerFechaNacimiento() == DateTime.Today)
            {
                gi.NuevoMensaje(cliente, DateTime.Today, "Feliz cumpleaños!!",
                    "Feliz cumpleaños! ¿Porque no lo festejas con los descuentos especiales que tenemos para vos?", true);
            }
        }
    }

    /// <summary>
    /// Crea y envía una campaña publicitaria a todos los clientes que poseen una etiqueta específica
    /// </summary>
    public void Campana(Etiqueta etiqueta, string anuncio) //Crear un anuncio para clientes especificos
    {
        foreach (Cliente cliente in Clientes)
        {
            if (cliente.ObtenerEtiquetas().IndexOf(etiqueta) != -1)
            {
                gi.NuevoMensaje(cliente, DateTime.Today, "Camapaña unica! No te lo pierdas",
                    anuncio, true);
            }
        }
    } //Arreglar esto

    /// <summary>
    /// Crea una nueva cotización para un cliente específico, siempre que el cliente pertenezca al vendedor.
    /// </summary>
    /// <param name="fecha">Fecha de creación de la cotización.</param>
    /// <param name="tema">Tema o título de la cotización.</param>
    /// <param name="notas">Notas adicionales o detalles.</param>
    /// <param name="cliente">Cliente asociado a la cotización.</param>
    /// <param name="precio">Monto estimado o precio cotizado.</param>
    /// <exception cref="ArgumentException">Si el cliente no pertenece al vendedor.</exception>
    public void NuevaCotizacion(DateTime fecha, string tema, string notas, Cliente cliente,
        int precio) //Crear una cotizacion
    {
        Cotizacion nuevaCotizacion = new Cotizacion(DateTime.Now, tema, notas, cliente, precio);
        if (Clientes.Contains(cliente))
        {
            cliente.AgregarInteraccion(nuevaCotizacion);
        }
        else
        {
            throw new ArgumentException("Cliente no encontrado");
        }
    }
    
    public void NuevaLlamada(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada)
    {
        gi.NuevaLlamada(cliente , fecha, tema, notas, enviada);
    }
    
    public void NuevoMensaje(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada)
    {
        gi.NuevoMensaje(cliente , fecha, tema, notas, enviada);
    }
    
    public void NuevoCorreo(Cliente cliente, DateTime fecha, string tema, string notas, bool enviada)
    {
        gi.NuevoCorreo(cliente , fecha, tema, notas, enviada);
    }
    
    public void NuevaReunion(Cliente cliente, DateTime fecha, string tema, string notas)
    {
        gi.NuevaReunion(cliente , fecha, tema, notas);
    }
    
    /// <summary>
    /// Muestra una lista de todas las ventas de cada cliente
    /// </summary>
    public string TotalVentas(DateTime fechaInicio, DateTime fechaFinal)
    {
        string totalVentas="Lista de todas las ventas:\n";
        foreach (Cliente cliente in Clientes)
        {
            foreach (Interaccion interaccion in cliente.ObtenerInteracciones())
            {
                if (interaccion is Venta venta)
                {
                    if (fechaInicio <= venta.Fecha && venta.Fecha <= fechaFinal)
                    {
                        totalVentas+=($"- {cliente.ObtenerNombre()} {cliente.ObtenerApellido()} compró {venta.ObtenerNota()} por ${venta.Precio} el {venta.Fecha}\n");
                    }    
                }
            }
        } 
        return totalVentas;
    }

    /// <summary>
    /// Define como se convierte en string
    /// </summary>
    public override string ToString()
    {
        return $"{this.ObtenerNombre()} {this.ObtenerApellido()} de nick: {this.ObtenerNick()}- Contacto: correo {this.ObtenerEmail()}, teléfono {this.ObtenerTelefono()}";
    }
    /// <summary>
    /// Devuelve el número de ventas del vendedor
    /// </summary>
    public int ObtenerNumeroVentas()
    {
        int resultado = 0;
        foreach (Cliente cliente in Clientes)
        {
            foreach (Interaccion interaccion in cliente.ObtenerInteracciones()) //LLama al método ObtenerInteracciones para no tener que interactuar directamente con el atributo de los clientes (Principio Demeter)
            {
                if (interaccion is Venta venta) //Recorre todas las interaciones 
                {
                    resultado += 1;
                }
            }
        } 
        return resultado;
    }
}