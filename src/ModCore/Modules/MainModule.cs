using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Modules
{
    public class MainModule
    {
        [Command("ping")]
        public async Task PingAsync(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"⏰ Pong! {ctx.Client.Ping} ms.");
        }
    }
}
