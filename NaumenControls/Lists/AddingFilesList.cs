using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaumenControls.Lists.Structurs;

namespace NaumenControls.Lists
{
    public class AddingFilesList : ADataList<AddingFilesStruct>
    {
        protected override AddingFilesStruct createDataStruct(int ls, string[] row)
            => new AddingFilesStruct(ls, row);
    }

}
