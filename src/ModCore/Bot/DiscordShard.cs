using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Logging;
using ModCore.Config;
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
        private BotConfig config;

        public DiscordShard(int shardCount, int shardId, string token, BotConfig config)
        {
            client = new DiscordClient(new DiscordConfiguration()
            {
                ShardCount = shardCount,
                ShardId = shardId,
                Token = token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,

                // Use different logging levels for releases and debugging.
                #if RELEASE
                MinimumLogLevel = LogLevel.Information,
                #elif DEBUG
                MinimumLogLevel = LogLevel.Trace,
                #endif
            });

            client.UseCommandsNext(new CommandsNextConfiguration()
            {
                EnableDefaultHelp = false,
                PrefixResolver = resolvePrefix,
                CaseSensitive = false,
                EnableMentionPrefix = true,
                EnableDms = false,
                UseDefaultCommandHandler = true
            });
        }

        public Task<int> resolvePrefix(DiscordMessage msg)
        {
            // For further extension with custom prefixes.
            return Task.FromResult(msg.GetStringPrefixLength(config.DefaultPrefix));
        }

        public async Task ConnectAsync()
        {

        }
    }
}
