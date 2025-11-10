namespace Library.Tests;

public class TestGestorCliente
{
    [SetUp]
    public void Setup()
    {
        Singleton<GestorCliente>.Instance.VerTotal().Clear();

    }

    [Test]
    public void TestAgregarCliente()
    {
        // Justificación: comprueba que el método AgregarCliente funciona
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Lautaro", "Ramirez", "092773311", "lautaramirezlopez@gmail.com", "Masculino",
            new DateTime(2007,04,22));

        Assert.That(gestor.VerTotal().Count.Equals(1));
    }
    
    [Test]
    public void TestEliminarCliente()
    {
        // Justificación: comprueba que el método EliminarCliente funciona
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Lautaro", "Ramirez", "092773311", "lautaramirezlopez@gmail.com", "Masculino",
            new DateTime(22 / 04 / 2007));
        gestor.Eliminar(gestor.BuscarPorEmail("lautaramirezlopez@gmail.com"));

        Assert.That(gestor.VerTotal().Count.Equals(0));
    }
    
    [Test]
    public void VerTotalClientes() //Chequea que se incrementa el total de clientes
    {
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        gestor.AgregarCliente("Lucia", "Dominguez", "091843289", "lucia@gmail.com", "mujer", new DateTime(1997,10,20));
        List<Cliente> resultado = gestor.VerTotal();
        Assert.That(resultado, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void AsignarCliente() //Chequea que funcione la asignacion de cliente a otro vendedor
    {
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Vendedor vendedor = new Vendedor("Lucia", "Dominguez", "093213589", "lucia@gmail.com");
        gestor.AsignarCliente(vendedor, gestor.VerTotal()[0]);
        Assert.That(vendedor.ObtenerClientes().Contains(gestor.VerTotal()[0]), Is.True);
    }
    
    [Test]
    public void ModificarNombre()
    {
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com", "hombre", DateTime.Today);
        gestor.ModificarNombre("Carlos", cliente);
        Assert.AreEqual("Carlos", cliente.ObtenerNombre());
    }

    [Test]
    public void ModificarApellido_CambiaApellidoDelCliente()
    {
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com", "hombre", DateTime.Today);
        gestor.ModificarApellido("Gomez", cliente);
        Assert.AreEqual("Gomez", cliente.ObtenerApellido());
    }

    [Test]
    public void ModificarTelefono_CambiaTelefonoDelCliente()
    {
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com", "hombre", DateTime.Today);
        gestor.ModificarTelefono("123", cliente);
        Assert.AreEqual("123", cliente.ObtenerTelefono());
    }

    [Test]
    public void ModificarEmail_CambiaEmailDelCliente()
    {
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        Cliente cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com", "hombre", DateTime.Today);
        gestor.ModificarEmail("carlos@gmail.com", cliente);
        Assert.AreEqual("carlos@gmail.com", cliente.ObtenerEmail());
    }
    [Test]
    public void TestBuscarPorNombre()
    {
        // Justificación: comprueba que el método BuscarPorNombre funciona
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        gestor.AgregarCliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = gestor.VerTotal();
        Cliente cliente1 = listaClientes[0];
        Cliente cliente2 = listaClientes[1];
        Assert.That(gestor.BuscarPorNombre("Juan"), Is.EqualTo(cliente1));
        Assert.That(gestor.BuscarPorNombre("Ana"), Is.EqualTo(cliente2));
    }
    [Test]
    public void TestBuscarPorApellido()
    {
        // Justificación: comprueba que el método BuscarPorApellido funciona
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        gestor.AgregarCliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = gestor.VerTotal();
        Cliente cliente1 = listaClientes[0];
        Cliente cliente2 = listaClientes[1];
        Assert.That(gestor.BuscarPorApellido("Martinez"), Is.EqualTo(cliente1));
        Assert.That(gestor.BuscarPorApellido("Romero"), Is.EqualTo(cliente2));
    }
    [Test]
    public void TestBuscarPorTelefono()
    {
        // Justificación: comprueba que el método BuscarPorTelefono funciona
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        gestor.AgregarCliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = gestor.VerTotal();
        Cliente cliente1 = listaClientes[0];
        Cliente cliente2 = listaClientes[1];
        Assert.That(gestor.BuscarPorTelefono("091827989"), Is.EqualTo(cliente1));
        Assert.That(gestor.BuscarPorTelefono("091222982"), Is.EqualTo(cliente2));
    }
    [Test]
    public void TestBuscarPorMail()
    {
        // Justificación: comprueba que el método BuscarPorEmail funciona
        GestorCliente gestor = Singleton<GestorCliente>.Instance;
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        gestor.AgregarCliente("Ana", "Romero", "091222982", "anaromeroo@gmail.com", "mujer", new DateTime(1994,4,20));
        List<Cliente> listaClientes = gestor.VerTotal();
        Cliente cliente1 = listaClientes[0];
        Cliente cliente2 = listaClientes[1];
        Assert.That(gestor.BuscarPorEmail("jmartin@gmail.com"), Is.EqualTo(cliente1));
        Assert.That(gestor.BuscarPorEmail("anaromeroo@gmail.com"), Is.EqualTo(cliente2));
    }
}