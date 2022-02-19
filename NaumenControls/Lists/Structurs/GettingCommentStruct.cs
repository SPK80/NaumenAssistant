using System;

namespace NaumenControls.Lists.Structures
{
    public class GettingCommentStruct: IDataStruct
    {
        private const int propertiesCount = 3;

        public GettingCommentStruct(int ls, params string[] values)
        {
            LS = ls;

            if (values.Length > 0) Date = values[0];
            if (values.Length > 1) Text = values[1];
            if (values.Length > 2) Author = values[2];
        }

        public int LS { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public string[] GetAllData() => new string[propertiesCount] { Date, Text, Author };
    }
}