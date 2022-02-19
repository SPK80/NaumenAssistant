using System;
using System.Collections.Generic;
using SPKCollections;

namespace ListScripts
{
    public class TableEventArgs : EventArgs
    {
        public TableEventArgs()
        {
            Table = null;
            InputValues = null;
        }

        public TableEventArgs(IEnumerable<string[]> table, Dictionary<string, string> inputValues)
        {
            Table = table;
            InputValues = inputValues;
        }

        public IEnumerable<string[]> Table { get; set; }
        public Dictionary<string, string> InputValues { get; }

    }
}

