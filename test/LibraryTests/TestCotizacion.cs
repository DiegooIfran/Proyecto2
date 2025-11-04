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
            int precio = 800;
            string tema = "Presupuesto";
            string notas = "Cotización de celular";

            // Act
            Cotizacion cotizacion = new Cotizacion(DateTime.Today, tema, notas, cliente, precio);

            // Assert
            Assert.That(cotizacion.Precio, Is.EqualTo(precio));
            Assert.That(cotizacion.Fecha, Is.EqualTo(DateTime.Today));
            Assert.That(cotizacion.Estado, Is.EqualTo("Abierta"));
            Assert.That(cotizacion.Cliente, Is.EqualTo(cliente));
            Assert.That(cotizacion.ObtenerTema(), Is.EqualTo(tema));
            Assert.That(cotizacion.ObtenerNota(), Is.EqualTo(notas));
        }

        [Test]
        public void Cotizacion_CerrarVenta_CambiaEstadoYAñadeVentaACliente()
        {
            // Arrange
            var cliente = CrearCliente();
            Cotizacion cotizacion = new Cotizacion(DateTime.Today, "Cotización", "Cotización de tablet", cliente, 500);

            // Act
            cotizacion.CerrarVenta();

            // Assert
            Assert.That(cotizacion.Estado, Is.EqualTo("Cerrada"));

            // El cliente debería tener una nueva interacción de tipo Venta
            var interacciones = cliente.ObtenerInteracciones();
            Assert.That(interacciones.Count, Is.EqualTo(1));
            Assert.That(interacciones[0], Is.TypeOf<Venta>());
            Assert.That(((Venta)interacciones[0]).Precio, Is.EqualTo(500));
        }
    }
}