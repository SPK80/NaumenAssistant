using System;
using System.Collections.Generic;
using System.Linq;
using NaumenAPI.Drivers;
using SPKCollections;

namespace NaumenAPI
{
    public abstract class NaumenTab : NaumenBase
    {
        protected NaumenTab(NaumenDriver naumenDriver) : base(naumenDriver)
        {
        }

        public abstract string[] Header { get; } //=> Descriptor.Values.ToArray();
        //public abstract string[] InputFields { get; }

        //protected NaumenLS naumenLS;


        //public NaumenTab(NaumenLS naumenLS)
        //{
        //    this.naumenLS = naumenLS ?? throw new ArgumentNullException(nameof(naumenLS));
        //    //initDescriptor();
        //}

        public abstract IEnumerable<string[]> Items { get; }

    }


}
