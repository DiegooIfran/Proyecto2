using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandosModificarNombre : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosModificarNombre(Fachada fachada)
        {
            _fachada = fachada;
        }
            /// <summary>
            /// Implementa el comando 'ModificarNombre'.
            /// </summary>
            [Command("modificarNombre")]
            [Summary(
                "Modifica el nombre de un cliente. Uso !modificarNombre email nombreNuevo")]
            // ReSharper disable once UnusedMember.Global
            public async Task ExecuteAsync(string email, string nombreNuevo)
            {
                try
                {
                    _fachada.ModificarNombre(email, nombreNuevo);

                    await ReplyAsync($"Nombre del cliente con email **{email}** actualizado a **{nombreNuevo}**");
                }
                catch (Exception ex)
                {
                    await ReplyAsync($"Error: {ex.Message}");
                }
            }
    }
    public class ComandosModificarApellido : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosModificarApellido(Fachada fachada)
        {
            _fachada = fachada;
        }
        /// <summary>
        /// Implementa el comando 'modificarApellido'.
        /// </summary>
        [Command("modificarApellido")]
        [Summary(
            "Modifica el nombre de un cliente. Uso !modificarNombre email apellidoNuevo")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync(string email, string apellidoNuevo)
        {
            try
            {
                _fachada.ModificarNombre(email, apellidoNuevo);

                await ReplyAsync($"Nombre del cliente con email **{email}** actualizado a **{apellidoNuevo}**");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
}