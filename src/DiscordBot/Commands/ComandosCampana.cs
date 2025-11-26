using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoRealizarCampana : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        public ComandoRealizarCampana(Fachada fachada)
        {
            _fachada = fachada;
        }

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