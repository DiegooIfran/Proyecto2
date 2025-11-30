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
        public ComandosModificarNombre()
        {
            this._fachada = Singleton<Fachada>.Instance;
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
        public ComandosModificarApellido()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'modificarApellido'.
        /// </summary>
        [Command("modificarApellido")]
        [Summary(
            "Modifica el apellido de un cliente. Uso !modificarApellido email apellidoNuevo")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync(string email, string apellidoNuevo)
        {
            try
            {
                _fachada.ModificarApellido(email, apellidoNuevo);

                await ReplyAsync($"Apellido del cliente con email **{email}** actualizado a **{apellidoNuevo}**");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
    
    public class ComandosModificarTelefono : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosModificarTelefono()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'modificarTelefono'.
        /// </summary>
        [Command("modificarTelefono")]
        [Summary(
            "Modifica el telefono de un cliente. Uso !modificarTelefono email telefonoNuevo")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync(string email, string telefonoNuevo)
        {
            try
            {
                _fachada.ModificarTelefono(email, telefonoNuevo);

                await ReplyAsync($"Telefono del cliente con email **{email}** actualizado a **{telefonoNuevo}**");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
    
    public class ComandosModificarEmail : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosModificarEmail()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'modificarEmail'.
        /// </summary>
        [Command("modificarEmail")]
        [Summary(
            "Modifica el email de un cliente. Uso !modificarEmail email emailNuevo")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync(string email, string emailNuevo)
        {
            try
            {
                _fachada.ModificarEmail(email, emailNuevo);

                await ReplyAsync($"Email del cliente con email **{email}** actualizado a **{emailNuevo}**");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
}