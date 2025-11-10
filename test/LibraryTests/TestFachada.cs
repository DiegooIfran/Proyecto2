namespace Library.Tests;

public class TestFachada
{
    private Fachada fachada;
    
    [SetUp]
    public void Setup()
    {
        fachada = Fachada.Instance;
    }
    
    [Test]
    public void AgregarYBuscarCliente_DeberiaDevolverElMismoCliente()
    {
        // Arrange
        string email = "test1@mail.com";
        fachada.AgregarCliente("Juan", "Pérez", "099111111", email, "M", new DateTime(1990, 1, 1));

        // Act
        var cliente = fachada.BuscarCliente(email);

        // Assert
        Assert.That(cliente, Is.Not.Null);
        Assert.That(cliente.ObtenerEmail(), Is.EqualTo(email));
        Assert.That(cliente.ObtenerNombre(), Is.EqualTo("Juan"));
    }
    
    [Test]
    public void SuspenderVendedores() // Suspendo a un vendedor
    {
        Administrador admin = new Administrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        admin.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com");
        admin.SuspenderVendedor("fedegarcia@gmail.com");
        Gestor<Vendedor> gestor = Singleton<Gestor<Vendedor>>.Instance;
        Assert.That(gestor.VerTotal()[0].Activo, Is.EqualTo(false));
    }

    [Test]
    public void a()
    {
        
    }
}