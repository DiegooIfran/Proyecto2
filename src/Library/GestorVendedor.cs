using System.Runtime.CompilerServices;

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
    /*public override void Agregar(Vendedor usuario)
    {
        foreach (Vendedor registrado in _total)
        {
            if (registrado.ObtenerEmail()== usuario.ObtenerEmail() || (registrado.ObtenerNick()== usuario.ObtenerNick()))
            {
                throw new AggregateException("El administrador ya está registrada.");
            }
        }
        _total.Add(usuario);
    }*/

    public Vendedor MayorVendedor()
    {
        if (VerTotal().Count != 0)
        {
            Vendedor mayorVendedor = this.VerTotal()[0];
            for (int i = 1; i < this.VerTotal().Count; i++) // Recorro todos los vendedores del singleton los cuales seran todos los del sistema
            {
                if (this.VerTotal()[i].TotalVentas() > mayorVendedor.TotalVentas())
                {
                    mayorVendedor = this.VerTotal()[i]; // Me voy quedando con el vendedor que mas haya vendido
                }
                else if ((this.VerTotal()[i].TotalVentas() == mayorVendedor.TotalVentas()) && (this.VerTotal()[i].NumeroVentas() > mayorVendedor.NumeroVentas()))
                {
                    mayorVendedor = this.VerTotal()[i];
                }
            }
            return mayorVendedor;
        }
        else
        {
            throw new InvalidOperationException("No hay vendedores registrados");
        }
    } 
    // Estoy aplicando el patron Demeter, Dont talk to strangers ya que las clases no se comunican con clases internas de otras si no que cada una implementa su funcion.
    // Siguiendo con la logica el mayorVendedor sera el que mas dinero haya hecho y, en caso de empate, sera el que haya logrado mas cantidad de ventas
    // Agrego el metodo a esta clase ya que contiene a todos los vendedores, pudiendo asi saber cual es el que vendio mas (Experta)
    // A su vez, al haber cumplido con el principio OCP pude agregar las nuevas funciones sin necesidad de modificar lo ya hecho
} 