using System.Collections.Generic;
using System.Linq;
using CommonLib.TmpHelper;

namespace NaumenAssistant.Scripts
{
    public class NaumenTmpWriter
    {
        private Tmp tmp;

        public NaumenTmpWriter(int startCounter = 0)
        {
            tmp = new Tmp(startCounter);
        }

        public void Write(int LS, IEnumerable<string[]> rows)
        {
            tmp.Write(rows.Select(x => LS.ToString() + "\t" + x.Aggregate((c1, c2) => c1 + "\t" + c2)));
        }
    }
}
