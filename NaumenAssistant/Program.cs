using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib.Config;
using CommonLib.LogHelper;
using NaumenAPI;

namespace NaumenAssistant
{
    static class Program
    {
        //public static ISettingsCatalog ScriptsSettings { get; private set; }
        //public static ISettingsCatalog UserSettings { get; private set; }
        //public static NaumenApi NaumenApi { get; private set; }

        private const string configFile = "config.ini";
        private static SettingsManager settings;

        [STAThread]
        static void Main()
        {

            settings = new SettingsManager(new ConfigStorge(configFile));
            settings.Load();
            //UserSettings = settings.GetCatalog("User");
            User.Init(settings.GetCatalog("User"));
            ScriptsSettings.Init(settings.GetCatalog("Scripts"));

            //using (new NaumenApi(User.Name, User.Password))
            //{
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                catch (Exception ex)
                {
                    Log.Write(ex, "Общая ошибка");
                    Dispose();
                }
                finally
                {
                    Dispose();
                }
            //}            

        }

        static void Dispose()
        {
            if (settings != null)
            {
                settings.Save();
                settings = null;
            }
        }
    }
}
