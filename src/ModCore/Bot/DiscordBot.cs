using ConcurrentCollections;
using ModCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Bot
{
    public class DiscordBot
    {
        private DiscordShard[] shards;

        public DiscordBot(ConnectionConfig connection, BotConfig bot)
        {
            shards = new DiscordShard[connection.ShardCount];
            for(int i = 0; i < connection.ShardCount; i++)
            {
                shards[i] = new DiscordShard(connection.ShardCount, i, connection.Token, bot);
            }
        }

        public async Task StartAsync() => await Task.WhenAll(shards.Select(x => x.ConnectAsync()).ToArray());
    }
}
