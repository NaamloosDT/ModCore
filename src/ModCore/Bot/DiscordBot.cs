using ConcurrentCollections;
using ModCore.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModCore.Bot
{
    public class DiscordBot
    {
        private ConcurrentHashSet<DiscordShard> shards;

        public DiscordBot(ConnectionConfig connection, BotConfig bot)
        {
            shards = new ConcurrentHashSet<DiscordShard>();
            for(int i = 0; i < connection.ShardCount; i++)
            {
                shards.Add(new DiscordShard(connection.ShardCount, i, connection.Token, bot));
            }
        }
    }
}
