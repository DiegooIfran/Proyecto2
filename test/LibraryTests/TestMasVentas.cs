namespace Library.Tests;

public class TestMasVentas
{
    //Voy a implementar todos los testeo de la defensa en este archivo para facilitar la correcion de la defensa, en situaciones normales lo haria en el testeo de la clase correspondiente
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
    public void ObtenerNumeroVentas() //Verifica si se calcula correctamente la cantidad de ventas de un vendedor
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com", ".luty");
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        vendedor.AgregarCliente(cliente);
        
        Venta venta0 = new Venta(new DateTime(2022,12,4), "Comida", "200g de muzzarela", 200);
        Venta venta1 = new Venta(new DateTime(2025,12,4), "Bebida", "CocaCola 3L", 150);
        Venta venta2 = new Venta(new DateTime(2025,8,30), "Galletitas", "Porteñitas", 55);
        
        cliente.AgregarInteraccion(venta2);
        cliente.AgregarInteraccion(venta1);
        cliente.AgregarInteraccion(venta0);
        
        Mensaje msg = new Mensaje(DateTime.Now, "msg", "nota", true);
        Correo correo = new Correo(DateTime.Now, "correo", "nota", true);
        cliente.AgregarInteraccion(msg);
        cliente.AgregarInteraccion(correo);
        
        Assert.That(vendedor.ObtenerNumeroVentas(),Is.EqualTo(3));
    }
    
    [Test]
    public void CalcularBonoVendedor() //Verifica si se calcula correctamente la cantidad de ventas de un vendedor
    {
        Vendedor vendedor = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com", ".luty");
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        vendedor.AgregarCliente(cliente);
        
        Venta venta0 = new Venta(new DateTime(2022,12,4), "Comida", "200g de muzzarela", 200);
        Venta venta1 = new Venta(new DateTime(2025,12,4), "Bebida", "CocaCola 3L", 150);
        Venta venta2 = new Venta(new DateTime(2025,8,30), "Galletitas", "Porteñitas", 55);
        Venta venta3 = new Venta(new DateTime(2025,8,30), "Galletitas", "Porteñitas", 55);
        
        cliente.AgregarInteraccion(venta3);
        cliente.AgregarInteraccion(venta2);
        cliente.AgregarInteraccion(venta1);
        cliente.AgregarInteraccion(venta0);
        
        Mensaje msg = new Mensaje(DateTime.Now, "msg", "nota", true);
        Correo correo = new Correo(DateTime.Now, "correo", "nota", true);
        cliente.AgregarInteraccion(msg);
        cliente.AgregarInteraccion(correo);
        
        Assert.That(vendedor.CalcularBono(),Is.EqualTo(400));
    }
   
    [Test]
    public void VendedorMasVentas() //Verifica si devuelve correctamente el vendedor con mayor cantidad de ventas
    {
        Vendedor vendedor0 = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com", ".luty");
        Cliente cliente0 = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        gv.Agregar(vendedor0);
        vendedor0.AgregarCliente(cliente0);
        
        Vendedor vendedor1 = new Vendedor("Diego", "Ifran", "092773322", "diego.ifran@gmail.com", ".buendia");
        Cliente cliente1 = new Cliente("Ana", "Perez", "092344", "ana@gmail.com","hombre", DateTime.Today);
        gv.Agregar(vendedor1);
        vendedor1.AgregarCliente(cliente1);
        
        Venta venta0 = new Venta(new DateTime(2022,12,4), "Comida", "200g de muzzarela", 200);
        Venta venta1 = new Venta(new DateTime(2025,12,4), "Bebida", "CocaCola 3L", 150);
        Venta venta2 = new Venta(new DateTime(2025,8,30), "Galletitas", "Porteñitas", 55);
        
        cliente0.AgregarInteraccion(venta2);
        cliente0.AgregarInteraccion(venta1);
        cliente0.AgregarInteraccion(venta0);
        
        Mensaje msg = new Mensaje(DateTime.Now, "msg", "nota", true);
        Correo correo = new Correo(DateTime.Now, "correo", "nota", true);
        cliente0.AgregarInteraccion(msg);
        cliente0.AgregarInteraccion(correo);
        
        Venta venta3 = new Venta(new DateTime(2022,12,4), "Comida", "200g de muzzarela", 200);
        Venta venta4 = new Venta(new DateTime(2025,12,4), "Bebida", "CocaCola 3L", 150);
        
        cliente1.AgregarInteraccion(venta3);
        cliente1.AgregarInteraccion(venta4);
        
        Assert.That(gv.VendedorMasVentas(),Is.EqualTo(vendedor0));
    }
    [Test]
    public void CalcularBono() //Verifica si el bono al vendedor con mas ventas se caclula correctamente
    {
        Vendedor vendedor0 = new Vendedor("Lautaro", "Ramirez", "092773311", "lautaro.ramirez@gmail.com", ".luty");
        Cliente cliente0 = new Cliente("Juan", "Perez", "0923", "juan@gmail.com","hombre", DateTime.Today);
        gv.Agregar(vendedor0);
        vendedor0.AgregarCliente(cliente0);
        
        Vendedor vendedor1 = new Vendedor("Diego", "Ifran", "092773322", "diego.ifran@gmail.com", ".buendia");
        Cliente cliente1 = new Cliente("Ana", "Perez", "092344", "ana@gmail.com","hombre", DateTime.Today);
        gv.Agregar(vendedor1);
        vendedor1.AgregarCliente(cliente1);
        
        Venta venta0 = new Venta(new DateTime(2022,12,4), "Comida", "200g de muzzarela", 200);
        Venta venta1 = new Venta(new DateTime(2025,12,4), "Bebida", "CocaCola 3L", 150);
        Venta venta2 = new Venta(new DateTime(2025,8,30), "Galletitas", "Porteñitas", 55);
        
        cliente0.AgregarInteraccion(venta2);
        cliente0.AgregarInteraccion(venta1);
        cliente0.AgregarInteraccion(venta0);
        
        
        Venta venta3 = new Venta(new DateTime(2022,12,4), "Comida", "200g de muzzarela", 200);
        Venta venta4 = new Venta(new DateTime(2025,12,4), "Bebida", "CocaCola 3L", 150);
        
        cliente1.AgregarInteraccion(venta3);
        cliente1.AgregarInteraccion(venta4);

        Vendedor masVentas = gv.VendedorMasVentas();
        Assert.That(masVentas.CalcularBono(),Is.EqualTo(300));
    }
}