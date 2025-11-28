using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordDemo.DiscordBot.Commands
{
    public class ComandoCrearVendedor : ModuleBase<SocketCommandContext>
    {
        private readonly Fachada _fachada;

        // Inyectás la fachada por constructor (recomendado en Discord.NET con DI)
        public ComandoCrearVendedor(Fachada fachada)
        {
            _fachada = fachada;
        }

        /// <summary>
        /// Implementa el comando 'CrearVendedor'.
        /// </summary>
        [Command("crearVendedor")]
        [Summary(
            "Creo un vendedor. Uso !crearVendedor nombre apellido telefono email nick")]

        public async Task CrearVendedorAsync(string nombre, string apellido, string telefono, string email, string nick)
        {
            try
            {
                _fachada.CrearVendedor(nombre, apellido, telefono, email, nick);

                await ReplyAsync(
                    $"Vendedor creado:\n" +
                    $"- **Nombre:** {nombre} {apellido}\n" +
                    $"- **Teléfono:** {telefono}\n" +
                    $"- **Email:** {email}\n" +
                    $"- **Nick:** {nick}"
                );
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Implementa el comando 'CrearAdministrador'.
        /// </summary>
        [Command("crearAdministrador")]
        [Summary(
            "Creo un administrador. Uso !crearAdministrador nombre apellido telefono email nick")]
        // ReSharper disable once UnusedMember.Global
        public async Task CrearAdministradorAsync(string nombre, string apellido, string telefono, string email, string nick)
        {
            try
            {
                _fachada.CrearAdministrador(nombre, apellido, telefono, email, nick);

                await ReplyAsync(
                    $"Administrador creado:\n" +
                    $"- **Nombre:** {nombre} {apellido}\n" +
                    $"- **Teléfono:** {telefono}\n" +
                    $"- **Email:** {email}\n" +
                    $"- **Nick:** {nick}"
                );
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Error: {ex.Message}");
            }
        }
    }
}