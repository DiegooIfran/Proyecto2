namespace Library.Tests;

public class TestFachada
{
    [SetUp]
    public void Setup()
    {
        Singleton<Gestor<Administrador>>.Instance.VerTotal().Clear();
        Singleton<Gestor<Vendedor>>.Instance.VerTotal().Clear();
    }
    
    [Test]
    public void CrearVendedores() // Que un admin cree un vendedor y lo almacene
    {
        Gestor<Vendedor> gestor = Singleton<Gestor<Vendedor>>.Instance;
        Administrador admin = new Administrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        admin.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com");
        Assert.AreEqual(1, gestor.VerTotal().Count);
        Assert.AreEqual("Federico", gestor.VerTotal()[0].ObtenerNombre());
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
    public void EliminarVendedores() // Elimino a un vendedor
    {
        Gestor<Vendedor> gestor = Singleton<Gestor<Vendedor>>.Instance;
        Administrador admin = new Administrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        admin.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com");
        admin.EliminarVendedor("fedegarcia@gmail.com");
        Assert.AreEqual(0, gestor.VerTotal().Count);
    }
}