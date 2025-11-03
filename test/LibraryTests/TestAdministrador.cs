namespace Library.Tests;

public class TestAdministrador
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void CrearVendedores() // Que un admin cree un vendedor y lo almacene
    {
        Administrador admin = new Administrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        admin.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com");

        Assert.AreEqual(1, admin.ObtenerVendedores().Count);
        Assert.AreEqual("Federico", admin.ObtenerVendedores()[0].ObtenerNombre());
    }
    
    [Test]
    public void SuspenderVendedores() // Suspendo a un vendedor
    {
        Administrador admin = new Administrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        admin.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com");
        admin.SuspenderVendedor("fedegarcia@gmail.com");
        
        Assert.That(admin.ObtenerVendedores()[0].Activo, Is.EqualTo(false));
    }
    
    [Test]
    public void EliminarVendedores() // Elimino a un vendedor
    {
        Administrador admin = new Administrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        admin.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com");
        admin.EliminarVendedor("fedegarcia@gmail.com");
        
        Assert.AreEqual(0, admin.ObtenerVendedores().Count);
    }
}