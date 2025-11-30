namespace Library;

public class GestorAdministrador: Gestor<Administrador>
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

}