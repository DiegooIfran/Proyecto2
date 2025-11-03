namespace Library.Tests
{
    public class VentaTests
    {
        [Test]
        public void Venta_Creacion_PropiedadesCorrectas()
        {
            // Arrange
            string producto = "Laptop";
            int precio = 1500;

            // Act
            Venta venta = new Venta(producto, precio);

            // Assert
            Assert.That(venta.Producto, Is.EqualTo(producto));
            Assert.That(venta.Precio, Is.EqualTo(precio));
            Assert.That(venta.Fecha, Is.EqualTo(DateTime.Today));
        }

        [Test]
        public void Venta_ProductoYPrecio_PuedenCambiar()
        {
            // Arrange
            Venta venta = new Venta("Tablet", 500);

            // Act
            venta.Producto = "Celular";
            venta.Precio = 600;

            // Assert
            Assert.That(venta.Producto, Is.EqualTo("Celular"));
            Assert.That(venta.Precio, Is.EqualTo(600));
        }
    }
}