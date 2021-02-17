using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ModCore.Config
{
    public static class ConfigLoader
    {
        public static ConnectionConfig LoadConnectionConfig() => JsonConvert.DeserializeObject<ConnectionConfig>(loadConfigFile<ConnectionConfig>("ConnectionConfig.json"));

        public static BotConfig LoadBotConfig() => JsonConvert.DeserializeObject<BotConfig>(loadConfigFile<BotConfig>("ConnectionConfig.json"));

        private static string loadConfigFile<T>(string path)
        {
            if (!File.Exists(path))
            {
                using (var fs = File.Create(path))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonConvert.SerializeObject(Activator.CreateInstance<T>()));
                }
            }
            return File.ReadAllText(path);
        }
    }
}
