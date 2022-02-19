using System.IO;

namespace NaumenAssistant.Scripts
{
    public class NaumenScriptSettings
    {
        public static string Directory = "scripts";
        public static string Extention = ".nscr";

        public static string Path(string name)
        {
            return System.IO.Path.Combine(Directory, name + Extention);
        }
    }
}
