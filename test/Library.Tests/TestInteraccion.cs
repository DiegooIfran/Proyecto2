namespace Library.Tests;

public class TestInteraccion
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestConstructorCorreo() //Chequea que funcione el constructor de la interaccion correo
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
    public void TestConstructorLlamadas() //Chequea que funcione el constructor de la interaccion llamada
    {
        var fechaPrueba = new DateTime(2025, 10, 20, 10, 30, 0);
        const string temaPrueba = "Consulta de Producto X";
        const string notasPrueba = "Cliente preguntó por stock y precio.";
        const bool fueEnviado = true;
        Llamadas llamadas = new Llamadas(fecha: fechaPrueba, tema: temaPrueba, notas: notasPrueba, enviada: fueEnviado);
        Assert.That(llamadas.ObtenerFecha(), Is.EqualTo(fechaPrueba));
        Assert.That(llamadas.ObtenerTema(), Is.EqualTo(temaPrueba));
        Assert.That(llamadas.ObtenerNota(), Is.EqualTo(notasPrueba));
        Assert.That(llamadas.ObtenerEnviada(), Is.EqualTo(fueEnviado));
        Assert.That(llamadas.ObtenerRespondido(), Is.EqualTo(false));
    }
    
    [Test]
    public void TestConstructorMensaje() //Chequea que funcione el constructor de la interaccion mensaje
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
    public void TestConstructorReunion() //Chequea que funcione el constructor de la interaccion reunion
    {
        var fechaPrueba = new DateTime(2025, 10, 20, 10, 30, 0);
        const string temaPrueba = "Consulta de Producto X";
        const string notasPrueba = "Cliente preguntó por stock y precio.";
        Reunion reunion = new Reunion(fecha: fechaPrueba, tema: temaPrueba, notas: notasPrueba);
        Assert.That(reunion.ObtenerFecha(), Is.EqualTo(fechaPrueba));
        Assert.That(reunion.ObtenerTema(), Is.EqualTo(temaPrueba));
        Assert.That(reunion.ObtenerNota(), Is.EqualTo(notasPrueba));
    }
}