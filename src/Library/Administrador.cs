namespace Library;

public class Administrador : Usuario
{
    public Administrador(string nombre, string apellido, string telefono, string email)
        : base(nombre, apellido, telefono, email)
    {
        GestorAdministrador.AgregarAdministrador(this); //Agrega el administrador al Gestor de Administradores
    }
    
    public void CrearVendedor(string nombre, string apellido, string telefono, string email) 
    {
        Vendedor nuevoVendedor = new Vendedor(nombre, apellido, telefono, email);
        GestorVendedor.AgregarVendedor(nuevoVendedor); //Lama al Singleton GestorVendedores para agregar el nuevo vendedor a la lista
    }

    public void EliminarVendedor(string email) // Se usa el email porque es único para cada vendedor
    { 
        foreach (var vendedor in GestorVendedor.VerTotalVendedores())//Recorre los la lista de vendedores
        {
            if (vendedor.ObtenerEmail()== email)//Cuando el email del vendedor coincide con la string que se pasó se elimina el vendedor
            {
                GestorVendedor.EliminarVendedor(vendedor);
            }
        }
    }

    public void SuspenderVendedor(string email) 
    {
        foreach (var vendedor in GestorVendedor.VerTotalVendedores()) //Recorre los la lista de vendedores
        {
            if (vendedor.ObtenerEmail()== email) //Cuando el email del vendedor coincide con la string que se pasó se cambia el estado del vendedor
            { 
                vendedor.Activo = false;
            }
        }
    }
}