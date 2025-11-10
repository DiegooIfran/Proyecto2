using System.Text.RegularExpressions;

namespace Library;
/// <summary>
/// Representa un usuario dentro del sistema.
/// Contiene sus datos personales
/// </summary>
public abstract class Usuario : IGestionable
{
private string Nombre { get; }
    private string Apellido { get;}
    private string Telefono { get; }
    private string Email { get; }

    /// <summary>
    /// Constructor de la clase Usuario.
    /// Valida los datos ingresados antes de asignarlos a las propiedades.
    /// </summary>
    /// <param name="nombre">Nombre del usuario.</param>
    /// <param name="apellido">Apellido del usuario.</param>
    /// <param name="telefono">Número de teléfono del usuario.</param>
    /// <param name="email">Correo electrónico del usuario.</param>
    /// <exception cref="ArgumentNullException">Si alguno de los parámetros es nulo.</exception>
    /// <exception cref="ArgumentException">Si algún parámetro no cumple con el formato esperado.</exception>
    protected Usuario(string nombre, string apellido, string telefono, string email)
    {
        if (nombre == null)
        {
            throw new ArgumentNullException(nombre);
        }

        if (apellido == null)
        {
            throw new ArgumentNullException(apellido);
        }

        if (telefono == null)
        {
            throw new ArgumentNullException(telefono);
        }

        if (email == null)
        {
            throw new ArgumentNullException(email);
        }
        if (Regex.IsMatch(nombre, @"^[a-zA-Z ]+$")) //Valida que el nombre solo contenga letras
        {
            throw new ArgumentException(nombre);
        }
        if (Regex.IsMatch(apellido, @"^[a-zA-Z ]+$")) //Valida que el apellido solo contenga letras
        {
            throw new ArgumentException(apellido);
        }
        if (Regex.IsMatch(telefono, @"^[0-9 +]+$")) //Valida que el teléfono solo contenga números o +
        {
            throw new ArgumentException(telefono);
        }
        if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) //Valida que el email solo contenga una arroba y alguas cosas más
        {
            throw new ArgumentException(email);
        }
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Telefono = telefono;
        this.Email = email;
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
}