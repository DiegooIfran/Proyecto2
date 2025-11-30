namespace Library;
/// <summary>
/// Representa un administrador en el sistema
/// </summary>
public class Administrador : Usuario, IPersona
{
    public Administrador(string nombre, string apellido, string telefono, string email, string nickname)
        : base(nombre, apellido, telefono, email, nickname)
    {
        Singleton<Gestor<Administrador>>.Instance.Agregar(this); // Al crear un administrador lo agrego a la lista global de administradores
    }
    
    /// <summary>
    /// Elimina un vendedor del sistema
    /// </summary>
    /// <param name="vendedor">El vendedor a eliminar</param>
    /// <exception cref="ArgumentNullException">Si el vendedor es nulo</exception>
    public void EliminarVendedor(Vendedor vendedor)
    {
        if (vendedor == null)
        {
            throw new ArgumentNullException(nameof(vendedor));
        }

        Singleton<Gestor<Vendedor>>.Instance.Eliminar(vendedor);
    }
}