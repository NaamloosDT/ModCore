using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using ModCore.Database;
using ModCore.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Modules
{
    public class MainModule : BaseCommandModule
    {
        private LocaleManager locales;
        private DatabaseConnectionProvider database;

        public MainModule(LocaleManager locales, DatabaseConnectionProvider database)
        {
            this.locales = locales;
            this.database = database;
        }

        [Command("ping")]
        public async Task PingAsync(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"⏰ Pong! {ctx.Client.Ping} ms.");
        }

        [Command("about")]
        public async Task AboutAsync(CommandContext ctx)
        {
            var dbcon = database.GetConnection();
            var cfg = await dbcon.GetGuildConfig(ctx.Guild.Id);
            var data = cfg.GetData();
            var locale = locales.GetLocale(data.Locale);

            var embed = new DiscordEmbedBuilder()
                .WithTitle(locale.AboutTitle)
                .WithDescription(locale.AboutText)
                .AddField(locale.SpecialThanks, Const.CONTRIBS);

            await ctx.RespondAsync(embed);
        }
    }
}
