using ModCore.Bot;
using ModCore.Config;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ModCore
{
    class Entry
    {
        static async Task Main(string[] args)
        {
            var botConfig = ConfigLoader.LoadBotConfig();
            var connectionConfig = ConfigLoader.LoadConnectionConfig();

            if (string.IsNullOrWhiteSpace(connectionConfig.Token))
            {
                Console.WriteLine("Please fill out all config files.");
                Console.ReadKey();
                return;
            }

            var bot = new DiscordBot(connectionConfig, botConfig);
        }
    }
}
