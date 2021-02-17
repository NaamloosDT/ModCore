using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModCore.Localization
{
    public class Locale
    {
        public string LocaleCode = Const.DEFAULT_LOCALE_CODE;

        public string Translator = "Naamloos#2887";

        public string AboutTitle = "About ModCore";

        public string AboutText = "ModCore is a powerful moderating bot written on top of DSharpPlus. It serves as a moderating assistant to make managing your server as easy as possible. Adding ModCore to your server today will open up a world of moderation options to you.";

        public string SpecialThanks = "Thank you to the people that have contributed to ModCore in the past:";

        public string ChangedPrefix = "Changed prefix to `{0}`.";

        public string LocaleNotFound = "Locale `{0}` doesn't exist!";

        public string ChangedLocale = "Changed locale for this guild to `{0}`.";
    }
}
