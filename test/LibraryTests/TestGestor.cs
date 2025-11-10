using NUnit.Framework;
using System.Collections.Generic;

namespace Library.Tests
{
    public class TestGestor
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAgregar()
        {
            // Justificación: comprueba que el método Agregar funciona correctamente
            Gestor<Cliente> gestor = Singleton<Gestor<Cliente>>.Instance;

            Cliente cliente = new Cliente("Juan", "Perez", "091111111", "juan@gmail.com", "Hombre", new DateTime(1990, 5, 12));
            gestor.Agregar(cliente);

            Assert.That(gestor.VerTotal().Count.Equals(1));
            Assert.That(gestor.VerTotal().Contains(cliente));
        }

        [Test]
        public void TestEliminar()
        {
            // Justificación: comprueba que el método Eliminar funciona correctamente
            Gestor<Cliente> gestor = Singleton<Gestor<Cliente>>.Instance;

            Cliente cliente = new Cliente("Lucia", "Romero", "092222222", "lucia@gmail.com", "Mujer", new DateTime(1993, 3, 25));
            gestor.Agregar(cliente);
            gestor.Eliminar(cliente);

            Assert.That(gestor.VerTotal().Count.Equals(0));
        }

        [Test]
        public void TestVerTotal()
        {
            // Justificación: comprueba que el método VerTotal devuelve la lista completa
            Gestor<Cliente> gestor = Singleton<Gestor<Cliente>>.Instance;

            Cliente c1 = new Cliente("Juan", "Martinez", "093333333", "juan@gmail.com", "Hombre", DateTime.Today);
            Cliente c2 = new Cliente("Ana", "Dominguez", "094444444", "ana@gmail.com", "Mujer", DateTime.Today);
            
            gestor.Agregar(c1);
            gestor.Agregar(c2);

            List<Cliente> lista = gestor.VerTotal();

            Assert.That(lista.Count.Equals(2));
            Assert.That(lista.Contains(c1));
            Assert.That(lista.Contains(c2));
        }

        [Test]
        public void TestYaRegistrado_DevuelveTrueSiEmailExiste()
        {
            // Justificación: comprueba que YaRegistrado devuelve true si el email ya está en la lista
            Gestor<Cliente> gestor = Singleton<Gestor<Cliente>>.Instance;

            Cliente cliente = new Cliente("Juan", "Perez", "095555555", "juan@gmail.com", "Hombre", DateTime.Today);
            gestor.Agregar(cliente);

            bool resultado = gestor.YaRegistrado("juan@gmail.com");

            Assert.That(resultado, Is.True);
        }

        [Test]
        public void TestYaRegistrado_DevuelveFalseSiEmailNoExiste()
        {
            // Justificación: comprueba que YaRegistrado devuelve false si el email no está registrado
            Gestor<Cliente> gestor = Singleton<Gestor<Cliente>>.Instance;

            Cliente cliente = new Cliente("Lucia", "Romero", "096666666", "lucia@gmail.com", "Mujer", DateTime.Today);
            gestor.Agregar(cliente);

            bool resultado = gestor.YaRegistrado("otro@gmail.com");

            Assert.That(resultado, Is.False);
        }
    }
}
