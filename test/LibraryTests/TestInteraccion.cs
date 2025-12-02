using System.Runtime.InteropServices;

namespace Library.Tests;

public class TestInteraccion
{ 
    private Fachada _fachada = Singleton<Fachada>.Instance;

    [SetUp]
    public void Setup()
    {
        Singleton<GestorCliente>.Instance.VerTotal().Clear();
        Singleton<GestorVendedor>.Instance.VerTotal().Clear();
    }

    [Test]
    public void TestConstructorCorreo() 
    {
        var fechaPrueba = new DateTime(2025, 10, 20, 10, 30, 0);
        const string temaPrueba = "Consulta de Producto X";
        const string notasPrueba = "Cliente preguntó por stock y precio.";
        const bool fueEnviado = true;
        Correo correo = new Correo(fecha: fechaPrueba, tema: temaPrueba, notas: notasPrueba, enviada: fueEnviado);
        Assert.That(correo.ObtenerFecha(), Is.EqualTo(fechaPrueba));
        Assert.That(correo.ObtenerTema(), Is.EqualTo(temaPrueba));
        Assert.That(correo.ObtenerNota(), Is.EqualTo(notasPrueba));
        Assert.That(correo.ObtenerEnviada(), Is.EqualTo(fueEnviado));
        Assert.That(correo.ObtenerRespondido(), Is.EqualTo(false));
    }

    [Test]
    public void TestConstructorLlamadas()
    {
        var fechaPrueba = new DateTime(2025, 10, 20, 10, 30, 0);
        const string temaPrueba = "Consulta de Producto X";
        const string notasPrueba = "Cliente preguntó por stock y precio.";
        const bool fueEnviado = true;
        Llamada llamada = new Llamada(fecha: fechaPrueba, tema: temaPrueba, notas: notasPrueba, enviada: fueEnviado);
        Assert.That(llamada.ObtenerFecha(), Is.EqualTo(fechaPrueba));
        Assert.That(llamada.ObtenerTema(), Is.EqualTo(temaPrueba));
        Assert.That(llamada.ObtenerNota(), Is.EqualTo(notasPrueba));
        Assert.That(llamada.ObtenerEnviada(), Is.EqualTo(fueEnviado));
        Assert.That(llamada.ObtenerRespondido(), Is.EqualTo(false));
    }
    
    [Test]
    public void TestConstructorMensaje() 
    {
        var fechaPrueba = new DateTime(2025, 10, 20, 10, 30, 0);
        const string temaPrueba = "Consulta de Producto X";
        const string notasPrueba = "Cliente preguntó por stock y precio.";
        const bool fueEnviado = true;
        Mensaje mensaje = new Mensaje(fecha: fechaPrueba, tema: temaPrueba, notas: notasPrueba, enviada: fueEnviado);
        Assert.That(mensaje.ObtenerFecha(), Is.EqualTo(fechaPrueba));
        Assert.That(mensaje.ObtenerTema(), Is.EqualTo(temaPrueba));
        Assert.That(mensaje.ObtenerNota(), Is.EqualTo(notasPrueba));
        Assert.That(mensaje.ObtenerEnviada(), Is.EqualTo(fueEnviado));
        Assert.That(mensaje.ObtenerRespondido(), Is.EqualTo(false));
    }
    
    [Test]
    public void TestConstructorReunion()
    {
        var fechaPrueba = new DateTime(2025, 10, 20, 10, 30, 0);
        const string temaPrueba = "Consulta de Producto X";
        const string notasPrueba = "Cliente preguntó por stock y precio.";
        Reunion reunion = new Reunion(fecha: fechaPrueba, tema: temaPrueba, notas: notasPrueba);
        Assert.That(reunion.ObtenerFecha(), Is.EqualTo(fechaPrueba));
        Assert.That(reunion.ObtenerTema(), Is.EqualTo(temaPrueba));
        Assert.That(reunion.ObtenerNota(), Is.EqualTo(notasPrueba));
    }
    
    [Test]
    public void VerCorreo_ClienteSinCorreos_MuestraMensajeDeVacio()
    {
        _fachada.AgregarCliente("Ana", "Lopez", "099111222", "ana@gmail.com", "mujer", DateTime.Now);
        _fachada.CrearVendedor("Lautaro", "Ramirez", "0923313", "lautaro@gmail.com", ".luty");
        string resultado = BuscadorInteracciones.VerCorreo(_fachada.BuscarPorEmail("ana@gmail.com"));

        Assert.That(resultado, Does.Contain("No hay correos registrados"));
    }

    [Test]
    public void VerCorreo_ClienteConUnCorreo_MuestraCorreo()
    {
        _fachada.AgregarCliente("Pedro", "Gomez", "094555666", "pepe@gmail.com", "hombre", DateTime.Now);
        _fachada.CrearVendedor("Lautaro", "Ramirez", "0923313", "lautaro@gmail.com", ".luty");
        _fachada.RegistrarCorreo(".luty","pepe@gmail.com", DateTime.Today, "Consulta", "Nota ejemplo", false);

        string resultado = BuscadorInteracciones.VerCorreo(_fachada.BuscarPorEmail("pepe@gmail.com"));

        Assert.That(resultado, Does.Contain("Tema: Consulta"));
        Assert.That(resultado, Does.Contain(DateTime.Today.ToShortDateString()));
        Assert.That(resultado, Does.Contain("Nota ejemplo"));
    }
    
    [Test]
    public void VerMensaje_ClienteConUNMENSAJE_MuestraMensaje()
    {
        _fachada.AgregarCliente("Pedro", "Gomez", "094555666", "pepe@gmail.com", "hombre", DateTime.Now);
        _fachada.CrearVendedor("Lautaro", "Ramirez", "0923313", "lautaro@gmail.com", ".luty");
        _fachada.RegistrarMensaje(".luty","pepe@gmail.com", DateTime.Today, "Consulta", "Nota ejemplo", false);

        string resultado = BuscadorInteracciones.VerMensaje(_fachada.BuscarPorEmail("pepe@gmail.com"));

        Assert.That(resultado, Does.Contain("Tema: Consulta"));
        Assert.That(resultado, Does.Contain(DateTime.Today.ToShortDateString()));
        Assert.That(resultado, Does.Contain("Nota ejemplo"));
    }
    
    [Test]
    public void VerLlamada_ClienteConUnaLlamada_MuestraLlamadas()
    {
        _fachada.AgregarCliente("Pedro", "Gomez", "094555666", "pepe@gmail.com", "hombre", DateTime.Now);
        _fachada.CrearVendedor("Lautaro", "Ramirez", "0923313", "lautaro@gmail.com", ".luty");
        _fachada.RegistrarLlamada(".luty","pepe@gmail.com", DateTime.Today, "Consulta", "Nota ejemplo", false);

        string resultado = BuscadorInteracciones.VerLlamadas(_fachada.BuscarPorEmail("pepe@gmail.com"));

        Assert.That(resultado, Does.Contain("Tema: Consulta"));
        Assert.That(resultado, Does.Contain(DateTime.Today.ToShortDateString()));
        Assert.That(resultado, Does.Contain("Nota ejemplo"));
    }

}