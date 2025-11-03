namespace Library.Tests;

public class TestModificadorCliente
{
    private Cliente cliente;

    [SetUp]
    public void Setup()
    {
        cliente = new Cliente("Juan", "Perez", "0923", "juan@gmail.com", "hombre", DateTime.Today);
    }

    [Test]
    public void ModificarNombre()
    {
        ModificadorCliente.ModificarNombre("Carlos", cliente);
        Assert.AreEqual("Carlos", cliente.ObtenerNombre());
    }

    [Test]
    public void ModificarApellido_CambiaApellidoDelCliente()
    {
        ModificadorCliente.ModificarApellido("Gomez", cliente);
        Assert.AreEqual("Gomez", cliente.ObtenerApellido());
    }

    [Test]
    public void ModificarTelefono_CambiaTelefonoDelCliente()
    {
        ModificadorCliente.ModificarTelefono("123", cliente);
        Assert.AreEqual("123", cliente.ObtenerTelefono());
    }

    [Test]
    public void ModificarEmail_CambiaEmailDelCliente()
    {
        ModificadorCliente.ModificarEmail("carlos@gmail.com", cliente);
        Assert.AreEqual("carlos@gmail.com", cliente.ObtenerEmail());
    }
}
