using System.Runtime.InteropServices.JavaScript;

namespace Library;

public class Cliente
{
    private string Nombre { get; set; }
    private string Apellido { get; set; }
    private string Telefono { get; set; }
    private string Email { get; set; }
    private string Genero { get; set; }
    private DateTime FechaNacimiento { get; set; }
    private List<Etiqueta> _etiquetas = new List<Etiqueta>();
    private List<Interaccion> _interacciones = new List<Interaccion>();
    private List<Venta> _compras = new List<Venta>();
    private List<Cotizacion> _cotizaciones = new List<Cotizacion>();

    public Cliente(string nombre, string apellido, string telefono, string email, string genero, DateTime fechaNacimiento)
    {
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Email = email;
        Genero = genero;
        FechaNacimiento = fechaNacimiento;
    }

    public string ObtenerNombre()
    {
        return this.Nombre;
    }
    public string ObtenerApellido()
    {
        return this.Apellido;
    }
    public string ObtenerTelefono()
    {
        return this.Telefono;
    }
    public string ObtenerEmail()
    {
        return this.Email;
    }
    public string ObtenerGenero()
    {
        return this.Genero;
    }
    public DateTime ObtenerFechaNacimiento()
    {
        return this.FechaNacimiento;
    }
    public List<Etiqueta> ObtenerEtiquetas()
    {
        return this._etiquetas;
    }

    public List<Interaccion> ObtenerInteracciones()
    {
        return this._interacciones;
    }
    public List<Venta> ObtenerCompras()
    {
        return this._compras;
    }
    public List<Cotizacion> ObtenerCotizaciones()
    {
        return this._cotizaciones;
    }
    
    public void CambiarNombre(string nombre)
    {
        this.Nombre = nombre;
    }
    public void CambiarApellido(string apellido)
    {
        this.Apellido = apellido;
    }
    public void CambiarTelefono(string telefono)
    {
        this.Telefono = telefono;
    }
    public void CambiarEmail(string email)
    {
        this.Email = email;
    }
    public void CambiarGenero(string genero)
    {
        this.Genero = genero;
    }

    public void AgregarInteraccion(Interaccion interaccion)
    {
        this._interacciones.Add(interaccion);
    }

    public Interaccion UltimaInteraccion()
        //Recorre todas las interacciones del cliente y devuelve la última interacción 
    {
            Interaccion ultimaInteraccion = this.ObtenerInteracciones()[0];
            foreach (Interaccion interaccion in _interacciones) 
            {if ((ultimaInteraccion.ObtenerFecha() < interaccion.ObtenerFecha()) && (interaccion.ObtenerFecha()<DateTime.Now))
                {
                    ultimaInteraccion= interaccion;
                }
            }
            return ultimaInteraccion;
    }

    public void AgregarVenta(Venta venta)
    {
        this._compras.Add(venta);
    }
    public void AgregarCotizacion(Cotizacion cotizacion)
    {
        this._cotizaciones.Add(cotizacion);
    }
    
}

