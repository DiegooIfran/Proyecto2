namespace Library;

public class Administrador : Usuario
{
    private List<Vendedor> Vendedores { get; set; }
    
    public Administrador(string nombre, string apellido, string telefono, string email) 
        : base(nombre, apellido, telefono, email)
    {
        this.Vendedores = new List<Vendedor>();
    }
    
    public void CrearVendedor(string nombre, string apellido, string telefono, string email) 
    {
        Vendedor nuevoVendedor = new Vendedor(nombre, apellido, telefono, email);
        Vendedores.Add(nuevoVendedor); 
    }

    public void EliminarVendedor(string email) //Decido usar los Email ya que deberia ser unico
    {
        Vendedores.RemoveAll(v => v.ObtenerEmail() == email);
    }

    public void SuspenderVendedor(string email)
    {
        foreach (Vendedor vendedor in Vendedores)
        {
            if (vendedor.ObtenerEmail() == email)
            {
                vendedor.Activo = false;
            }
        } 
    }

    public List<Vendedor> ObtenerVendedores()
    {
        return this.Vendedores;
    }
}