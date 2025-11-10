using System.Text.RegularExpressions;

namespace Library;

public abstract class Usuario : IGestionable
{
private string Nombre { get; }
    private string Apellido { get;}
    private string Telefono { get; }
    private string Email { get; }

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
        if (!Regex.IsMatch(nombre, @"^[a-zA-Z ]+$")) //Valida que el nombre solo contenga letras
        {
            throw new ArgumentException(nombre);
        }
        if (!Regex.IsMatch(apellido, @"^[a-zA-Z ]+$")) //Valida que el apellido solo contenga letras
        {
            throw new ArgumentException(apellido);
        }
        if (!Regex.IsMatch(telefono, @"^[0-9 +]+$")) //Valida que el teléfono solo contenga números o +
        {
            throw new ArgumentException(telefono);
        }
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) //Valida que el email solo contenga una arroba y alguas cosas más
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