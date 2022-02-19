using System.Collections.Generic;

namespace ListScripts
{
    public class FailEventArgs : TableEventArgs
    {
        public FailEventArgs(IEnumerable<string[]> table, Dictionary<string, string> inputValues) : base(table, inputValues)
        {
        }

        public bool Continue { get; set; } = true;
    }
}

