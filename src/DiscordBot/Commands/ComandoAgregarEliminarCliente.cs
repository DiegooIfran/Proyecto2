namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    using System;
    using System.Threading.Tasks;
    using Discord.Commands;
    using Library;

    namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
    {
        public class ComandoAgregarCliente : ModuleBase<SocketCommandContext>
        {
            private readonly Fachada _fachada;

            // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
            public ComandoAgregarCliente()
            {
                this._fachada = Singleton<Fachada>.Instance;
            }
            /// <summary>
            /// Implementa el comando 'agregarCliente'.
            /// </summary>
            [Command("agregarCliente")]
            [Summary(
                "Agrega un cliente a la lista de clientes.")]
            
            public async Task ExecuteAsync(string name, string apellido, string telefono, string email, string genero,
                DateTime fechaNacimiento)
            {
                try
                {
                    _fachada.AgregarCliente( name, apellido, telefono, email, genero, fechaNacimiento);

                    await ReplyAsync($"El nuevo cliente fue registrado con éxito.");
                }
                catch (Exception ex)
                {
                    await ReplyAsync($"Error: {ex.Message}");
                }
            }
        }
        
        public class ComandoEliminarCliente : ModuleBase<SocketCommandContext>
        {
            private readonly Fachada _fachada;

            // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
            public ComandoEliminarCliente()
            {
                this._fachada = Singleton<Fachada>.Instance;
            }
            /// <summary>
            /// Implementa el comando 'eliminarCliente'.
            /// </summary>
            [Command("eliminarCliente")]
            [Summary(
                "Elimina un cliente a la lista de clientes.")]
            
            public async Task ExecuteAsync(string email)
            {
                try
                {
                    _fachada.EliminarCliente(email);

                    await ReplyAsync($"El cliente con email {email} fue eliminado con éxito.");
                }
                catch (Exception ex)
                {
                    await ReplyAsync($"Error: {ex.Message}");
                }
            }
        }
        public class ComandoAsignarCliente : ModuleBase<SocketCommandContext>
        {
            private readonly Fachada _fachada;

            // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
            public ComandoAsignarCliente()
            {
                this._fachada = Singleton<Fachada>.Instance;
            }
            /// <summary>
            /// Implementa el comando 'asignarCliente'.
            /// </summary>
            [Command("asignarCliente")]
            [Summary(
                "Asigna un cliente a un vendedor.")]
            public async Task ExecuteAsync(string nickVendedor, string correoCliente)
            {
                try
                {
                    _fachada.AsignarCliente(nickVendedor, correoCliente);

                    await ReplyAsync($"El cliente con email {correoCliente} fue asignado a {nickVendedor} con éxito.");
                }
                catch (Exception ex)
                {
                    await ReplyAsync($"Error: {ex.Message}");
                }
            }
        }
    }
}