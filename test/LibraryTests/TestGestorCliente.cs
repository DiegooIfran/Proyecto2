namespace Library.Tests;

public class TestGestorCliente
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void AgregarCliente() //Chequea que se agregue un cliente
    {
        GestorCliente gestor = new GestorCliente();
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Assert.That(gestor.VerTotalClientes().Count, Is.EqualTo(1));
        Assert.That(gestor.VerTotalClientes()[0].ObtenerEmail(), Is.EqualTo("jmartin@gmail.com"));
    }
    
    [Test]
    public void EliminarCliente() //Chequea que se elimine un cliente
    {
        GestorCliente gestor = new GestorCliente();
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        gestor.AgregarCliente("Lucia", "Dominguez", "091843289", "lucia@gmail.com", "mujer", new DateTime(1997,10,20));
        gestor.EliminarCliente("lucia@gmail.com");
        Assert.That(gestor.VerTotalClientes().Count, Is.EqualTo(1)); 
    }
    
    [Test]
    public void VerTotalClientes() //Chequea que se incrementa el total de clientes
    {
        GestorCliente gestor = new GestorCliente();
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        gestor.AgregarCliente("Lucia", "Dominguez", "091843289", "lucia@gmail.com", "mujer", new DateTime(1997,10,20));
        List<Cliente> resultado = gestor.VerTotalClientes();
        Assert.That(resultado, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void AsignarCliente() //Chequea que funcione la asignacion de cliente a otro vendedor
    {
        GestorCliente gestor = new GestorCliente();
        gestor.AgregarCliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Vendedor vendedor = new Vendedor("Lucia", "Dominguez", "093213589", "lucia@gmail.com");
        gestor.AsignarCliente(vendedor, gestor.VerTotalClientes()[0]);
        Assert.That(vendedor.ObtenerClientes().Contains(gestor.VerTotalClientes()[0]), Is.True);
    }
}