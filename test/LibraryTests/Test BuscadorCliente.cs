namespace Library.Tests;

public class TestBuscadorCliente
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestBuscarPorNombre()
    {
        // Justificación: comprueba que el método BuscarPorNombre funciona
        Cliente cliente1 = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Cliente cliente2 = new Cliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = new List<Cliente>();
        listaClientes.Add(cliente1);
        listaClientes.Add(cliente2);
        Assert.That(BuscadorCliente.BuscarPorNombre("Juan",listaClientes), Is.EqualTo(cliente1));
        Assert.That(BuscadorCliente.BuscarPorNombre("Ana",listaClientes), Is.EqualTo(cliente2));
    }
    [Test]
    public void TestBuscarPorApellido()
    {
        // Justificación: comprueba que el método BuscarPorApellido funciona
        Cliente cliente1 = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Cliente cliente2 = new Cliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = new List<Cliente>();
        listaClientes.Add(cliente1);
        listaClientes.Add(cliente2);
        Assert.That(BuscadorCliente.BuscarPorApellido("Martinez",listaClientes), Is.EqualTo(cliente1));
        Assert.That(BuscadorCliente.BuscarPorApellido("Romero",listaClientes), Is.EqualTo(cliente2));
    }
    [Test]
    public void TestBuscarPorTelefono()
    {
        // Justificación: comprueba que el método BuscarPorTelefono funciona
        Cliente cliente1 = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Cliente cliente2 = new Cliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = new List<Cliente>();
        listaClientes.Add(cliente1);
        listaClientes.Add(cliente2);
        Assert.That(BuscadorCliente.BuscarPorTelefono("091827989",listaClientes), Is.EqualTo(cliente1));
        Assert.That(BuscadorCliente.BuscarPorTelefono("091222982",listaClientes), Is.EqualTo(cliente2));
    }
    [Test]
    public void TestBuscarPorMail()
    {
        // Justificación: comprueba que el método BuscarPorEmail funciona
        Cliente cliente1 = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Cliente cliente2 = new Cliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = new List<Cliente>();
        listaClientes.Add(cliente1);
        listaClientes.Add(cliente2);
        Assert.That(BuscadorCliente.BuscarPorEmail("jmartin@gmail.com",listaClientes), Is.EqualTo(cliente1));
        Assert.That(BuscadorCliente.BuscarPorEmail("anaromeroo@gmail.com",listaClientes), Is.EqualTo(cliente2));
    }
}