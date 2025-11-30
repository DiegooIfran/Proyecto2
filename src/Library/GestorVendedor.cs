namespace Library;

public class GestorVendedor:Gestor<Vendedor>
{
    /// <summary>
    /// Crea nuevos vendedores
    /// Patron Creator: Crea los vendedores ya que los almacena y los usa
    /// Principio SRP: unicamente gestiona los vendedores
    /// OCP: Se puede agregar funciones sin modificar lo ya hecho
    /// </summary>
    public void CrearVendedor(string nombre, string apellido, string telefono, string email, string nickname) 
    {
        Vendedor nuevoVendedor = new Vendedor(nombre, apellido, telefono, email, nickname);
        Singleton<Gestor<Vendedor>>.Instance.Agregar(nuevoVendedor); //Lama al Singleton GestorVendedores para agregar el nuevo vendedor a la lista
    }

    /// <summary>
    /// Elimina un vendedor
    /// </summary>
    public void EliminarVendedor(string email) // Se usa el email porque es único para cada vendedor
    {
        bool existe = false;
        Vendedor vendedorAEliminar = null;
        for (int i = 0; i < Singleton<Gestor<Vendedor>>.Instance.VerTotal().Count; i++)//Recorre los la lista de vendedores
        {
            if (Singleton<Gestor<Vendedor>>.Instance.VerTotal()[i].ObtenerEmail()== email)//Cuando el email del vendedor coincide con la string que se pasó se elimina el vendedor
            {
                vendedorAEliminar = Singleton<Gestor<Vendedor>>.Instance.VerTotal()[i]; // Guardo al vendedor cuando llebgue a el
                existe = true;
                break;
            }
        }
        if (vendedorAEliminar != null)
        {
            Singleton<Gestor<Vendedor>>.Instance.Eliminar(vendedorAEliminar);
        }
        if (!existe)
        {
            throw new ArgumentException("Vendedor no encontrado");
        }
    }

    /// <summary>
    /// Suspende un vendedor
    /// </summary>
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
    
    public Vendedor BuscarPorNick(string nick)
    {
        foreach (Vendedor vendedor in this.VerTotal())
        {
            if (nick == vendedor.ObtenerNick())
            {
                return vendedor;
            }
        }

        throw new InvalidOperationException("No se encontró ningún usuario con ese nombre.");
    }

}