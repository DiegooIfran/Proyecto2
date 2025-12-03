using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoPanel : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoPanel()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando 'VerTotalClientes'.
        /// </summary>
        [Command("verPanel")]
        [Summary(
            "Muestra el panel de un vendedor. Uso !verPanel nick")]
        // ReSharper disable once UnusedMember.Global

        public async Task ExecuteAsync(string nick)
        {
            try
            {
                await ReplyAsync(_fachada.VerPanel(nick));
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
        
    }
    public class ComandoVerTotalClientes : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoVerTotalClientes()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando 'VerTotalClientes'.
        /// </summary>
        [Command("verTotalCliente")]
        [Summary(
            "Muestra todos los clientes de un vendedor. Uso !verTotalCliente nick")]
        // ReSharper disable once UnusedMember.Global

        public async Task ExecuteAsync(string nick)
        {
            try
            {
                string mensaje ="";
                Vendedor vendedor = _fachada.BuscarVendedorNick(nick) as Vendedor;
                List<Cliente> totalCliente = _fachada.VerTotalClientes(vendedor);
                mensaje+= $"**Clientes de {vendedor.ObtenerNombre()} {vendedor.ObtenerApellido()}: **\n";
                foreach (Cliente cliente in totalCliente)
                {
                    mensaje+= $"**{cliente} **\n";
                }
                await ReplyAsync(mensaje);
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
        
    }
    public class ComandoMayorVendedor : ModuleBase<SocketCommandContext>
    {
        // Decido agregarlo aca ya que cumple una funcion similar a la de un panel.
        
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoMayorVendedor()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando "mayorVendedor'.
        /// </summary>
        [Command("mayorVendedor")]
        [Summary(
            "Veo el vendedor con mas ventas. Uso !mayorVendedor")]
        // Lo debera hacer un administrador

        public async Task MayorVendedor()
        {
            try
            {
                Usuario admin = _fachada.BuscarAdministradorNick(Context.User.Username);
                // Esto ya que lo debe hacer el administrador
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No eres un administrador.");
                return;
            }
            try
            {
                Vendedor vendedor = _fachada.MejorVendedor();
                await ReplyAsync(
                    $"- **El vendedor:** {vendedor.ObtenerNombre()} {vendedor.ObtenerApellido()} ha sido el que mas ventas logro.\n" +
                    $"- **Genero un total de:** ${vendedor.TotalVentas()}.\n" +
                    $"- **Cerro:** {vendedor.NumeroVentas()} ventas\n" +
                    $"- **Logro obtener un bonus de:** ${vendedor.NumeroVentas() * 100}");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No hay vendedores");
                // En caso de no encontrar un mejor vendedor significa que no hay vendedores, por ende dará error.
            }

        }
    }
    
}    