namespace Library.Tests;

public class TesteosDefensa
{
    
    Fachada fachada = Singleton<Fachada>.Instance;
    private GestorVendedor gv = Singleton<GestorVendedor>.Instance;
    
    [SetUp]
    public void Setup()
    {
        Singleton<GestorCliente>.Instance.VerTotal().Clear();
        Singleton<GestorVendedor>.Instance.VerTotal().Clear();
    }
    
    
    [Test]
    public void GastosCalculaBien()
    {
        fachada.AgregarCliente("John", "Doe", "01313", "cliente1@gmail.com", "hombre", DateTime.Now);
        fachada.CrearVendedor("Lautaro", "Ramirez", "092313", "lautaramirez@gmail.com", ".luty");
        fachada.AsignarCliente(".luty", "cliente1@gmail.com");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Laptop", "Nueva", 1500);
        fachada.RealizarVenta("cliente1@gmail.com", "Laptop");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Auto", "usado", 500);
        fachada.RealizarVenta("cliente1@gmail.com", "Auto");
        
        // En 2 ventas gasto 2000
        
        Assert.That(fachada.BuscarPorEmail("cliente1@gmail.com").Gastos(), Is.EqualTo(2000));
        Assert.That(fachada.BuscarPorEmail("cliente1@gmail.com").VentasCerradas(), Is.EqualTo(2));
    }
    
    [Test]
    public void TotalVentasCalculaBien()
    {
        fachada.AgregarCliente("John", "Doe", "01313", "cliente1@gmail.com", "hombre", DateTime.Now);
        fachada.CrearVendedor("Lautaro", "Ramirez", "092313", "lautaramirez@gmail.com", ".luty");
        fachada.AsignarCliente(".luty", "cliente1@gmail.com");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Laptop", "Nueva", 1500);
        fachada.RealizarVenta("cliente1@gmail.com", "Laptop");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Auto", "usado", 500);
        fachada.RealizarVenta("cliente1@gmail.com", "Auto");
        
        // En 2 ventas obtuvo 2000 
        
        Assert.That(fachada.BuscarVendedorNick(".luty").TotalVentas(), Is.EqualTo(2000));
        Assert.That(fachada.BuscarVendedorNick(".luty").NumeroVentas(), Is.EqualTo(2));

    }
    
    [Test]
    public void MayorVendedorCalculaBien()
    {
        fachada.AgregarCliente("John", "Doe", "01313", "cliente1@gmail.com", "hombre", DateTime.Now);
        fachada.CrearVendedor("Lautaro", "Ramirez", "092313", "lautaramirez@gmail.com", ".luty");
        fachada.AsignarCliente(".luty", "cliente1@gmail.com");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Laptop", "Nueva", 1500);
        fachada.RealizarVenta("cliente1@gmail.com", "Laptop");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Auto", "usado", 500);
        fachada.RealizarVenta("cliente1@gmail.com", "Auto"); 
        // Total de ventas = 2000
        
        fachada.AgregarCliente("John", "Doe", "01313", "cliente2@gmail.com", "hombre", DateTime.Now);
        fachada.CrearVendedor("Lautaro", "Ramirez", "092313", "lautaramirez2@gmail.com", ".luty2");
        fachada.AsignarCliente(".luty2", "cliente2@gmail.com");
        fachada.RealizarCotizacion(".luty2", "cliente2@gmail.com", DateTime.Now, "Avion", "Blanco", 6000);
        fachada.RealizarVenta("cliente2@gmail.com", "Avion");
        // Total de ventas = 6000
        
        fachada.AgregarCliente("John", "Doe", "01313", "cliente3@gmail.com", "hombre", DateTime.Now);
        fachada.CrearVendedor("Lautaro", "Ramirez", "092313", "lautaramirez3@gmail.com", ".luty3");
        fachada.AsignarCliente(".luty3", "cliente3@gmail.com");
        fachada.RealizarCotizacion(".luty3", "cliente3@gmail.com", DateTime.Now, "Casa", "Vieja", 10000);
        fachada.RealizarVenta("cliente3@gmail.com", "Casa");
        // Total de ventas = 10000
        
        // El 3er vendedor fue el que mas vendio con un total de 10000
        
        Assert.That(gv.MayorVendedor(), Is.EqualTo(fachada.BuscarVendedorNick(".luty3")));
        Assert.That(fachada.MejorVendedor(), Is.EqualTo(fachada.BuscarVendedorNick(".luty3")));
    }

    [Test]
    public void DosVendedoresIgualesVentas()
    {
        fachada.AgregarCliente("John", "Doe", "01313", "cliente2@gmail.com", "hombre", DateTime.Now);
        fachada.CrearVendedor("Lautaro", "Ramirez", "092313", "lautaramirez2@gmail.com", ".luty2");
        fachada.AsignarCliente(".luty2", "cliente2@gmail.com");
        fachada.RealizarCotizacion(".luty2", "cliente2@gmail.com", DateTime.Now, "Avion", "Blanco", 2000);
        fachada.RealizarVenta("cliente2@gmail.com", "Avion");
        // Total de ventas = 2000 
        // 1 venta
        
        fachada.AgregarCliente("John", "Doe", "01313", "cliente1@gmail.com", "hombre", DateTime.Now);
        fachada.CrearVendedor("Lautaro", "Ramirez", "092313", "lautaramirez@gmail.com", ".luty");
        fachada.AsignarCliente(".luty", "cliente1@gmail.com");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Laptop", "Nueva", 1500);
        fachada.RealizarVenta("cliente1@gmail.com", "Laptop");
        fachada.RealizarCotizacion(".luty", "cliente1@gmail.com", DateTime.Now, "Auto", "usado", 500);
        fachada.RealizarVenta("cliente1@gmail.com", "Auto");
        // Total de ventas = 2000
        // 2 ventas
        
        // Ambos vendedores vendieron lo mismo sin embargo el segundo cerro mas ventas

        Assert.That(fachada.MejorVendedor(), Is.EqualTo(fachada.BuscarVendedorNick(".luty")));
    }
}