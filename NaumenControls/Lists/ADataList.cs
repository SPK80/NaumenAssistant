using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CommonLib.Extentions;
using NaumenControls.Lists.Structures;
using SPKCollections.Extentions;

namespace NaumenControls.Lists
{
    public abstract class ADataList<T> : BindingList<T>, IDataList 
        where T: IDataStruct
    {
        protected abstract T createDataStruct(int ls, string[] row);

        public void AddRecievedData(int LS, IEnumerable<string[]> recievedData)
        {
            if (recievedData == null) return;
            foreach (var row in recievedData.Reverse())
            {
                Add(createDataStruct(LS, row));
            }
        }

        public void InsertRecievedData(int LS, IEnumerable<string[]> recievedData)
        {
            int index;
            if (recievedData == null) return;
            if (this.Count() == 0)
            {
                AddRecievedData(LS, recievedData);
                return;
            }

            try
            {
                index = IndexOf(this.First(ds => ds.LS == LS));                
            }
            catch (Exception ex)
            {
                return;
            }

            foreach (var row in recievedData.Reverse())
            {
                Insert(index, createDataStruct(LS, row));
            }
        }

        public void PasteFromClipboard()
        {
            var table = ClipboardExt.TableFromClipboard();
            if (table == null) return;

            Clear();
            for (int iRow = 0; iRow< table.Length; iRow++)
            {
                int ls;
                var row = table[iRow];
                if (row.Length > 0 && int.TryParse(row[0], out ls))
                {
                    Add(createDataStruct(ls, row.Copy(1)));
                }
            }
        }

        public void AddEmpty()
        {
            Add(createDataStruct(default, new string[0]));
        }
    }
}
