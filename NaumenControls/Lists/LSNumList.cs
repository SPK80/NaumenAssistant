
using NaumenControls.Lists.Structures;

namespace NaumenControls.Lists
{
    public class LSNumList : ADataList<LSNumStruct>
    {
        protected override LSNumStruct createDataStruct(int ls, string[] row)
            => new LSNumStruct(ls, row);
    }
}
