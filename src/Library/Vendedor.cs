using System.Globalization;
using System.Runtime.InteropServices;

namespace Library;

public class Vendedor : Usuario
{
    private List<Cliente> Clientes { get; set; }
    public bool Activo { get; set; }
    
    public Vendedor(string nombre, string apellido, string telefono, string email) 
        : base(nombre, apellido, telefono, email)
    {
        this.Activo = true;
        this.Clientes = new List<Cliente>();
    }

    public List<Cliente> ObtenerClientes()
    {
        return this.Clientes;
    }

    public void AgregarCliente(Cliente cliente)
    {
        this.Clientes.Add(cliente);
    }
    public void VerClientes()
    {
        foreach (Cliente cliente in Clientes)
        {
            Console.WriteLine($"{cliente.ObtenerNombre()} {cliente.ObtenerApellido}");
        }
    }

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

    public void Campana(Etiqueta etiqueta, string anuncio)
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

    public void NuevaCotizacion(Cliente cliente, int precio, string producto)
    {
        Cotizacion nuevaCotizacion = new(cliente, precio, producto);
        cliente.AgregarCotizacion(nuevaCotizacion);
    }

    public void TotalVentas(DateTime fechaInicio, DateTime fechaFinal)
    {
        foreach (Cliente cliente in Clientes)
        {
            foreach (Venta compra in cliente.ObtenerCompras())
            {
                if (fechaInicio <= compra.Fecha && compra.Fecha <= fechaFinal)
                {
                    Console.WriteLine($"{cliente} compro {compra.Producto} por {compra.Precio} el {compra.Fecha}");
                }
            }
        }
    }

    public void VerPanel()
    {
        Panel.ImprimirPanel(this);
    }
}