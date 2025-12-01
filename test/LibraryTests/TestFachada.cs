namespace Library.Tests;

public class TestFachada
{
    Fachada fachada = Singleton<Fachada>.Instance; 
    GestorEtiquetas<Etiqueta> ge = Singleton<GestorEtiquetas<Etiqueta>>.Instance;

    [SetUp]
    public void Setup()
    {
        Singleton<GestorAdministrador>.Instance.VerTotal().Clear();
        Singleton<GestorCliente>.Instance.VerTotal().Clear();
        Singleton<GestorVendedor>.Instance.VerTotal().Clear();
        Singleton<GestorEtiquetas<Etiqueta>>.Instance.VerEtiquetas().Clear();
    }

    [Test]
    public void AgregarYBuscarCliente_DeberiaDevolverElMismoCliente()
    {
        // Arrange
        string email = "test1@mail.com";
        fachada.AgregarCliente("Juan", "Perez", "099111111", email, "M", new DateTime(1990, 1, 1));

        // Act
        var cliente = fachada.BuscarPorNombre("Juan").First();

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
        var cliente = fachada.BuscarPorNombre(nuevoNombre).First();

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
        var cliente = fachada.BuscarPorApellido(nuevoApellido).First();

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
        fachada.AgregarCliente("Sofia", "Torres", "099999999", "etiqueta@gmail.com", "F", new DateTime(1997, 7, 7));

        // Act
        fachada.AgregarEtiqueta("etiqueta@gmail.com", "VIP");

        // Assert
        var cliente = fachada.BuscarPorEmail("etiqueta@gmail.com");
        Assert.That(cliente.ObtenerEtiquetas().Count, Is.EqualTo(1));
    }

    [Test]
    public void RegistrarReunion_DeberiaAgregarUnaInteraccionDeTipoReunion()
    {
        // Arrange
        string email = "reunion@mail.com";
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@email.com", "diego");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
        fachada.AsignarCliente("diego", email);
        // Act
        fachada.RegistrarReunion("diego", email, DateTime.Now, "Presentación", "Reunión de presentación");
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
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@email.com", "diego");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
        fachada.AsignarCliente("diego", email);
        // Act
        fachada.RegistrarLlamada("diego", email, DateTime.Now, "Presentación", "Reunión de presentación", true);
        var cliente = fachada.BuscarPorEmail(email);

        // Assert
        Assert.That(cliente.ObtenerInteracciones().Count, Is.GreaterThan(0));
        Assert.That(cliente.ObtenerInteracciones()[0].GetType().Name, Is.EqualTo("Llamada"));
    }

    [Test]
    public void RegistrarCorreo_DeberiaAgregarUnaInteraccionDeTipoCorreo()
    {
        // Arrange
        string email = "reunion@mail.com";
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@email.com", "diego");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
        fachada.AsignarCliente("diego", email);
        // Act
        fachada.RegistrarCorreo("diego", email, DateTime.Now, "Presentación", "Reunión de presentación", true);
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
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@email.com", "diego");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", email, "M", new DateTime(2003, 3, 3));
        fachada.AsignarCliente("diego", email);
        // Act
        fachada.RegistrarMensaje("diego", email, DateTime.Now, "Presentación", "Reunión de presentación", true);
        var cliente = fachada.BuscarPorEmail(email);

        // Assert
        Assert.That(cliente.ObtenerInteracciones().Count, Is.GreaterThan(0));
        Assert.That(cliente.ObtenerInteracciones()[0].GetType().Name, Is.EqualTo("Mensaje"));
    }

    [Test]
    public void Singleton_DeberiaDevolverLaMismaInstancia()
    {
        // Act
        Fachada instancia1 = Singleton<Fachada>.Instance;
        Fachada instancia2 = Singleton<Fachada>.Instance;

        // Assert
        Assert.That(instancia1, Is.SameAs(instancia2));
    }

    [Test]
    public void BuscarVendedorNick()
    {
        // Act
        string nick = ".luty";
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@gmail.com", ".luty");

        // Assert
        Assert.That(fachada.BuscarVendedorNick(nick).ObtenerEmail(), Is.SameAs("email@gmail.com"));
    }

    [Test]
    public void BuscarAdminNick()
    {
        // Act
        string nick = ".luty";
        fachada.CrearAdministrador("Vende", "dor", "09154321", "email@gmail.com", ".luty");

        // Assert
        Assert.That(fachada.BuscarAdministradorNick(nick).ObtenerEmail(), Is.SameAs("email@gmail.com"));
    }


    [Test]
    public void VerTotalClientes()
    {
        // Act
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@gmail.com", ".luty");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", "prueba1@gmail.com", "M", new DateTime(2003, 3, 3));
        fachada.AgregarCliente("Diego", "Ifran", "091111111", "prueba2@gmail.com", "M", new DateTime(2003, 3, 3));
        fachada.AgregarCliente("Diego", "Ifran", "091111111", "prueba3@gmail.com", "M", new DateTime(2003, 3, 3));
        fachada.AgregarCliente("Diego", "Ifran", "091111111", "prueba4@gmail.com", "M", new DateTime(2003, 3, 3));
        fachada.AsignarCliente(".luty", "prueba1@gmail.com");
        fachada.AsignarCliente(".luty", "prueba2@gmail.com");
        fachada.AsignarCliente(".luty", "prueba3@gmail.com");
        fachada.AsignarCliente(".luty", "prueba4@gmail.com");

        Assert.That(fachada.VerTotalClientes(fachada.BuscarVendedorNick(".luty")).Count, Is.EqualTo(4));
    }
    
    [Test]
    public void CrearEtiqueta()
    {
        // Act
        fachada.CrearEtiqueta("hola","prueba");
        // Assert
        Assert.That(ge.VerEtiquetas()[0].Nombre, Is.EqualTo("hola"));
        Assert.That(ge.VerEtiquetas()[0].Descripcion, Is.EqualTo("prueba"));
    }

    [Test]
    public void BorrarEtiqueta()
    {
        // Act
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@gmail.com", ".luty");
        fachada.CrearEtiqueta("hola", "prueba");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", "prueba1@gmail.com", "M", new DateTime(2003, 3, 3));
        fachada.AgregarEtiqueta("prueba1@gmail.com", "hola");
        Assert.That(fachada.BuscarPorEmail("prueba1@gmail.com").ObtenerEtiquetas().Count, Is.EqualTo(1));
        fachada.BorrarEtiqueta("prueba1@gmail.com", "hola");
        // Assert
        Assert.That(fachada.BuscarPorEmail("prueba1@gmail.com").ObtenerEtiquetas().Count, Is.EqualTo(0));
    }
    
    [Test]
    public void RealizarCampana()
    {
        // Act
        fachada.CrearVendedor("Vende", "dor", "09154321", "email@gmail.com", ".luty");
        fachada.CrearEtiqueta("hola", "prueba");
        fachada.AgregarCliente("Diego", "Ifran", "091111111", "prueba1@gmail.com", "M", new DateTime(2003, 3, 3));
        fachada.AgregarEtiqueta("prueba1@gmail.com", "hola");
        
        
        // Assert
        Assert.That(fachada.BuscarPorEmail("prueba1@gmail.com").ObtenerEtiquetas().Count, Is.EqualTo(0));
    }
}