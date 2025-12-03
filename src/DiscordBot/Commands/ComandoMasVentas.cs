using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoMasVentas : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoMasVentas()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando "vendedorConMasVentas'.
        /// </summary>
        [Command("vendedorConMasVentas")]
        [Summary(
            "Muestra el vendedor con más ventas y calcula el bono que le corresponde. Uso !vendedorConMasVentas")]

        public async Task VendedorConMasVentas()
        {
            try
            {
                Usuario admin = _fachada.BuscarAdministradorNick(Context.User.Username);
                // Esto ya que lo debe hacer el administrador
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No existe un administrador con ese nick.");
                return;
            }

            try
            {
                Vendedor masventas = _fachada.VendedorConMasVentas();
                await ReplyAsync(
                    $"**{masventas.ObtenerNombre()} {masventas.ObtenerApellido()}** es el vendedor con más ventas.\nLe corresponde un bono de **${_fachada.CalcularBonoMasVentas()}**.");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No existe un administrador con ese nick.");
            }

        }
    }
    public class ComandoVentasDelVendedor : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoVentasDelVendedor()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }

        /// <summary>
        /// Implementa el comando "vendedorConMasVentas'.
        /// </summary>
        [Command("ventasDelVendedor")]
        [Summary(
            "Muestra la cantidad del ventas de un vendedor. Uso !ventasDelVendedor nick")]

        public async Task ExecuteAsync(string nick)
        {
            try
            {
                Usuario admin = _fachada.BuscarAdministradorNick(Context.User.Username);
                // Esto ya que lo debe hacer el administrador
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No existe un administrador con ese nick.");
                return;
            }

            try
            {
                Vendedor vendedor = _fachada.BuscarVendedorNick(nick);
                await ReplyAsync(
                    $"**El vendedor {vendedor.ObtenerNombre()} {vendedor.ObtenerApellido()}** realizó **{_fachada.CantidadVentasDelVendedor(nick)}** ventas.");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No existe un administrador con ese nick.");
            }

        }
    }
}
    