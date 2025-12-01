using System.ComponentModel;

namespace Library.Tests;

public class TestAdministrador
{
    Fachada fachada = Singleton<Fachada>.Instance;
    private GestorVendedor gv = Singleton<GestorVendedor>.Instance;
    private GestorAdministrador ga = Singleton<GestorAdministrador>.Instance;
    
    [SetUp]
    public void Setup()
    {
        Singleton<GestorAdministrador>.Instance.VerTotal().Clear();
        Singleton<GestorVendedor>.Instance.VerTotal().Clear();
    }
    
    [Test]
    public void CrearVendedores() // Que un admin cree un vendedor y lo almacene
    {
        fachada.CrearAdministrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com", "lauta");
        fachada.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty");
        Assert.AreEqual(1, gv.VerTotal().Count);
        Assert.AreEqual("Federico", gv.VerTotal()[0].ObtenerNombre());
    }
    
    [Test]
    public void SuspenderVendedores() // Suspendo a un vendedor
    {
        fachada.CrearAdministrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com", "lauta");
        fachada.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty");
        fachada.SuspenderUsuario("fedegarcia@gmail.com");
        Assert.That(gv.VerTotal()[0].Activo, Is.EqualTo(false));
    }
    
    [Test]
    public void EliminarVendedores() // Elimino a un vendedor
    {
        
        fachada.CrearAdministrador("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com", "lauta");
        fachada.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty");
        fachada.EliminarVendedor("fedegarcia@gmail.com");
        Assert.AreEqual(0, gv.VerTotal().Count);
    }
}