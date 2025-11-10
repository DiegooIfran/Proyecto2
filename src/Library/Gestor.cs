namespace Library;

public class Gestor<T> where T : IGestionable
{
    private List<T> _total = new List<T>(); //Hago la lista que contendra administradores o vendedores 
    
    public void Agregar(T usuario)
    {
        _total.Add(usuario);
    }

    public List<T> VerTotal()
    {
        return _total;
    }

    public void Eliminar(T usuario)
    {
        _total.Remove(usuario);
    }

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

// Deberia haber solo 1 GestorAdministrador y 1 GestorVendedor por ende empleamos Singleton para hacer que solamente 
// pueda existir 1 instancia de estos y ella contenga la lista y las funciones que deberia hacer