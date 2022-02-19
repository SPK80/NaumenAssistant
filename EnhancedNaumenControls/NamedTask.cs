using System;
using System.Collections.Generic;

namespace EnhancedNaumenControls
{
    public class NamedTask
    {
        private Func<IEnumerable<string[]>, IEnumerable<string[]>> func;
        
        private string name;

        public NamedTask(string name, Func<IEnumerable<string[]>, IEnumerable<string[]>> func)
        {
            this.func = func ?? throw new ArgumentNullException(nameof(func));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public IEnumerable<string[]> Exec(IEnumerable<string[]> data)
        {
            return func(data);
        }
        public override string ToString()
        {
            return name;
        }
    }

}
