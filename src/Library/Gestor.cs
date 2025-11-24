namespace Library;
/// <summary>
/// Clase genérica que gestiona colecciones de objetos que implementan la interfaz IGestionable.
/// Puede utilizarse para administrar distintos tipos de usuarios, como administradores o vendedores.
/// </summary>
/// <typeparam name="T">Tipo de objeto gestionado. Debe implementar IGestionable.</typeparam>

public class Gestor<T> where T : IGestionable
{
    /// <summary>
    /// Lista que contiene todos los elementos gestionados (por ejemplo, vendedores o administradores)
    /// </summary>
    private List<T> _total = new List<T>();
    
    /// <summary>
    /// Agrega un nuevo elemento a la lista gestionada
    /// </summary>
    public void Agregar(T usuario)
    {
        _total.Add(usuario);
    }

    /// <summary>
    /// Devuelve la lista completa de elementos gestionados
    /// </summary>
    public List<T> VerTotal()
    {
        return _total;
    }

    /// <summary>
    /// Elimina un elemento específico de la lista gestionada
    /// </summary>
    public void Eliminar(T usuario)
    {
        _total.Remove(usuario);
    }

    /// <summary>
    /// Verifica si un elemento con el email especificado ya se encuentra registrado
    /// </summary>
    /// <param name="email">Correo electrónico a buscar.</param>
    /// <returns><c>true</c> si el email ya está registrado; de lo contrario, <c>false</c>.</returns>
    public bool YaRegistrado(string email)
    {
        foreach (T usuario in _total)
        {
            if (usuario.ObtenerEmail() == email)
            {
                return true;
            }
        }

        return false;
    }
     
    /// <summary>
    /// Crea nuevos vendedores
    /// </summary>
    public void CrearVendedor(string nombre, string apellido, string telefono, string email) 
    {
        Vendedor nuevoVendedor = new Vendedor(nombre, apellido, telefono, email);
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
}