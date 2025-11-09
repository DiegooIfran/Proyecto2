namespace Library;

public class Administrador : Usuario, IGestionable
{
    public Administrador(string nombre, string apellido, string telefono, string email)
        : base(nombre, apellido, telefono, email)
    {
        Singleton<Gestor<Administrador>>.Instance.Agregar(this); // Al crear un administrador lo agrego a la lista global de administradores
    }
    
    public void CrearVendedor(string nombre, string apellido, string telefono, string email) 
    {
        Vendedor nuevoVendedor = new Vendedor(nombre, apellido, telefono, email);
        Singleton<Gestor<Vendedor>>.Instance.Agregar(nuevoVendedor); //Lama al Singleton GestorVendedores para agregar el nuevo vendedor a la lista
    }

    public void EliminarVendedor(string email) // Se usa el email porque es único para cada vendedor
    {
        bool existe = false;
        foreach (var vendedor in Singleton<Gestor<Vendedor>>.Instance.VerTotal())//Recorre los la lista de vendedores
        {
            if (vendedor.ObtenerEmail()== email)//Cuando el email del vendedor coincide con la string que se pasó se elimina el vendedor
            {
                Singleton<Gestor<Vendedor>>.Instance.Eliminar(vendedor);
                existe = true;
            }
        }

        if (!existe)
        {
            throw new ArgumentException("Vendedor no encontrado");
        }
    }

    public void SuspenderVendedor(string email) 
    {
        bool existe = false;
        foreach (var vendedor in Singleton<Gestor<Vendedor>>.Instance.VerTotal()) //Recorre los la lista de vendedores
        {
            if (vendedor.ObtenerEmail()== email) //Cuando el email del vendedor coincide con la string que se pasó se cambia el estado del vendedor
            { 
                vendedor.Activo = false;
                existe = true;
            }
        }
        if (!existe)
        {
            throw new ArgumentException("Vendedor no encontrado");
        }
    }
}