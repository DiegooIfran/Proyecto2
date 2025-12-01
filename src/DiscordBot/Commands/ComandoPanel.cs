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
        [Command("verTotalClientes")]
        [Summary(
            "Muestra todos los clientes. Uso !verTotalClientes nick")]
        // Pones el nick del vendedor a buscar
        // ReSharper disable once UnusedMember.Global

        public async Task ExecuteAsync(string nick)
        {
            try
            {
                var vendedor = _fachada.BuscarVendedorNick(nick);
                
                await ReplyAsync(_fachada.VerTotalClientes(vendedor as Vendedor).ToString());
                
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
        
    }
}    