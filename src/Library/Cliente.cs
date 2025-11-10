using System.Text.RegularExpressions;

namespace Library;
// Representa un cliente dentro del sistema.
// Contiene sus datos personales, etiquetas asociadas y el historial de interacciones
public class Cliente : IGestionable
{
    private string Nombre { get; set; }
    private string Apellido { get; set; }
    private string Telefono { get; set; }
    private string Email { get; set; }
    private string Genero { get; set; }
    private DateTime FechaNacimiento { get; set; }

    private List<Etiqueta> _etiquetas = new List<Etiqueta>();
    private List<Interaccion> _interacciones = new List<Interaccion>();

    // Constructor que inicializa un nuevo cliente con sus datos personales
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

    public void CambiarNombre(string nombre)
    {
        if (nombre == null)
        {
            throw new ArgumentNullException(nombre);
        }
        if (Regex.IsMatch(nombre, @"^[a-zA-Z ]+$")) //Valida que el nombre solo contenga letras
        {
            throw new ArgumentException(nombre);
        }
        this.Nombre = nombre;
    }

    public void CambiarApellido(string apellido)
    {
        if (apellido == null)
        {
            throw new ArgumentNullException(apellido);
        }
        if (Regex.IsMatch(apellido, @"^[a-zA-Z ]+$")) //Valida que el nombre solo contenga letras
        {
            throw new ArgumentException(apellido);
        }
        this.Apellido = apellido;
    }

    public void CambiarTelefono(string telefono)
    {
        if (telefono == null)
        {
            throw new ArgumentNullException(telefono);
        }
        if (Regex.IsMatch(telefono, @"^[0-9 +]+$")) //Valida que el teléfono solo contenga números o +
        {
            throw new ArgumentException(telefono);
        }
        this.Telefono = telefono;
    }

    public void CambiarEmail(string email)
    {
        if (email == null)
        {
            throw new ArgumentNullException(email);
        }
        if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) //Valida que el email solo contenga una arroba y alguas cosas más
        {
            throw new ArgumentException(email);
        }
        this.Email = email;
    }

    public void CambiarGenero(string genero)
    {
        if (genero == null)
        {
            throw new ArgumentNullException(genero);
        }
        if (Regex.IsMatch(genero, @"^[a-zA-Z ]+$")) //Valida que el nombre solo contenga letras
        {
            throw new ArgumentException(genero);
        }
        this.Genero = genero;
    }

    // Agrega una nueva interacción (como una venta o cotización) al historial del cliente
    public void AgregarInteraccion(Interaccion interaccion)
    {
        this._interacciones.Add(interaccion);
    }
    
    // Devuelve la última interacción realizada con el cliente,
    // comparando las fechas de todas sus interacciones registradas
    public Interaccion UltimaInteraccion()
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
}

