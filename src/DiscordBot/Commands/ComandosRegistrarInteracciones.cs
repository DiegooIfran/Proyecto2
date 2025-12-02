using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Discord.WebSocket;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandosRegistrarInteracciones : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosRegistrarInteracciones()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando 'registrarLlamada'.
        /// </summary>
        [Command("registrarLlamada")]
        [Summary(
            "Registro una llamada. Uso !registrarLlamada correo, fecha, tema, nota, enviada")]
        // enviada debe ser true o false
        
        public async Task RegistrarLLamada(string correo, DateTime fecha, string tema, string nota, bool enviada)
        {
            if(_fachada.BuscarVendedorNick(Context.User.Username).Activo != false)
            {
                try
                {
                    _fachada.RegistrarLlamada(Context.User.Username, correo, fecha, tema, nota, enviada);

                    await ReplyAsync($"La interaccion **{tema}** fue creada con exito.");
                }
                catch (InvalidOperationException)
                {
                    await ReplyAsync("Un dato fue invalido");
                }
            }
            else
            {
                await ReplyAsync("El vendedor esta suspendido");

            }
        }
        
        /// <summary>
        /// Implementa el comando 'registarMensaje'.
        /// </summary>
        [Command("registrarMensaje")]
        [Summary(
            "Registro un mensaje. Uso !registrarMensaje correo, fecha, tema, nota, enviada")]
        // enviada debe ser true o false
        
        public async Task RegistrarMensaje(string correo, DateTime fecha, string tema, string nota, bool enviada)
        {
            try
            {
                _fachada.RegistrarMensaje(Context.User.Username, correo, fecha, tema, nota, enviada);

                await ReplyAsync($"La interaccion **{tema}** fue creada con exito.");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("Un dato fue invalido");
            }

        }
        
        /// <summary>
        /// Implementa el comando 'registarCorreo'.
        /// </summary>
        [Command("registrarCorreo")]
        [Summary(
            "Registro un email. Uso !registrarCorreo correo, fecha, tema, nota, enviada")]
        // enviada debe ser true o false
        
        public async Task RegistrarCorreo(string correo, DateTime fecha, string tema, string nota, bool enviada)
        {
            try
            {
                _fachada.RegistrarCorreo(Context.User.Username, correo, fecha, tema, nota, enviada);

                await ReplyAsync($"La interaccion **{tema}** fue creada con exito.");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("Un dato fue invalido");
            }

        }
        
        /// <summary>
        /// Implementa el comando 'registarReunion'.
        /// </summary>
        [Command("registrarReunion")]
        [Summary(
            "Registro una reunion. Uso !registrarReunion correo, fecha, tema, nota")]
        
        public async Task RegistrarReunion(string correo, DateTime fecha, string tema, string nota)
        {
            try
            {
                _fachada.RegistrarReunion(Context.User.Username, correo, fecha, tema, nota);

                await ReplyAsync($"La interaccion **{tema}** fue creada con exito.");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("Un dato fue invalido");
            }

        }
    }
    
    
}