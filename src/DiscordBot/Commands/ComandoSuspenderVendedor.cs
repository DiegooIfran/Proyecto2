using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Discord.WebSocket;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoSuspenderVendedor : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoSuspenderVendedor()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando 'suspenderVendedor'.
        /// </summary>
        [Command("suspenderVendedor")]
        [Summary(
            "Suspendo a un vendedor. Uso !suspenderVendedor email")]

        public async Task SuspenderVendedor(string email)
        {
            try
            {
                var admin = _fachada.BuscarAdministradorNick(Context.User.Username);

                _fachada.SuspenderUsuario(email);

                await ReplyAsync($"El vendedor {email} fue suspendido.");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No existe un administrador con ese nick.");
            }

        }
    }
}