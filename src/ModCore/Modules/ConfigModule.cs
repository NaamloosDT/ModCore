using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using ModCore.Database;
using ModCore.Database.Entities.Database;
using ModCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Modules
{
    [Group("config")]
    [Aliases("cfg")]
    [Description("Guild configuration options. Invoking without a subcommand will list current guild's settings.")]
    [RequireUserPermissions(Permissions.ManageGuild)]
    public partial class ConfigModule : BaseCommandModule
    {
        private DatabaseConnectionProvider database;
        private LocaleManager locales;

        public ConfigModule(DatabaseConnectionProvider database, LocaleManager locales)
        {
            this.database = database;
            this.locales = locales;
        }

        [Command("prefix")]
        public async Task PrefixAsync(CommandContext ctx, string prefix)
        {
            var dbcon = database.GetConnection();
            var cfg = await dbcon.GetGuildConfig(ctx.Guild.Id);
            var data = cfg.GetData();
            var locale = locales.GetLocale(data.Locale);

            data.Prefix = prefix;
            cfg.SetData(data);

            dbcon.UpdateGuildConfig(cfg);

            await ctx.RespondAsync(string.Format(locale.ChangedPrefix, prefix));
        }

        [Command("locale")]
        public async Task LocaleAsync(CommandContext ctx, string locale)
        {
            var dbcon = database.GetConnection();
            var cfg = await dbcon.GetGuildConfig(ctx.Guild.Id);
            var data = cfg.GetData();
            var oldlocale = locales.GetLocale(data.Locale);

            if (!locales.Exists(locale.ToUpper()))
            {
                await ctx.RespondAsync(string.Format(oldlocale.LocaleNotFound, locale));
            }

            var newlocale = locales.GetLocale(locale.ToUpper());
            data.Locale = locale.ToUpper();
            cfg.SetData(data);

            dbcon.UpdateGuildConfig(cfg);

            await ctx.RespondAsync(string.Format(newlocale.ChangedPrefix, locale));
        }
    }
}
