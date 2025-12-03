using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoMaxVentas : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoMaxVentas()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'VendedorConMaxVentas'.
        /// </summary>
        [Command("vendedorConMaxVentas")]
        [Summary(
            "Devuelve al vendedor con más ventas. Usa !vendedorConMaxVentas")]
            
        public async Task ExecuteAsync()
        {
            try
            {
                await ReplyAsync($"El vendedor con **más ventas** es **{_fachada.VendedorConMaxVentas().ObtenerNick()}** con **{_fachada.VendedorConMaxVentas().ObtenerCantidadDeVentas()}** ventas.");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
}