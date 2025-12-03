namespace Library;
/// <summary>
/// Representa un administrador en el sistema
/// Aplica el principio SRP: esta clase solo gestiona acciones del Administrador.
/// </summary>
public class Administrador : Usuario, IPersona
{
    public Administrador(string nombre, string apellido, string telefono, string email, string nickname)
        : base(nombre, apellido, telefono, email, nickname)
    {
        Singleton<Gestor<Administrador>>.Instance.Agregar(this); // Al crear un administrador lo agrego a la lista global de administradores
    }
    
    public List<Vendedor> ObtenerVendedores(Vendedor vendedor) //Obtener vendedores
    { 
        return this.Vendedores;
    }
    
    // Obtener la cantidad de ventas de un vendedor concreto
    public virtual int ObtenerCantidadDeVentas(Vendedor vendedor)
    {
        if (vendedor == null)
        {
            throw new ArgumentNullException(nameof(vendedor));
        }
        
        var ventas = gi.ObtenerVentasPorVendedor(vendedor);
        return ventas?.Count ?? 0;
    }
    
    /// <summary>
    /// Devuelve el vendedor con mayor cantidad de ventas realizadas
    /// Si no hay vendedores devuelve null
    /// </summary>
    public Vendedor ObtenerVendedorConMasVentas()
    {
        Vendedor vendedorConMasVentas = null;
        int maxVentas = -1;

        foreach (var vendedor in this.Vendedores)
        {
            int ventasActuales = ObtenerCantidadDeVentas(vendedor);
            if (ventasActuales > maxVentas)
            {
                maxVentas = ventasActuales;
                vendedorConMasVentas = vendedor;
            }
        }

        return vendedorConMasVentas;
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
