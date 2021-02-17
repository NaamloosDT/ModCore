using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Logging;
using ModCore.Config;
using ModCore.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Bot
{
    /// <summary>
    /// Represents one separate connection to Discord.
    /// </summary>
    public class DiscordShard
    {
        private DiscordClient client;
        private CommandsNextExtension commands;
        private BotConfig config;
        private int shardId;

        public DiscordShard(int shardCount, int shardId, string token, BotConfig config)
        {
            this.shardId = shardId;
            this.config = config;
            client = new DiscordClient(new DiscordConfiguration()
            {
                ShardCount = shardCount,
                ShardId = shardId,
                Token = token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,

                MinimumLogLevel = LogLevel.Debug // always using debug log level, so I can more quickly resolve issues causes in production.
            });

            commands = client.UseCommandsNext(new CommandsNextConfiguration()
            {
                EnableDefaultHelp = false,
                PrefixResolver = resolvePrefix,
                CaseSensitive = false,
                EnableMentionPrefix = true,
                EnableDms = false,
                UseDefaultCommandHandler = true
            });

            commands.RegisterCommands<MainModule>();
        }

        public Task<int> resolvePrefix(DiscordMessage msg)
        {
            // For further extension with custom prefixes.
            return Task.FromResult(msg.GetStringPrefixLength(config.DefaultPrefix));
        }

        public async Task ConnectAsync()
        {
            await client.ConnectAsync();
        }
    }
}
