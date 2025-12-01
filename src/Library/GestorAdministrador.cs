namespace Library;

public class GestorAdministrador : Gestor<Administrador>, ISingleton
{ 
    /// <summary>
    /// SRP: La responsabilidad de esta clase es únicamente gestionar administradores
    /// </summary>
    public Administrador BuscarPorNick(string nick)
    {
        foreach (Administrador administrador in this.VerTotal())
        {
            if (nick == administrador.ObtenerNick())
            {
                return administrador;
            }
        }
        
        throw new InvalidOperationException("No se encontró ningún usuario con ese nombre.");
    }

    public void CrearAdministrador(string nombre, string apellido, string telefono, string email, string nickname) 
    {
        Administrador nuevoAdministrador = new Administrador(nombre, apellido, telefono, email, nickname);
        this.Agregar(nuevoAdministrador);
    }
}