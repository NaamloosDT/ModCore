using ConcurrentCollections;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using ModCore.Config;
using ModCore.Database;
using ModCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Bot
{
    public class DiscordBot
    {
        private DiscordShard[] shards;
        private LocaleManager locales;
        private DatabaseConnectionProvider database;

        public DiscordBot(ConnectionConfig connection, BotConfig bot)
        {
            // Find available modules
            var modules = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsInstanceOfType(typeof(BaseCommandModule)));

            locales = new LocaleManager(bot);
            locales.PreloadLocales();

            database = new DatabaseConnectionProvider(connection.ConnectionString, connection.DatabaseProvider);

            var services = new ServiceCollection()
                .AddSingleton(locales)
                .AddSingleton(database)
                .BuildServiceProvider();

            shards = new DiscordShard[connection.ShardCount];
            for(int i = 0; i < connection.ShardCount; i++)
            {
                shards[i] = new DiscordShard(connection.ShardCount, i, connection.Token, bot, services, modules);
            }
        }

        public async Task StartAsync() => await Task.WhenAll(shards.Select(x => x.ConnectAsync()).ToArray());
    }
}
