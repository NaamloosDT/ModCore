using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Database.Entities.Database
{
    public class DatabaseTimer : JsonDatabaseEntity<object>
    {
        public ulong UserId;
        public ulong ChannelId;
        public ulong Dispatch;
    }
}
