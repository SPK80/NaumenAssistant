using CommonLib.Extentions;
using NaumenControls.Lists.Structures;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace NaumenControls.Lists
{
    public class ConnectionsList : ADataList<ConnectionStruct>
    {
        protected override ConnectionStruct createDataStruct(int ls, string[] row) => new ConnectionStruct(ls, row);

    }
}
