using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Discord.WebSocket;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoCotizacion : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoCotizacion()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando "cotizacion'.
        /// </summary>
        [Command("cotizacion")]
        [Summary(
            "Registra una nueva cotización. Uso !cotizacion correo fecha tema notas precio")]
        // Toma el nick del vendedor(el que mando el mensaje) y el email del cliente a asignar y los datos de la cotización

        public async Task RealizarCotizacion(string correo, DateTime fecha, string tema, string notas, int precio)
        {
            try
            {
                _fachada.RealizarCotizacion(Context.User.Username, correo, fecha, tema, notas, precio);
                await ReplyAsync($"La cotización realizada con el cliente {_fachada.BuscarPorEmail(correo).ObtenerNombre()} por el vendedor {_fachada.BuscarVendedorNick(Context.User.Username)} fue registrada con éxito.");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
        
    }
    public class ComandoVenta : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoVenta()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando "asignarCliente'.
        /// </summary>
        [Command("venta")]
        [Summary(
            "Registra una nueva venta. Uso !venta correo tema")]
        // Pide y el email del cliente a asignar y los datos de la venta

        public async Task RealizaVenta(string correo, string tema)
        {
            try
            {
                _fachada.RealizarVenta(correo, tema);

                await ReplyAsync($"La venta realizada con el cliente {_fachada.BuscarPorEmail(correo).ObtenerNombre()} fue registrada con éxito.");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
        
    }
}