namespace Library;
/// <summary>
/// Define el contrato que deben implementar las clases que pueden ser gestionadas por un <see cref="Gestor{T}"/>.
/// </summary>
public interface IGestionable
{
    /// <summary>
    /// Devuelve el correo electrónico asociado al objeto gestionable
    /// </summary>
    public string ObtenerEmail();
}