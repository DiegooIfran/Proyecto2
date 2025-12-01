using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoInteracciones: ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;
    
        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoInteracciones()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        
        /// <summary>
        /// Implementa el comando 'VerInteraccionesCliente'.
        /// </summary>
        [Command("verInteraccionesCliente")]
        [Summary(
            "Muestra las interacciones de un cliente. Uso !verInteraccionesCliente email")]
        // ReSharper disable once UnusedMember.Global

        public async Task ExecuteAsync(string correo)
        {
            try
            {
                var cliente = _fachada.BuscarPorEmail(correo);
                var interacciones = cliente.ObtenerInteracciones(); 

                if (interacciones.Count == 0)
                {
                    await ReplyAsync("Este cliente no tiene interacciones registradas");
                    return;
                }
                
                var texto = string.Join("\n", interacciones.Select(i => i.ObtenerTema()));
                await ReplyAsync(texto);
            }
            
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }

    }
}