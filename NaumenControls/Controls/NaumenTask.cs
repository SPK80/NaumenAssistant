using System;
using System.Collections.Generic;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Controls
{
    public class NaumenTask : INaumenTask
    {
        private Func<IDataStruct, IEnumerable<string[]>> task;

        public StructType StructType { get; }
        public string Name { get; }

        public Type InputType => throw new NotImplementedException();
        public Type OutputType => throw new NotImplementedException();

        public NaumenTask(string name, StructType structType, Func<IDataStruct, IEnumerable<string[]>> task)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            StructType = structType;
            this.task = task ?? throw new ArgumentNullException(nameof(task));
        }

        public IEnumerable<string[]> Exec(IDataStruct dataStruct) => task(dataStruct);

        public override string ToString() => Name;
    }

    
}
