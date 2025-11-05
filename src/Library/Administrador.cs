namespace Library;

public class Administrador : Usuario
{
   public Administrador(string nombre, string apellido, string telefono, string email) 
        : base(nombre, apellido, telefono, email)
    { }
    
    public void CrearVendedor(string nombre, string apellido, string telefono, string email) 
    {
        Vendedor nuevoVendedor = new Vendedor(nombre, apellido, telefono, email);
        GestorVendedor.AgregarVendedor(nuevoVendedor); //
    }

    public void EliminarVendedor(string email) //Decido usar los Email ya que deberia ser unico
    { 
        foreach (var vendedor in GestorVendedor.VerTotalVendedores())
        {
            if (vendedor.ObtenerEmail()== email)
            {
                GestorVendedor.EliminarVendedor(vendedor);
            }
        }
    }

    public void SuspenderVendedor(string email)
    {
        foreach (var vendedor in GestorVendedor.VerTotalVendedores())
        {
            if (vendedor.ObtenerEmail()== email)
            { 
                vendedor.Activo = false;
            }
        }
    }
}