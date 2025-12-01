namespace Library.Tests;

public class TestGestorVendedor
{
    Fachada fachada = Singleton<Fachada>.Instance;
    private GestorVendedor gv = Singleton<GestorVendedor>.Instance;
    private GestorAdministrador ga = Singleton<GestorAdministrador>.Instance;
    private GestorCliente gc = Singleton<GestorCliente>.Instance;
    
    [SetUp]
    public void Setup()
    {
        Singleton<GestorCliente>.Instance.VerTotal().Clear();
        Singleton<GestorAdministrador>.Instance.VerTotal().Clear();
        Singleton<GestorVendedor>.Instance.VerTotal().Clear();
    }

    [Test]
    public void TestCrearVendedor()
    {
        // Justificación: comprueba que el método crearVendedor funciona
        gv.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty");

        Assert.That(gv.VerTotal().Count.Equals(1));
    }
    
    [Test]
    public void TestEliminarVendedor()
    {
        // Justificación: comprueba que el método EliminarVendedor funciona
        gv.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty"); 
        gv.EliminarVendedor("fedegarcia@gmail.com");

        Assert.That(gv.VerTotal().Count.Equals(0));
    }
    
    [Test]
    public void SuspenderVendedor() //Chequea que funcione la suspension de vendedor
    {
        gv.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty"); 
        gv.SuspenderVendedor("fedegarcia@gmail.com");
        Assert.That(gv.VerTotal()[0].Activo, Is.False);
    }
    
    [Test]
    public void HabilitarVendedor()
    {
        gv.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty"); 
        gv.SuspenderVendedor("fedegarcia@gmail.com");
        Assert.That(gv.VerTotal()[0].Activo, Is.False);
        gv.HabilitarVendedor("fedegarcia@gmail.com");
        Assert.That(gv.VerTotal()[0].Activo, Is.True);
    }
}