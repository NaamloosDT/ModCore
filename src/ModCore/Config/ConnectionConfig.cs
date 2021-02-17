using ModCore.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModCore.Config
{
    public class ConnectionConfig
    {
        [JsonProperty("token")]
        public string Token { get; private set; } = "";

        [JsonProperty("shardcount")]
        public int ShardCount { get; private set; } = 1;

        [JsonProperty("connectionstring")]
        public string ConnectionString { get; set; } = "";

        [JsonProperty("databaseprovider")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DatabaseProvider DatabaseProvider { get; set; } = DatabaseProvider.SQLite;
    }
}
