using System;
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
            "Muestra todos los clientes de un vendedor. Uso !verPanel nick")]
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
}    