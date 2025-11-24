namespace Library;
/// <summary>
/// Representa un administrador en el sistema
/// </summary>
public class Administrador : Usuario, IGestionable
{
    public Administrador(string nombre, string apellido, string telefono, string email)
        : base(nombre, apellido, telefono, email)
    {
        Singleton<Gestor<Administrador>>.Instance.Agregar(this); // Al crear un administrador lo agrego a la lista global de administradores
    }
   
}