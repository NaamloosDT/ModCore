using ConcurrentCollections;
using ModCore.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCore.Localization
{
    public class LocaleManager
    {
        private BotConfig config;
        private ConcurrentHashSet<Locale> locales;

        public LocaleManager(BotConfig config)
        {
            this.config = config;
            this.locales = new ConcurrentHashSet<Locale>();
        }

        public void PreloadLocales()
        {
            var localepath = Path.Combine(Environment.CurrentDirectory, Const.LOCALE_FOLDER);

            if (!Directory.Exists(localepath))
                Directory.CreateDirectory(localepath);

            var defaultlocale = Path.Combine(localepath, Const.DEFAULT_LOCALE);

            if (!File.Exists(defaultlocale))
            {
                File.Create(defaultlocale).Close();
                File.WriteAllText(defaultlocale, JsonConvert.SerializeObject(new Locale()));
            }

            var localefiles = Directory.GetFiles(localepath).Where(x => x.EndsWith(".json"));
            foreach (var file in localefiles)
            {
                Locale loc;

                using (var fs = File.OpenRead(file))
                using (var sr = new StreamReader(fs))
                {
                    loc = JsonConvert.DeserializeObject<Locale>(sr.ReadToEnd());
                    locales.Add(loc);
                }

                // Ensuring new defaults are written to file.
                File.WriteAllText(file, JsonConvert.SerializeObject(loc));
            }
        }

        public Locale GetLocale(string locale)
        {
            if (!locales.Any(x => x.LocaleCode == locale))
            {
                return locales.First(x => x.LocaleCode == Const.DEFAULT_LOCALE_CODE);
            }

            return locales.First(x => x.LocaleCode == locale);
        }

        public bool Exists(string locale)
        {
            return locales.Any(x => x.LocaleCode == locale);
        }
    }
}
