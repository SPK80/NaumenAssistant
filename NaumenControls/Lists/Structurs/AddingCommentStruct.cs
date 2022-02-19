using System;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Lists.Structurs
{
    public class AddingCommentStruct : IDataStruct
    {
        private const int propertiesCount = 1;

        public AddingCommentStruct(int lS, params string[] values)
        {
            LS = lS;
            if (values.Length > 0) Text = values[0];
        }

        public int LS { get ; set; }
        public string Text { get; set; }
        public string[] GetAllData()
        {
            return new string[propertiesCount] { Text };
        }
    }
}
