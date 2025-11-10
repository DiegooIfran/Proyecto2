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
}