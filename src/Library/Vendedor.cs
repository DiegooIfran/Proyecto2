using System.Globalization;
using System.Runtime.InteropServices;
namespace Library;
/// <summary>
/// Representa un vendedor del sistema.
/// Hereda de Usuario y gestiona una lista de clientes asociados,
/// además de realizar acciones como enviar campañas o generar cotizaciones.
/// </summary>
public class Vendedor : Usuario
{
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
    public Vendedor(string nombre, string apellido, string telefono, string email) //Constructor de vendedor
        : base(nombre, apellido, telefono, email)
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
    
    public void VerClientes() //Imprimir clientes
    {
        foreach (Cliente cliente in Clientes)
        {
            Console.WriteLine($"{cliente.ObtenerNombre()} {cliente.ObtenerApellido}");
        }
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
                GestorInteracciones.NuevoMensaje(cliente, DateTime.Today, "Feliz cumpleaños!!",
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
                GestorInteracciones.NuevoMensaje(cliente, DateTime.Today, "Camapaña unica! No te lo pierdas",
                    anuncio, true);
            }
        }
    }

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
            throw new ArgumentException("Cliente no encotrado");
        }
    }
    
    /// <summary>
    /// Muestra las ventas realizadas por los clientes del vendedor dentro de un rango de fechas determinado.
    /// </summary>
    public void TotalVentas(DateTime fechaInicio, DateTime fechaFinal) 
    {
        foreach (Cliente cliente in Clientes)
        {
            foreach (Venta compra in cliente.ObtenerInteracciones())
            {
                if (fechaInicio <= compra.Fecha && compra.Fecha <= fechaFinal)
                {
                    Console.WriteLine($"{cliente} compro {compra.ObtenerNota()} por {compra.Precio} el {compra.Fecha}");
                }
            }
        }
    }

    /// <summary>
    /// Muestra el panel visual del vendedor con sus datos y clientes asociados
    /// </summary>
    public void VerPanel() 
    {
        Panel.ImprimirPanel(this);
    }
}