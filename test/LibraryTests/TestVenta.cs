namespace Library.Tests
{
    public class VentaTests
    {
        [Test]
        public void Venta_Creacion_PropiedadesCorrectas()
        {
            // Arrange
            DateTime fecha = DateTime.Today;
            string tema = "Venta";
            string notas = "Venta de laptop";
            int precio = 1500;

            // Act
            Venta venta = new Venta(fecha, tema, notas, precio);

            // Assert
            Assert.That(venta.Precio, Is.EqualTo(precio));
            Assert.That(venta.Fecha, Is.EqualTo(fecha));
            Assert.That(venta.ObtenerTema(), Is.EqualTo(tema));
            Assert.That(venta.ObtenerNota(), Is.EqualTo(notas));
        }
    }
}