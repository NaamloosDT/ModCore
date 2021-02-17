using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Database.Entities.Json
{
    public class GuildConfig
    {
        public string Prefix { get; set; }

        public string Locale { get; set; } = "EN";
    }
}
