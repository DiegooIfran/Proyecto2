namespace Library.Tests;

public class TestPanel
{
    private Cliente CrearClienteConInteracciones()
        {
            Cliente cliente = new Cliente("Pablo", "Martinez", "098333222", "pablomm@email.com", "Masculino", new DateTime(2000, 6, 22));
            cliente.AgregarInteraccion(new Reunion( new DateTime(2025,10,12),"Kickoff", "Presentación inicial"));
            cliente.AgregarInteraccion(new Correo( new DateTime(2025,4,4), "Oferta","Revisar presupuesto", false));
            return cliente;
        }

        private Vendedor CrearVendedorConClientes()
        {
            Vendedor vendedor = new Vendedor("Juan", "Silva", "092678999", "juansil@MailAddress.com", ".luty");
            vendedor.AgregarCliente(CrearClienteConInteracciones());
            return vendedor;
        }

        [Test]
        public void TestImprimirPanel_MuestraClientesEInteracciones()
        {
            Vendedor vendedor = CrearVendedorConClientes();
            
            string panel = Panel.MostrarPanel(vendedor);
            Console.WriteLine(panel);
            Assert.That(panel, Is.EqualTo("**Panel del vendedor Juan Silva**\n**Clientes totales:** 1\n\n**Interacciones recientes:**\n Reunion: Kickoff 12/10/2025\n Correo: Oferta 4/4/2025\n\n**Próximas reuniones:**\n"));
        
        }

        [Test]
        public void TestImprimirPanel_SinClientes_MuestraMensajeAdecuado()
        {
            Vendedor vendedor = new Vendedor("Ana", "Rodriguez", "096123456", "anarod@mail.com", ".luty"); 
            
            string panel = Panel.MostrarPanel(vendedor);
            Console.WriteLine(panel);
            Assert.That(panel, Is.EqualTo("**Panel del vendedor Ana Rodriguez**\n**Clientes totales:** 0\nNo hay interacciones registradas.\n\n**Próximas reuniones:**\nNo hay reuniones próximas."));
        }
    }
