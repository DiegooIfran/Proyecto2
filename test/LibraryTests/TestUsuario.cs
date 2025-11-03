namespace Library.Tests;

public class TestUsuario
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Heredar() // Verifico que efectivamente hereden los atributos
    {
        var vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");

        Assert.AreEqual("Lautaro", vendedor.ObtenerNombre());
        Assert.AreEqual("Ramirez", vendedor.ObtenerApellido());
        Assert.AreEqual("lautaro.ramirez@gmail.com", vendedor.ObtenerEmail());
        Assert.AreEqual("092773311", vendedor.ObtenerTelefono());
    }

    [Test]
    public void InstanciasDe() // Verifico que administrador y vendedor sean instancias de usuario
    {
        Usuario administrador = new Administrador("Carlos", "Diaz", "3213138", "carlosdiaz@gmail.com");
        Assert.IsInstanceOf<Usuario>(administrador);
        
        Usuario vendedor= new Vendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com");
        Assert.IsInstanceOf<Usuario>(vendedor);
    }

}