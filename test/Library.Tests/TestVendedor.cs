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
        Etiqueta etiqueta = GestorEtiquetas.CrearEtiqueta("Mayor", "Sos mayor");
        GestorEtiquetas.AgregarEtiqueta(mayor, etiqueta);
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
        
        vendedor.NuevaCotizacion(cliente, 123, "pelota");
        
        Assert.That(cliente.ObtenerCotizaciones().Count, Is.EqualTo(1));
    }
    
    [Test]
    public void TotalVentas()
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        vendedor.AgregarCliente(cliente);
        
        vendedor.NuevaCotizacion(cliente, 123, "pelota");
        vendedor.NuevaCotizacion(cliente, 300, "guantes");
        vendedor.NuevaCotizacion(cliente, 541, "arco");
        
        cliente.ObtenerCotizaciones()[0].CerrarVenta();
        cliente.ObtenerCotizaciones()[1].CerrarVenta();
        cliente.ObtenerCotizaciones()[2].CerrarVenta();
        
        Assert.That(cliente.ObtenerCompras().Count, Is.EqualTo(3));
    }

}