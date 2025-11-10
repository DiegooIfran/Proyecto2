namespace Library.Tests;

public class TestFachada
{
    private Fachada fachada;
    
    [SetUp]
    public void Setup()
    {
        fachada = Fachada.Instance;
    }
    
    [Test]
    public void AgregarYBuscarCliente_DeberiaDevolverElMismoCliente()
    {
        // Arrange
        string email = "test1@mail.com";
        fachada.AgregarCliente("Juan", "Pérez", "099111111", email, "M", new DateTime(1990, 1, 1));

        // Act
        var cliente = fachada.BuscarPorEmail(email);

        // Assert
        Assert.That(cliente, Is.Not.Null);
        Assert.That(cliente.ObtenerEmail(), Is.EqualTo(email));
        Assert.That(cliente.ObtenerNombre(), Is.EqualTo("Juan"));
    }
    
    [Test]
    public void ModificarNombre_DeberiaActualizarElNombreDelCliente()
    {
        // Arrange
        string email = "test2@mail.com";
        fachada.AgregarCliente("Ana", "Lopez", "099222222", email, "F", new DateTime(1995, 5, 5));
        string nuevoNombre = "Diego";
        
        // Act
        fachada.ModificarNombre(email, nuevoNombre);
        var cliente = fachada.BuscarPorNombre(nuevoNombre);

        // Assert
        Assert.That(cliente.ObtenerNombre(), Is.EqualTo("Andrea"));
    }

    [Test]
    public void ModificarApellido_DeberiaActualizarElApellidoDelCliente()
    {
        // Arrange
        string email = "test3@mail.com";
        fachada.AgregarCliente("Mario", "Gomez", "099333333", email, "M", new DateTime(1992, 3, 3));
        string nuevoApellido = "Ifran";
        
        // Act
        fachada.ModificarApellido(email, nuevoApellido);
        var cliente = fachada.BuscarPorApellido(nuevoApellido);

        // Assert
        Assert.That(cliente.ObtenerApellido(), Is.EqualTo("Gonzalez"));
    }
    
    [Test]
    public void ModificarTelefono_DeberiaActualizarElTelefonoDelCliente()
    {
        // Arrange
        string email = "test2@mail.com";
        fachada.AgregarCliente("Ana", "Lopez", "099222222", email, "F", new DateTime(1995, 5, 5));
        string nuevoTelefono = "099333333";
        
        // Act
        fachada.ModificarTelefono(email, nuevoTelefono);
        var cliente = fachada.BuscarPorTelefono(nuevoTelefono);

        // Assert
        Assert.That(cliente.ObtenerTelefono(), Is.EqualTo("099333333"));
    }
    
    [Test]
    public void ModificarEmail_DeberiaActualizarElEmailDelCliente()
    {
        // Arrange
        string email = "test2@mail.com";
        fachada.AgregarCliente("Ana", "Lopez", "099222222", email, "F", new DateTime(1995, 5, 5));
        string nuevoEmail = "test3@mail.com";

        // Act
        fachada.ModificarEmail(email, nuevoEmail);
        var cliente = fachada.BuscarPorEmail(nuevoEmail);

        // Assert
        Assert.That(cliente.ObtenerEmail(), Is.EqualTo("test3@mail.com"));
    }
    
    [Test]
    public void EliminarCliente_DeberiaQuitarloDeLaLista()
    {
        // Arrange
        string email = "test4@mail.com";
        fachada.AgregarCliente("Carla", "Diaz", "099444444", email, "F", new DateTime(1998, 8, 8));

        // Act
        fachada.EliminarCliente(email);

        // Assert
        Assert.Throws<InvalidOperationException>(() => fachada.BuscarPorEmail(email));
    }
    
    [Test]
    public void Singleton_DeberiaDevolverLaMismaInstancia()
    {
        // Act
        var instancia1 = Fachada.Instance;
        var instancia2 = Fachada.Instance;

        // Assert
        Assert.That(instancia1, Is.SameAs(instancia2));
    }
}