using System;
using System.Linq;
using CommonLib.Config;

namespace NaumenAssistant
{
    public static class ScriptsSettings
    {
        private static ISettingsCatalog settingsCatalog;
        internal static void Init(ISettingsCatalog catalog)
        {
            settingsCatalog = catalog;
        }

        public static string[] Items
        {
            get=> settingsCatalog["Scripts"].
                Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries).
                Select(s => s.Trim(' ', '\t', '\n')).ToArray();
            set
            {
                if (value!=null)
                try
                {
                    settingsCatalog["Scripts"] = value.Aggregate((s1, s2) => s1 + "," + s2);
                }
                catch
                {
                    settingsCatalog["Scripts"] = "";
                }
                    
            }
        }
            

    }
}
