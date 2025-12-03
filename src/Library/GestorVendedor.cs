namespace Library;

public class GestorVendedor : Gestor<Vendedor>, ISingleton
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
        this.Agregar(nuevoVendedor); //Lama al Singleton GestorVendedores para agregar el nuevo vendedor a la lista
    }

    /// <summary>
    /// Elimina un vendedor
    /// </summary>
    public void EliminarVendedor(string email) // Se usa el email porque es único para cada vendedor
    {
        bool existe = false;
        Vendedor vendedorAEliminar = null;
        for (int i = 0; i < Singleton<GestorVendedor>.Instance.VerTotal().Count; i++)//Recorre los la lista de vendedores
        {
            if (Singleton<GestorVendedor>.Instance.VerTotal()[i].ObtenerEmail()== email)//Cuando el email del vendedor coincide con la string que se pasó se elimina el vendedor
            {
                vendedorAEliminar = Singleton<GestorVendedor>.Instance.VerTotal()[i]; // Guardo al vendedor cuando llebgue a el
                existe = true;
                break;
            }
        }
        if (vendedorAEliminar != null)
        {
            Singleton<GestorVendedor>.Instance.Eliminar(vendedorAEliminar);
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
        foreach (var vendedor in Singleton<GestorVendedor>.Instance.VerTotal()) //Recorre los la lista de vendedores
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
    public void HabilitarVendedor(string email) 
    {
        bool existe = false;
        foreach (var vendedor in Singleton<GestorVendedor>.Instance.VerTotal()) //Recorre los la lista de vendedores
        {
            if (vendedor.ObtenerEmail()== email) //Cuando el email del vendedor coincide con la string que se pasó se cambia el estado del vendedor
            { 
                vendedor.Activo = true;
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
    /// <summary>
    /// Devuelve el vendedor con mayor cantidad de ventas
    /// </summary>
    public Vendedor VendedorMasVentas() 
    {
        //El gestor es la experta en los vendedores que existen
        int maxNumeroVentas = 0;
        Vendedor resultado = null;
        foreach (var vendedor in Singleton<GestorVendedor>.Instance.VerTotal()) //Recorre los la lista de vendedores
        {
            if (vendedor.ObtenerNumeroVentas()>maxNumeroVentas)//Si el numero de ventas del vendedor es mayor lo remplaza por el anterior
            {
                resultado = vendedor;
                maxNumeroVentas = vendedor.ObtenerNumeroVentas();
            }
        }
        return resultado;
    }
    /// <summary>
    /// Calcula el bono
    /// </summary>
     public int CalcularBono() 
    {
        //El gestor es la experta en el vendedor con más ventas
        int bono = 0;
        Vendedor vendedor = Singleton<GestorVendedor>.Instance.VendedorMasVentas();
        bono = vendedor.ObtenerNumeroVentas() * 100;
        return bono;
    }
}