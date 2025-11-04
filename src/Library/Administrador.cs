namespace Library;

public class Administrador : Usuario
{
   public Administrador(string nombre, string apellido, string telefono, string email) 
        : base(nombre, apellido, telefono, email)
    { }
    
    public void CrearVendedor(string nombre, string apellido, string telefono, string email) 
    {
        Vendedor nuevoVendedor = new Vendedor(nombre, apellido, telefono, email);
    }

    public void EliminarVendedor(Vendedor vendedor) //Decido usar los Email ya que deberia ser unico
    {
        GestorVendedor.EliminarVendedor(vendedor);
    }

    public void SuspenderVendedor(Vendedor vendedor)
    {
         if (vendedor.Activo==true)
         { 
             vendedor.Activo = false;
         }
    }
}