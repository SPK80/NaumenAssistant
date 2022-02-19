using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CommonLib.TmpHelper;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Controls
{
    public partial class GettingDataPanel : UserControl
    {
        public GettingDataPanel()
        {
            InitializeComponent();
            EventHandler tuneButtons = (s, e) =>
            {
                tsbReceiveFiles.Enabled = tsbReceiveConnections.Enabled = tsbReceiveComments.Enabled = dataPanel.Prepared;
            };
            dataPanel.PrepareChanged += tuneButtons;

            tuneButtons(this, EventArgs.Empty);


        }

        public event EventHandler<XchangeDataStructEventArgs> GetOne;

        private void receiveData(int[] lss)
        {            
            foreach (int ls in lss)
            {
                var getOneEventArgs = new XchangeDataStructEventArgs(ls, dataPanel.StructType);
                GetOne?.Invoke(this, getOneEventArgs);
                var recievedData = getOneEventArgs.Data;
                //dataList.AddRecievedData(ops.LS, dataList.IndexOf(ops), recievedData);                
                if (recievedData == null )
                    dataPanel.DataList.AddRecievedData(ls, new string[][] { new[] { "" } });
                else
                {
                    dataPanel.DataList.AddRecievedData(ls, recievedData);
                }
                    


            }
        }
                 

        private void tsbReceiveComments_Click(object sender, EventArgs e)
        {
            tsbReceiveFiles.Enabled = tsbReceiveConnections.Enabled = tsbReceiveComments.Enabled = false;
            
            var lss = dataPanel.DataList.Cast<IDataStruct>().Select(s => s.LS).ToArray();
            dataPanel.Prepared = false;
            dataPanel.StructType = StructType.GettingComment;
            receiveData(lss);
        }

        private void tsbReceiveConnections_Click(object sender, EventArgs e)
        {
            var lss = dataPanel.DataList.Cast<IDataStruct>().Select(s => s.LS).ToArray();
            dataPanel.Prepared = false;
            dataPanel.StructType = StructType.Connection;
            receiveData(lss);
        }

        private void tsbReceiveFiles_Click(object sender, EventArgs e)
        {            
            var lss = dataPanel.DataList.Cast<IDataStruct>().Select(s => s.LS).ToArray();
            dataPanel.Prepared = false;
            dataPanel.StructType = StructType.GettingFile;
            receiveData(lss);
        }
    }

    public class XchangeDataStructEventArgs : EventArgs
    {

        public XchangeDataStructEventArgs(int lS, StructType structType)
        {
            LS = lS;
            StructType = structType;
        }

        public XchangeDataStructEventArgs(int lS, IEnumerable<string[]> data, StructType structType)
        {
            LS = lS;
            StructType = structType;
            Data = data;
        }

        public StructType StructType { get; }
        public int LS { get; }
        public IEnumerable<string[]> Data { get; set; }
    }
}
