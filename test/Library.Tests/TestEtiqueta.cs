namespace Library.Tests;

public class TestsEtiquta
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCrearEtiqueta()
    {
        // Justificación: comprueba que el constructor de Etiquetas guarda correctamente la información
        Etiqueta etiqueta = new Etiqueta("Padre", "Este cliente tiene un hijo, le pueden interesar productos para niños chicos.");
        Assert.That(etiqueta.Nombre, Is.EqualTo("Padre"));
        Assert.That(etiqueta.Descripcion, Is.EqualTo("Este cliente tiene un hijo, le pueden interesar productos para niños chicos."));
    
    }
}