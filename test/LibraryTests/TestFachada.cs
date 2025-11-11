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
        fachada.AgregarCliente("Juan", "Perez", "099111111", email, "M", new DateTime(1990, 1, 1));

        // Act
        var cliente = fachada.BuscarPorEmail(email);

        // Assert
        Assert.That(cliente, Is.Not.Null);
        Assert.That(cliente.ObtenerEmail(), Is.EqualTo(email));
        Assert.That(cliente.ObtenerNombre(), Is.EqualTo("Juan"));
        Assert.That(cliente.ObtenerApellido(), Is.EqualTo("Perez"));
        Assert.That(cliente.ObtenerTelefono(), Is.EqualTo("099111111"));
    }
    
    [Test]
    public void ModificarNombreYBuscarPorNombre_DeberiaActualizarElNombreDelCliente()
    {
        // Arrange
        string email = "test2@mail.com";
        fachada.AgregarCliente("Ana", "Lopez", "099222222", email, "F", new DateTime(1995, 5, 5));
        string nuevoNombre = "Diego";
        
        // Act
        fachada.ModificarNombre(email, nuevoNombre);
        var cliente = fachada.BuscarPorNombre(nuevoNombre);

        // Assert
        Assert.That(cliente.ObtenerNombre(), Is.EqualTo(nuevoNombre));
    }

    [Test]
    public void ModificarApellidoYBuscarPorApellido_DeberiaActualizarElApellidoDelCliente()
    {
        // Arrange
        string email = "test3@mail.com";
        fachada.AgregarCliente("Mario", "Gomez", "099333333", email, "M", new DateTime(1992, 3, 3));
        string nuevoApellido = "Ifran";
        
        // Act
        fachada.ModificarApellido(email, nuevoApellido);
        var cliente = fachada.BuscarPorApellido(nuevoApellido);

        // Assert
        Assert.That(cliente.ObtenerApellido(), Is.EqualTo(nuevoApellido));
    }
    
    [Test]
    public void ModificarTelefonoYBuscarPorTelefono_DeberiaActualizarElTelefonoDelCliente()
    {
        // Arrange
        string email = "test2@mail.com";
        fachada.AgregarCliente("Ana", "Lopez", "099222222", email, "F", new DateTime(1995, 5, 5));
        string nuevoTelefono = "099333333";
        
        // Act
        fachada.ModificarTelefono(email, nuevoTelefono);
        var cliente = fachada.BuscarPorTelefono(nuevoTelefono);

        // Assert
        Assert.That(cliente.ObtenerTelefono(), Is.EqualTo(nuevoTelefono));
    }
    
    [Test]
    public void ModificarEmailYBuscarPorEmail_DeberiaActualizarElEmailDelCliente()
    {
        // Arrange
        string email = "test2@mail.com";
        fachada.AgregarCliente("Ana", "Lopez", "099222222", email, "F", new DateTime(1995, 5, 5));
        string nuevoEmail = "test3@mail.com";

        // Act
        fachada.ModificarEmail(email, nuevoEmail);
        var cliente = fachada.BuscarPorEmail(nuevoEmail);

        // Assert
        Assert.That(cliente.ObtenerEmail(), Is.EqualTo(nuevoEmail));
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
    public void CrearEtiquetaYAgregarlaACliente_DeberiaAsociarseCorrectamente()
    {
        // Arrange
        string email = "etiqueta@mail.com";
        fachada.AgregarCliente("Sofia", "Torres", "099999999", email, "F", new DateTime(1997, 7, 7));
        var etiqueta = new Etiqueta("VIP", "Clientes importantes");

        // Act
        fachada.AgregarEtiqueta(email, etiqueta);

        // Assert
        var cliente = fachada.BuscarPorEmail(email);
        Assert.That(cliente.ObtenerEtiquetas(), Does.Contain(etiqueta));
    }
    
    [Test]
    public void RegistrarReunion_DeberiaAgregarUnaInteraccionDeTipoReunion()
    {
    // Arrange
    string email = "reunion@mail.com";
    Vendedor vendedor = new Vendedor("Vende","dor","09154321","email@email.com");
    fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
    fachada.AsignarVendedor(vendedor);
    // Act
    fachada.RegistrarReunion(email, DateTime.Now, "Presentación", "Reunión de presentación");
    var cliente = fachada.BuscarPorEmail(email);

    // Assert
    Assert.That(cliente.ObtenerInteracciones().Count, Is.GreaterThan(0));
    Assert.That(cliente.ObtenerInteracciones()[0].GetType().Name, Is.EqualTo("Reunion"));
    }
    
    [Test]
    public void RegistrarLlamada_DeberiaAgregarUnaInteraccionDeTipoLlamada()
    {
        // Arrange
        string email = "reunion@mail.com";
        Vendedor vendedor = new Vendedor("Vende","dor","09154321","email@email.com");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
        fachada.AsignarVendedor(vendedor);
        // Act
        fachada.RegistrarLlamada(email, DateTime.Now, "Presentación", "Reunión de presentación", true);
        var cliente = fachada.BuscarPorEmail(email);

        // Assert
        Assert.That(cliente.ObtenerInteracciones().Count, Is.GreaterThan(0));
        Assert.That(cliente.ObtenerInteracciones()[0].GetType().Name, Is.EqualTo("Llamadas"));
    }
    
    [Test]
    public void RegistrarCorreo_DeberiaAgregarUnaInteraccionDeTipoCorreo()
    {
        // Arrange
        string email = "reunion@mail.com";
        Vendedor vendedor = new Vendedor("Vende","dor","09154321","email@email.com");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
        fachada.AsignarVendedor(vendedor);
        // Act
        fachada.RegistrarCorreo(email, DateTime.Now, "Presentación", "Reunión de presentación", true);
        var cliente = fachada.BuscarPorEmail(email);

        // Assert
        Assert.That(cliente.ObtenerInteracciones().Count, Is.GreaterThan(0));
        Assert.That(cliente.ObtenerInteracciones()[0].GetType().Name, Is.EqualTo("Correo"));
    }
    
    [Test]
    public void RegistrarMensaje_DeberiaAgregarUnaInteraccionDeTipoMensaje()
    {
        // Arrange
        string email = "reunion@mail.com";
        Vendedor vendedor = new Vendedor("Vende","dor","09154321","email@email.com");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
        fachada.AsignarVendedor(vendedor);
        // Act
        fachada.RegistrarMensaje(email, DateTime.Now, "Presentación", "Reunión de presentación", true);
        var cliente = fachada.BuscarPorEmail(email);

        // Assert
        Assert.That(cliente.ObtenerInteracciones().Count, Is.GreaterThan(0));
        Assert.That(cliente.ObtenerInteracciones()[0].GetType().Name, Is.EqualTo("Mensaje"));
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