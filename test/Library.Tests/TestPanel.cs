namespace Library.Tests;

public class TestPanel
{
    private Cliente CrearClienteConInteracciones()
        {
            Cliente cliente = new Cliente("Pablo", "Martinez", "098333222", "pablomm@email.com", "Masculino", new DateTime(2000, 6, 22));
            cliente.AgregarInteraccion(new Reunion( DateTime.Today,"Kickoff", "Presentación inicial"));
            cliente.AgregarInteraccion(new Correo( DateTime.Today.AddDays(-1), "Oferta","Revisar presupuesto", false));
            return cliente;
        }

        private Vendedor CrearVendedorConClientes()
        {
            Vendedor vendedor = new Vendedor("Juan", "Silva", "092678999", "juansil@MailAddress.com");
            vendedor.AgregarCliente(CrearClienteConInteracciones());
            return vendedor;
        }

        [Test]
        public void TestImprimirPanel_MuestraClientesEInteracciones()
        {
            // Arrange
            Vendedor vendedor = CrearVendedorConClientes();
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Panel.ImprimirPanel(vendedor);
            string output = sw.ToString();

            // Assert
            StringAssert.Contains("Panel del vendedor: Juan", output);
            StringAssert.Contains("Clientes totales: 1", output);
            StringAssert.Contains("Interacciones recientes:", output);
            StringAssert.Contains("Reunion: Kickoff", output);
            StringAssert.Contains("Correo: Oferta", output);
            StringAssert.Contains("Próximas reuniones:", output);
        }

        [Test]
        public void TestImprimirPanel_SinClientes_MuestraMensajeAdecuado()
        {
            // Arrange
            Vendedor vendedor = new Vendedor("Ana", "Rodriguez", "096123456", "anarod@mail.com"); 
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Panel.ImprimirPanel(vendedor);
            string output = sw.ToString();

            // Assert
            StringAssert.Contains("Panel del vendedor: Ana", output);
            StringAssert.Contains("Clientes totales: 0", output);
            StringAssert.Contains("No hay interacciones registradas", output);
        }
    }
