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
        public static ConnectionConfig LoadConnectionConfig() => loadConfigFile<ConnectionConfig>(Const.CONNECTION_CONFIG);

        public static BotConfig LoadBotConfig() =>loadConfigFile<BotConfig>(Const.BOT_CONFIG);

        private static T loadConfigFile<T>(string filename) where T : new()
        {
            var path = Path.Combine(Environment.CurrentDirectory, filename);
            if (!File.Exists(path))
            {
                using (var fs = File.Create(path))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonConvert.SerializeObject(new T()));
                }
            }
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}
