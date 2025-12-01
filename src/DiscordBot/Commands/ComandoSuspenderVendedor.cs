using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoSuspenderVendedor : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectas la fachada por constructor (recomendado en Discord.NET con DI)
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
            
            var lista = Singleton<Gestor<Administrador>>.Instance.VerTotal();

            string debug = "Admins en sistema:\n";
            foreach (var a in lista)
                debug += "- " + a.ObtenerNick() + a.ObtenerNick().Length + "\n";

            await ReplyAsync(debug);
            await ReplyAsync(Context.User.Username + Context.User.Username.Length());
            
            Usuario admin = null;

            try
            {
                admin = _fachada.BuscarAdministradorNick(Context.User.Username);
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No existe un administrador con ese nick.");
                return;
            }
            try
            {
                _fachada.SuspenderUsuario(email);
                await ReplyAsync($"El vendedor {email} fue suspendido.");
            }
            catch (InvalidOperationException)
            {
                await ReplyAsync("No existe un vendedor con ese email.");
            }
        }

        public class ComandoHabilitarVendedor : ModuleBase<SocketCommandContext>
        {
            private readonly Fachada _fachada;

            // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
            public ComandoHabilitarVendedor()
            {
                this._fachada = Singleton<Fachada>.Instance;
            }

            /// <summary>
            /// Implementa el comando 'habilitarVendedor'.
            /// </summary>
            [Command("habilitarVendedor")]
            [Summary(
                "Habilito a un vendedor. Uso !habilitarVendedor email")]

            public async Task HabilitarVendedor(string email)
            {
                try
                {
                    Usuario admin = _fachada.BuscarAdministradorNick(Context.User.Username);
                }
                catch (InvalidOperationException)
                {
                    await ReplyAsync("No existe un administrador con ese nick.");
                    return;
                }
                try
                {
                    _fachada.HabilitarUsuario(email);
                    await ReplyAsync($"El vendedor {email} fue habilitado.");
                }
                catch (InvalidOperationException)
                {
                    await ReplyAsync("No existe un vendedor con ese email.");
                }

            }
        }
    }
}