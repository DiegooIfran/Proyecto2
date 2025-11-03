namespace Library.Tests;

public class TestGestorInteracciones
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void NuevoMensaje() //Chequea que funcione la funcion NuevoMensaje
    {
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        GestorInteracciones.NuevoMensaje(cliente, DateTime.Now, "Tema mensaje", "Notas", true);
        List<Interaccion> interaccionesCliente = cliente.ObtenerInteracciones();
        Assert.That(interaccionesCliente.Count, Is.EqualTo(1));
        Assert.That(interaccionesCliente[0], Is.TypeOf<Mensaje>());
    }
    
    [Test]
    public void NuevaLlamada() //Chequea que funcione la funcion NuevaLlamada
    {
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        GestorInteracciones.NuevaLlamada(cliente, DateTime.Now, "Tema mensaje", "Notas", true);
        List<Interaccion> interaccionesCliente = cliente.ObtenerInteracciones();
        Assert.That(interaccionesCliente.Count, Is.EqualTo(1));
        Assert.That(interaccionesCliente[0], Is.TypeOf<Llamadas>());
    }
    
    [Test]
    public void NuevoCorreo() //Chequea que funcione la funcion NuevoCorreo
    {
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        GestorInteracciones.NuevoCorreo(cliente, DateTime.Now, "Tema mensaje", "Notas", true);
        List<Interaccion> interaccionesCliente = cliente.ObtenerInteracciones();
        Assert.That(interaccionesCliente.Count, Is.EqualTo(1));
        Assert.That(interaccionesCliente[0], Is.TypeOf<Correo>());
    }
    
    [Test]
    public void NuevaReunion() //Chequea que funcione la funcion NuevaReunion
    {
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        GestorInteracciones.NuevaReunion(cliente, DateTime.Now, "Tema mensaje", "Notas");
        List<Interaccion> interaccionesCliente = cliente.ObtenerInteracciones();
        Assert.That(interaccionesCliente.Count, Is.EqualTo(1));
        Assert.That(interaccionesCliente[0], Is.TypeOf<Reunion>());
    }
    
    [Test]
    public void UltimasInteracciones() //Chequea que funcione la funcion UltimasInteracciones
    {
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        for (int i = 0; i < 7; i++)
        {
            GestorInteracciones.NuevoMensaje(cliente, DateTime.Now.AddDays(-i), $"Tema {i}", "Notas", true);
        }
        var ultimas = GestorInteracciones.UltimasInteracciones();
        Assert.That(ultimas.Count, Is.EqualTo(5));
        Assert.That(ultimas[0].Fecha, Is.GreaterThan(ultimas[4].Fecha));
    }

    [Test]
    public void InteraccionesPendientes() //Chequea que funcione la funcion InteraccionesPendientes
    {
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        var msg = new Mensaje(DateTime.Now, "msg", "nota", true);
        msg.Respondida();
        var correo = new Correo(DateTime.Now, "correo", "nota", true);
        cliente.AgregarInteraccion(msg);
        cliente.AgregarInteraccion(correo);
        var field = typeof(GestorInteracciones).GetField("_todasInteracciones",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var lista = (List<Interaccion>)field.GetValue(null);
        lista.Add(msg);
        lista.Add(correo);
        var pendientes = GestorInteracciones.InteraccionesPendientes();
        Assert.That(pendientes.Count, Is.EqualTo(1));
        Assert.That(pendientes[0], Is.TypeOf<Correo>());
    }
}