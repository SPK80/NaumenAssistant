using System;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Lists.Structurs
{
    public class AddingFilesStruct : IDataStruct
    {
        private const int propertiesCount = 1;

        public AddingFilesStruct(int lS, params string[] values)
        {
            LS = lS;
            if (values.Length > 0) Path = values[0];
        }

        public int LS { get; set; }
        public string Path { get; set; }
        public string[] GetAllData()
        {
            return new string[propertiesCount] { Path };
        }
    }
}
