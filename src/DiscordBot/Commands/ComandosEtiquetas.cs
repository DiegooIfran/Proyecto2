using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandosCrearEtiqueta : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosCrearEtiqueta(Fachada fachada)
        {
            _fachada = fachada;
        }
        /// <summary>
        /// Implementa el comando 'CrearEtiqueta'.
        /// </summary>
        [Command("crearEtiqueta")]
        [Summary("Crea una etiqueta. Uso: !crearEtiqueta nombre descripcion")]
        public async Task ExecuteAsync(string nombre, [Remainder] string descripcion)
        {
            try
            {
                _fachada.CrearEtiqueta(nombre, descripcion);

                await ReplyAsync($"Etiqueta **{nombre}** creada correctamente.\n📝 Descripción: {descripcion}");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
    
    public class ComandosAgregarEtiqueta : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosAgregarEtiqueta(Fachada fachada)
        {
            _fachada = fachada;
        }
        /// <summary>
        /// Implementa el comando 'AgregarEtiqueta'.
        /// </summary>
        [Command("agregarEtiqueta")]
        [Summary("Agrega una etiqueta a un cliente. Uso: !agregarEtiqueta correoCliente nombreEtiqueta")]
        public async Task ExecuteAsync(string correoCliente, [Remainder] string nombreEtiqueta)
        {
            try
            {
                _fachada.AgregarEtiqueta(correoCliente, nombreEtiqueta);

                await ReplyAsync($"Etiqueta **{nombreEtiqueta}** agregada correctamente a **{correoCliente}**.");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
    
    public class ComandosBorrarEtiqueta : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandosBorrarEtiqueta(Fachada fachada)
        {
            _fachada = fachada;
        }
        /// <summary>
        /// Implementa el comando 'BorrarEtiqueta'.
        /// </summary>
        [Command("borrarEtiqueta")]
        [Summary("Borra una etiqueta a un cliente. Uso: !borrarEtiqueta correoCliente nombreEtiqueta")]
        public async Task ExecuteAsync(string correoCliente, [Remainder] string nombreEtiqueta)
        {
            try
            {
                _fachada.BorrarEtiqueta(correoCliente, nombreEtiqueta);

                await ReplyAsync($"Etiqueta **{nombreEtiqueta}** borrada correctamente de **{correoCliente}**.");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
}