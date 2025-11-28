using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Discord.WebSocket;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoAsignarCliente : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoAsignarCliente(Fachada fachada)
        {
            _fachada = fachada;
        }

        /// <summary>
        /// Implementa el comando "asignarCliente'.
        /// </summary>
        [Command("asignarCliente")]
        [Summary(
            "Suspendo a un vendedor. Uso !asignarCliente nick, email")]
        // Pide el nick del vendedor y el email del cliente a asignar

        public async Task AsignarCliente(string nick, string email)
        {
            try
            {
                var admin = _fachada.BuscarAdministradorNick(Context.User.Username);
                // Esto ya que lo debe hacer el administrador
                _fachada.AsignarCliente(nick , email);

                await ReplyAsync($"El cliente {_fachada.BuscarPorEmail(email).ObtenerNombre()} {_fachada.BuscarPorEmail(email).ObtenerApellido()} fue asignado al vendedor {_fachada.BuscarVendedorNick(nick)}");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("❌ No existe un administrador con ese nick.");
            }

        }
    }
}