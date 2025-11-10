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
    
    [Test]
    public void TotalVentas()
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com");
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        vendedor.AgregarCliente(cliente);
        
        Venta venta0 = new Venta(new DateTime(2022,12,4), "Comida", "200g de muzzarela", 200);
        Venta venta1 = new Venta(new DateTime(2025,12,4), "Bebida", "CocaCola 3L", 150);
        Venta venta2 = new Venta(new DateTime(2025,8,30), "Galletitas", "Porteñitas", 55);
        cliente.AgregarInteraccion(venta2);
        cliente.AgregarInteraccion(venta1);
        cliente.AgregarInteraccion(venta0);
        
        Assert.That(vendedor.TotalVentas(new DateTime(2024, 5, 11),new DateTime(2026, 5, 12)), Is.EqualTo($"Lista de todas las ventas:\n- Juan Perez compró Porteñitas por $55 el 30/8/2025 0:00:00\n- Juan Perez compró CocaCola 3L por $150 el 4/12/2025 0:00:00\n"));
        Console.WriteLine(vendedor.TotalVentas(new DateTime(2024, 5, 11),new DateTime(2026, 5, 12)));
    }

}