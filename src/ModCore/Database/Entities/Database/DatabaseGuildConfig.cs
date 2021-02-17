using Microsoft.EntityFrameworkCore;
using ModCore.Database.Entities.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Database.Entities.Database
{
    public class DatabaseGuildConfig : JsonDatabaseEntity<GuildConfig>
    {
        [Key]
        [Column("guild_id")]
        [Required]
        public ulong GuildId { get; set; }
    }
}
