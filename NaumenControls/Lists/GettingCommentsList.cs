using NaumenControls.Lists.Structures;

namespace NaumenControls.Lists
{
    public class GettingCommentsList : ADataList<GettingCommentStruct>
    {
        protected override GettingCommentStruct createDataStruct(int ls, string[] row) => new GettingCommentStruct(ls, row);
    }
}
