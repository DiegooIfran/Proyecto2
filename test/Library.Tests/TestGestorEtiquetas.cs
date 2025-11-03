namespace Library.Tests;

public class TestGestorEtiquetas
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCrearEtiqueta()
    {
        // Justificación: comprueba que el método CrearEtiqueta del Gestor funcione correctamente
        Etiqueta etiqueta = new Etiqueta("Padre", "Este cliente tiene un hijo, le pueden interesar productos para niños chicos.");
        Etiqueta etiquetaConGestor = GestorEtiquetas.CrearEtiqueta("Padre", "Este cliente tiene un hijo, le pueden interesar productos para niños chicos.");
        Assert.That(etiqueta.Nombre, Is.EqualTo(etiquetaConGestor.Nombre));
        Assert.That(etiqueta.Descripcion, Is.EqualTo(etiquetaConGestor.Descripcion));
    }
    [Test]
    public void AgregarEtiqueta()
    {
        // Justificación: comprueba que el método AgregarEtiqueta del Gestor funcione correctamente
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Etiqueta etiqueta = GestorEtiquetas.CrearEtiqueta("Padre", "Este cliente tiene un hijo, le pueden interesar productos para niños chicos.");
        GestorEtiquetas.AgregarEtiqueta(cliente, etiqueta);
        Assert.That(cliente.ObtenerEtiquetas(), Does.Contain(etiqueta));
    }   
    [Test]
    public void BorrarEtiqueta()
    {
        // Justificación: comprueba que el método BorrarEtiqueta del Gestor funcione correctamente
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Etiqueta etiqueta = GestorEtiquetas.CrearEtiqueta("Padre", "Este cliente tiene un hijo, le pueden interesar productos para niños chicos.");
        GestorEtiquetas.AgregarEtiqueta(cliente, etiqueta);
        GestorEtiquetas.BorrarEtiqueta(cliente,etiqueta);
        Assert.That(cliente.ObtenerEtiquetas(), Does.Not.Contain(etiqueta));
    }   
}