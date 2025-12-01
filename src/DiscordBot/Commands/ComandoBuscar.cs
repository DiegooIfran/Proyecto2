using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoBuscarClientePorEmail : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoBuscarClientePorEmail()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'buscarClientePorEmail'.
        /// </summary>
        [Command("buscarClientePorEmail")]
        [Summary(
            "Busca un cliente por Email. Usa buscarClientePorEmail email")]
            
        public async Task ExecuteAsync(string email)
        {
            try
            {
                await ReplyAsync($"El cliente con el email **{email}** es **{_fachada.BuscarPorEmail(email)}**.");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
    public class ComandoBuscarClientePorTelefono : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoBuscarClientePorTelefono()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'buscarClientePorTelefono'.
        /// </summary>
        [Command("buscarClientePorTelefono")]
        [Summary(
            "Busca un cliente por Telefono.")]
            
        public async Task ExecuteAsync(string telefono)
        {
            try
            {
                await ReplyAsync($"El cliente con el teléfono **{telefono}** es **{_fachada.BuscarPorTelefono(telefono)}**.");
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
    public class ComandoBuscarClientePorNombre : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoBuscarClientePorNombre()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'buscarClientePorNombre'.
        /// </summary>
        [Command("buscarClientePorNombre")]
        [Summary(
            "Busca un cliente por Nombre.")]
            
        public async Task ExecuteAsync(string name)
        {
            List<Cliente> clientes = _fachada.BuscarPorNombre(name);
            try
            {
                await ReplyAsync($"Los clientes con el nombre **{name}** son: ");
                foreach (Cliente cliente in clientes)
                {
                    await ReplyAsync($"**{cliente}**");
                }
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
    public class ComandoBuscarClientePorApellido : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoBuscarClientePorApellido()
        {
            this._fachada = Singleton<Fachada>.Instance;
        }
        /// <summary>
        /// Implementa el comando 'buscarClientePorApellido'.
        /// </summary>
        [Command("buscarClientePorApellido")]
        [Summary(
            "Busca un cliente por apellido.")]
            
        public async Task ExecuteAsync(string apellido)
        {
            List<Cliente> clientes = _fachada.BuscarPorApellido(apellido);
            try
            {
                await ReplyAsync($"Los clientes con el apellido **{apellido}** son: ");
                foreach (Cliente cliente in clientes)
                {
                    await ReplyAsync($"**{cliente}**");
                }
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
}