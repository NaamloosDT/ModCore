using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModCore.Config
{
    public class BotConfig
    {
        [JsonProperty("defaultprefix")]
        public string DefaultPrefix { get; private set; } = "$$";

        [JsonProperty("defaultlocale")]
        public string DefaultLocale { get; private set; } = "EN";
    }
}
