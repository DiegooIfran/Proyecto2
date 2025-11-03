namespace Library;

public abstract class Usuario
{
    private string Nombre { get; }
    private string Apellido { get;}
    private string Telefono { get; }
    private string Email { get; }

    protected Usuario(string nombre, string apellido, string telefono, string email)
    {
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