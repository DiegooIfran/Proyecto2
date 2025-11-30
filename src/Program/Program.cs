using Discord;
using Discord.WebSocket;
using Library;
using Ucu.Poo.DiscordDemo.DiscordBot.Services;

namespace Program;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>

    /// <summary>
    /// Un programa que implementa un bot de Discord.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        private static void Main(string [] args)
        {
            if (args.Length != 0)
            {
                DemoFacade(args);
            }
            else
            {
                DemoBot();
            }
        }

        private static void DemoFacade(string [] args)
        {
            if (args.Length > 0)
            {
                // línea simple en Main/DemoFacade
             //   Console.WriteLine(Singleton<Fachada>.Instance.BuscarPorEmail(args[0])?.ToString() ?? "Cliente no encontrado");

            }
        }

        private static void DemoBot()
        {
            BotLoader.LoadAsync().GetAwaiter().GetResult();
        }
    }

