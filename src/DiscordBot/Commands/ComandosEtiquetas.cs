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
        /// Implementa el comando 'ModificarNombre'.
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
}