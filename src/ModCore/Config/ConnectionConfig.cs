using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModCore.Config
{
    public class ConnectionConfig
    {
        [JsonProperty("token")]
        public string Token { get; } = "";

        [JsonProperty("shardcount")]
        public int ShardCount { get; } = 1;
    }
}
