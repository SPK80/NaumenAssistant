
using NaumenControls.Lists.Structures;

namespace NaumenControls.Lists
{
    public class LSList : ADataList<LSStruct>
    {
        protected override LSStruct createDataStruct(int ls, string[] row)
            => new LSStruct(ls);
    }
}
