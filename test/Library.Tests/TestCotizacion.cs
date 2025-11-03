namespace Library.Tests
{
    public class CotizacionTests
    {
        private Cliente CrearCliente()
        {
            return new Cliente("Juan", "Martinez", "091827989", "jmartin@gmail.com", "masculino", new DateTime(2006, 5, 1));
        }

        [Test]
        public void Cotizacion_Creacion_PropiedadesCorrectas()
        {
            // Arrange
            var cliente = CrearCliente();
            string producto = "Celular";
            int precio = 800;

            // Act
            Cotizacion cotizacion = new Cotizacion(cliente, precio, producto);

            // Assert
            Assert.That(cotizacion.Producto, Is.EqualTo(producto));
            Assert.That(cotizacion.Precio, Is.EqualTo(precio));
            Assert.That(cotizacion.Fecha, Is.EqualTo(DateTime.Today));
            Assert.That(cotizacion.Estado, Is.EqualTo("Abierta"));
            Assert.That(cotizacion.Cliente, Is.EqualTo(cliente));
        }

        [Test]
        public void Cotizacion_CerrarVenta_CambiaEstadoYAñadeVentaACliente()
        {
            // Arrange
            var cliente = CrearCliente();
            Cotizacion cotizacion = new Cotizacion(cliente, 500, "Tablet");

            // Act
            cotizacion.CerrarVenta();

            // Assert
            Assert.That(cotizacion.Estado, Is.EqualTo("Cerrada"));
            var compras = cliente.ObtenerCompras();
            Assert.That(compras.Count, Is.EqualTo(1));
            Assert.That(compras[0].Producto, Is.EqualTo("Tablet"));
            Assert.That(compras[0].Precio, Is.EqualTo(500));
        }

        [Test]
        public void Cotizacion_CerrarVenta_DosVeces_NoAgregaOtraVenta()
        {
            // Arrange
            var cliente = CrearCliente();
            Cotizacion cotizacion = new Cotizacion(cliente, 300, "Monitor");

            // Act
            cotizacion.CerrarVenta();

            // Assert
            Assert.That(cotizacion.Estado, Is.EqualTo("Cerrada"));
            var compras = cliente.ObtenerCompras();
            Assert.That(compras.Count, Is.EqualTo(1)); // solo una venta
        }
    }
}
