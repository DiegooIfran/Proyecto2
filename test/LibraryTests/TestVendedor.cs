using System.Runtime.InteropServices.JavaScript;
namespace Library.Tests;

public class TestVendedor
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void FestejarCumpleanos()
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        Cliente cumpleaniero = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        Cliente otro = new Cliente("Carlos", "Diaz", "09232", "carlos@gmail.com","hombre", DateTime.Today.AddDays(2));
        vendedor.AgregarCliente(cumpleaniero);
        vendedor.AgregarCliente(otro);

        vendedor.FestejarCumpleanos();

        Assert.That(cumpleaniero.ObtenerInteracciones().Count, Is.EqualTo(1));
        Assert.That(otro.ObtenerInteracciones().Count, Is.EqualTo(0));
    }
    
    [Test]
    public void Campana()
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        Cliente mayor = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        Cliente otro = new Cliente("Carlos", "Diaz", "09232", "carlos@gmail.com","hombre", DateTime.Today.AddDays(2));
        vendedor.AgregarCliente(mayor);
        vendedor.AgregarCliente(otro);
        Etiqueta etiqueta = new Etiqueta("Mayor", "Sos mayor");
        etiqueta.AgregarEtiqueta(mayor);
        vendedor.Campana(etiqueta, "Sos mayor de edad!");

        Assert.That(mayor.ObtenerInteracciones().Count, Is.EqualTo(1));
        Assert.That(otro.ObtenerInteracciones().Count, Is.EqualTo(0));
    }
    
    [Test]
    public void Cotizacion()
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        vendedor.AgregarCliente(cliente);
        
        vendedor.NuevaCotizacion(DateTime.Today,"Pelotas","Comprar 10 pelotas", cliente, 5000);
        
        Assert.That(cliente.ObtenerInteracciones().Count, Is.EqualTo(1));
    }
    /*
    [Test]
    public void TotalVentas()
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        vendedor.AgregarCliente(cliente);
        
        vendedor.NuevaCotizacion(DateTime.Today,"Pelotas","Comprar 10 pelotas", cliente, 5000);
        vendedor.NuevaCotizacion(DateTime.Today,"Guantes","Comprar 2 pares de guantes", cliente, 1000);
        vendedor.NuevaCotizacion(DateTime.Today,"Arcos","Comprar 2 arcos", cliente, 3000);

        Cotizacion interaccion0 = cliente.ObtenerInteracciones()[0];
        var interaccion1 = cliente.ObtenerInteracciones()[1];
        var interaccion2 = cliente.ObtenerInteracciones()[2];
        
        Assert.That(cliente.ObtenerInteracciones().Count, Is.EqualTo(3));
    }*/

}