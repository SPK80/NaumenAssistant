using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CommonLib.Extentions;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Lists
{
    public class GettingFilesList : ADataList<FilesInfoStruct>
    {
        protected override FilesInfoStruct createDataStruct(int ls, string[] row) => new FilesInfoStruct(ls, row);
       
    }
}
