namespace Library.Tests;

public class TestsCliente
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestConstructor()
    {
        // Justificación: comprueba que el constructor asigne correctamente el valor de los atributos del cliente y que las listas estén vacías
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990,10,20));
        Assert.That(cliente.ObtenerNombre(), Is.EqualTo("Juan"));
        Assert.That(cliente.ObtenerApellido(), Is.EqualTo("Martinez"));
        Assert.That(cliente.ObtenerTelefono(), Is.EqualTo("091827989"));
        Assert.That(cliente.ObtenerEmail(), Is.EqualTo("jmartin@gmail.com"));
        Assert.That(cliente.ObtenerGenero(), Is.EqualTo("hombre"));
        Assert.That(cliente.ObtenerFechaNacimiento(), Is.EqualTo(new DateTime(1990,10,20)));
        Assert.That(cliente.ObtenerEtiquetas(), Is.Empty);
        Assert.That(cliente.ObtenerInteracciones(), Is.Empty);
        Assert.That(cliente.ObtenerCompras(), Is.Empty);
        Assert.That(cliente.ObtenerCotizaciones(), Is.Empty);
    }

    [Test]
    public void TestUltimaInterracion()
    {
        // Justificación: comprueba que el método ÚltimaInterración devuelva la última interración que realizó el cliente
        Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre",
            new DateTime(1990, 10, 20));
        GestorInteracciones.NuevoMensaje(cliente, new DateTime(2025, 10, 17), "Consulta Disponibilidad",
            "Esta interesado en la compro de un mueble", false);
        GestorInteracciones.NuevoMensaje(cliente,new DateTime(2024, 9, 29), "Actualización estado de la compra",
           "El producto fue enviado", true);
        GestorInteracciones.NuevaReunion(cliente,new DateTime(2025, 11, 22), "Mostrar productos",
            "Quiere ver la calidad de los muebles");
        Assert.That(cliente.UltimaInteraccion(), Is.EqualTo(cliente.ObtenerInteracciones()[0]));
    }
}