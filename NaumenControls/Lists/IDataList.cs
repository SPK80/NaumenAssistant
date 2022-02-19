
using System.Collections;
using System.Collections.Generic;

namespace NaumenControls.Lists
{
    public interface IDataList: IList
    {
        void PasteFromClipboard();
        void InsertRecievedData(int LS, IEnumerable<string[]> recievedData);
        void AddRecievedData(int LS, IEnumerable<string[]> recievedData);
        void AddEmpty();
    }
}