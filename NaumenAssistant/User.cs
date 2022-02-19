using System;
using CommonLib;
using CommonLib.Config;

namespace NaumenAssistant
{
    public static class User
    {
        public static string Name
        {
            get =>userSettings?["UserName"]??"";
            set
            {
                if (userSettings == null) return;
                userSettings["UserName"] = value;
            }
        }
        public static string Password
        {
            get
            {
                try
                {
                    return Encrypter.UnEncrypt(userSettings?["Password"] ?? "");
                }
                catch { return ""; }                
            }
            set
            {
                if (userSettings == null) return;
                try
                {
                    userSettings["Password"] = Encrypter.Encrypt(value);
                }
                catch{ }                
            }
        }
        private static ISettingsCatalog userSettings;
        internal static void Init(ISettingsCatalog UserSettings)
        {
            userSettings = UserSettings;
        }
    }
}
