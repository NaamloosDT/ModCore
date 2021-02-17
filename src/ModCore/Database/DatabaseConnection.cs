using Microsoft.EntityFrameworkCore;
using ModCore.Database.Entities.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Database
{
    public class DatabaseConnection : DbContext
    {
        public virtual DbSet<DatabaseGuildConfig> GuildConfigs { get; set; }

        private string connectionString;
        private DatabaseProvider provider;

        public DatabaseConnection(string connectionstring, DatabaseProvider provider)
        {
            connectionString = connectionstring;
            this.provider = provider;
        }

        public async Task<DatabaseGuildConfig> GetGuildConfig(ulong guild)
        {
            if (GuildConfigs.Any(x => x.GuildId == guild))
                return await GuildConfigs.FirstAsync(x => x.GuildId == guild);

            return (await GuildConfigs.AddAsync(new DatabaseGuildConfig() { GuildId = guild })).Entity;
        }

        public void UpdateGuildConfig(DatabaseGuildConfig config)
        {
            GuildConfigs.Update(config);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (provider)
            {
                default:
                case DatabaseProvider.SQLite:
                    optionsBuilder.UseSqlite($"Data Source = {Path.Combine(Environment.CurrentDirectory, "modcore_sqlite.db")};");
                    break;
                case DatabaseProvider.Postgres:
                    optionsBuilder.UseNpgsql(connectionString);
                    break;
            }
        }
    }
}
