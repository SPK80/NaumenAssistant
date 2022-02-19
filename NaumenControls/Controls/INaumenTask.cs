using System;
using System.Collections.Generic;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Controls
{
    public interface INaumenTask
    {
        string Name { get; }
        StructType StructType { get; }
        //Type InputType { get; }
        //Type OutputType { get; }
        IEnumerable<string[]> Exec(IDataStruct dataStruct);
    }
}