namespace Library;

public class GestorEtiquetas<T> : ISingleton where T : Etiqueta
{
    /// <summary>
    /// Lista que contiene todas las etiquetas
    ///  SRP:Su única responsabilidad es administrar etiquetas (crearlas, buscarlas y asignarlas).
    /// Creator: El gestor conoce la colección de etiquetas, por lo tanto es quien debe crearlas.
    /// </summary>
    private List<Etiqueta> _etiquetas = new List<Etiqueta>();
    
    /// <summary>
    /// Crea una nueva etiqueta con su nombre y descripción y la añade a una lista
    /// </summary>
    /// <param name="nombre"></param>
    /// <param name="descripcion"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void CrearEtiqueta(string nombre, string descripcion)
    {
        Etiqueta etiqueta = new Etiqueta(nombre, descripcion);
        _etiquetas.Add(etiqueta);
    }
    
    /// <summary>
    /// Asocia una etiqueta a un cliente
    /// </summary>
    /// <param name="cliente"></param>
    /// <param name="etiqueta"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void AgregarEtiqueta(Cliente cliente, Etiqueta etiqueta) //REVISAR A A A A A A A A 
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        cliente.ObtenerEtiquetas().Add(etiqueta);
        this._etiquetas.Add(etiqueta);
    }

    /// <summary>
    /// Devuelve la lista completa de elementos gestionados
    /// </summary>
    public List<Etiqueta> VerEtiquetas()
    {
        return _etiquetas;
    }

    public Etiqueta RetornarEtiqueta(string nombre) //NO ESTA BIEN, FALTAN EXCEPCIONES
    {
        foreach (Etiqueta etiqueta in _etiquetas)
        {
            if (etiqueta.Nombre == nombre)
            {
                return etiqueta;
            }
        }
        return null;
    }

    /// <summary>
    /// Elimina una etiqueta de un cliente si ya la tiene
    /// </summary>
    /// <param name="cliente"></param>
    /// <param name="etiqueta"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void BorrarEtiqueta(Cliente cliente, Etiqueta etiqueta)
    {
        if (cliente == null) //Valida que el cliente no sea nulo
        {
            throw new ArgumentNullException(nameof(cliente));
        }
        if (etiqueta == null) //Valida que el etiqueta no sea nulo
        {
            throw new ArgumentNullException(nameof(etiqueta));
        }
        if (cliente.ObtenerEtiquetas().Contains(etiqueta))
        {
            cliente.ObtenerEtiquetas().Remove(etiqueta);
        }
    }
}