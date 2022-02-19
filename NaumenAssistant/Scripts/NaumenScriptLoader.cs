using ListScripts;

namespace NaumenAssistant.Scripts
{
    public class NaumenScriptFile : ListScriptFile
    {
        public string[] Operations => operations;
        public string[] InputFields => inputFields;

        public NaumenScriptFile(string name) :
            base(NaumenScriptSettings.Path(name))
        {
        }

        public NaumenScriptFile(string path, string[] inputFields, string[] operations) : 
            base(path, inputFields, operations)
        {
        }
    }

}