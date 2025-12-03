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
           
            gv.CrearVendedor("Federico", "Garcia", "2312", "fedegarcia@gmail.com", "luty");
            gv.EliminarVendedor("fedegarcia@gmail.com");
            
            Assert.That(gv.VerTotal(), Is.Empty);
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
    
    [Test]
    public void VendedorConMaxVentas() //Testeo el método "VendedorConMaxVentas()"
    {
        //Creo vendedores
        fachada.CrearVendedor("Federico", "Garcia", "231231", "fedegarcia@gmail.com", "luty"); 
        fachada.CrearVendedor("Vende", "Dor", "09154321", "email1@gmail.com", "vende");
        
        //Creo clientes y los asigno a cada vendedor
        fachada.AgregarCliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        fachada.AgregarCliente("Diego", "Ifran", "091111123", "prueba1@gmail.com", "H", new DateTime(2003, 3, 3));
        fachada.AsignarCliente("luty", "juan@gmail.com");
        fachada.AsignarCliente("vende", "prueba1@gmail.com");
        
        //Asigno ventas a cada cliente
        fachada.RealizarCotizacion("vende", "prueba1@gmail.com", DateTime.Today, "b1", "hola", 100);
        fachada.RealizarCotizacion("vende", "prueba1@gmail.com", DateTime.Today, "b2", "hola", 100);
        fachada.RealizarVenta("prueba1@gmail.com", "b1");
        fachada.RealizarVenta("prueba1@gmail.com", "b2");
        fachada.RealizarCotizacion("luty", "juan@gmail.com", DateTime.Today, "c1", "hola", 100);
        fachada.RealizarVenta("juan@gmail.com", "c1");
        
        //Pruebo gv.VendedorConMaxVentas
        Vendedor maxVentas = gv.VendedorConMaxVentas();
        
        //Chequeo que maxVentas sea el resultado esperado "vende"
        Assert.That(maxVentas, Is.EqualTo(fachada.BuscarVendedorNick("vende")));
    }
}