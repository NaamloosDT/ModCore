using Microsoft.Extensions.Hosting;
using ModCore.Bot;
using ModCore.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModCore.Services
{
    public class TimerService : BackgroundService
    {
        private DiscordBot bot;
        private DatabaseConnectionProvider database;

        public TimerService(DiscordBot bot, DatabaseConnectionProvider database)
        {
            this.bot = bot;
            this.database = database;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
