using Newtonsoft.Json;
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
    }
}
