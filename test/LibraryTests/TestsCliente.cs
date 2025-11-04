namespace Library.Tests
{
    public class ClienteTests
    {
        [Test]
        public void Constructor_AsignaPropiedadesYListasVacias()
        {
            // Arrange y Act
            Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990, 10, 20));

            // Assert
            Assert.That(cliente.ObtenerNombre(), Is.EqualTo("Juan"));
            Assert.That(cliente.ObtenerApellido(), Is.EqualTo("Martinez"));
            Assert.That(cliente.ObtenerTelefono(), Is.EqualTo("091827989"));
            Assert.That(cliente.ObtenerEmail(), Is.EqualTo("jmartin@gmail.com"));
            Assert.That(cliente.ObtenerGenero(), Is.EqualTo("hombre"));
            Assert.That(cliente.ObtenerFechaNacimiento(), Is.EqualTo(new DateTime(1990, 10, 20)));
            Assert.That(cliente.ObtenerEtiquetas(), Is.Empty);
            Assert.That(cliente.ObtenerInteracciones(), Is.Empty);
        }

        [Test]
        public void UltimaInteraccion_DevuelveLaMasReciente()
        {
            // Arrange
            Cliente cliente = new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "hombre", new DateTime(1990, 10, 20));

            Interaccion i1 = new Venta(new DateTime(2024, 5, 10), "Compra", "Compra de producto", 500);
            Interaccion i2 = new Cotizacion(new DateTime(2025, 1, 15), "Cotización", "Cotización futura", cliente, 800);
            Interaccion i3 = new Venta(new DateTime(2025, 3, 20), "Pago", "Pago completado", 600);

            cliente.AgregarInteraccion(i1);
            cliente.AgregarInteraccion(i2);
            cliente.AgregarInteraccion(i3);

            // Act
            var ultima = cliente.UltimaInteraccion();

            // Assert
            Assert.That(ultima, Is.EqualTo(i3));
        }
    }
}