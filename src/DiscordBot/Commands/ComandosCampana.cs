using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoRealizarCampana : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoRealizarCampana()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando 'RealizarCampana'.
        /// </summary>
        [Command("campana")]
        [Summary("Realiza una campaña publicitaria. Uso: !campana nick etiqueta anuncio")]
        public async Task ExecuteAsync(string nick, string nombreEtiqueta, [Remainder] string anuncio)
        {
            try
            {
                _fachada.RealizarCampana(nick, nombreEtiqueta, anuncio);

                await ReplyAsync(
                    $"Campaña realizada por **{nick}**\n" +
                    $"Etiqueta: **{nombreEtiqueta}**\n" +
                    $"Anuncio enviado:\n> {anuncio}");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
}