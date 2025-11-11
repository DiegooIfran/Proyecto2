namespace Library;
/// <summary>
/// Define el contrato que deben implementar las clases que pueden ser gestionadas por un <see cref="Gestor{T}"/>.
/// </summary>

public interface IGestionable
{
    public string ObtenerEmail();
}