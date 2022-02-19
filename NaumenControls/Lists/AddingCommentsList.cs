using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaumenControls.Lists.Structurs;

namespace NaumenControls.Lists
{
    public class AddingCommentsList : ADataList<AddingCommentStruct>
    {
        protected override AddingCommentStruct createDataStruct(int ls, string[] row)
            => new AddingCommentStruct(ls, row);        
    }
}
