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
            Vendedor vendedor = CrearVendedorConClientes();
            
            string panel = Panel.ImprimirPanel(vendedor);
            Console.WriteLine(panel);
            Assert.That(panel, Is.EqualTo("Panel del vendedor: Juan\nClientes totales: 1\n\nInteracciones recientes:\n Reunion: Kickoff 10/11/2025\n Correo: Oferta 9/11/2025\n\nPróximas reuniones:\n"));
        
        }

        [Test]
        public void TestImprimirPanel_SinClientes_MuestraMensajeAdecuado()
        {
            Vendedor vendedor = new Vendedor("Ana", "Rodriguez", "096123456", "anarod@mail.com"); 
            
            string panel = Panel.ImprimirPanel(vendedor);
            Console.WriteLine(panel);
            Assert.That(panel, Is.EqualTo("Panel del vendedor: Ana\nClientes totales: 0\nNo hay interacciones registradas\n\nPróximas reuniones:\nNo hay reuniones próximas."));
        }
    }
