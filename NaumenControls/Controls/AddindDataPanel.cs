using System;
using System.Windows.Forms;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Controls
{

    public partial class AddindDataPanel : UserControl, ICounted
    {
        public AddindDataPanel()
        {
            InitializeComponent();

            EventHandler tuneButtons = (s, e) =>
            {
                tsbExec.Enabled = dataPanel.Prepared && dataPanel.PreparingStructType != StructType.LSNum;
            };

            dataPanel.PrepareChanged += tuneButtons;

            tscbSrtuctTypeSelector.Items.Clear();
            tscbSrtuctTypeSelector.Items.Add(new StructTypeWrap(StructType.AddingComment));
            tscbSrtuctTypeSelector.Items.Add(new StructTypeWrap(StructType.AddingFile));
            tscbSrtuctTypeSelector.Items.Add(new StructTypeWrap(StructType.Connection));
            tscbSrtuctTypeSelector.Items.Add(new StructTypeWrap(StructType.LS));
            tscbSrtuctTypeSelector.SelectedIndex = 0;
        }

        public event EventHandler<XchangeDataStructEventArgs> SendOne;

        private void sendData()
        {
            Counter = 0;
            Count = dataPanel.DataList.Count;
            foreach (IDataStruct dataStruct in dataPanel.DataList)
            {
                var getOneEventArgs = new XchangeDataStructEventArgs(
                    dataStruct.LS, 
                    new[] { dataStruct.GetAllData() }, 
                    dataPanel.StructType);

                SendOne?.Invoke(this, getOneEventArgs);
                Counter++;
            }
        }
        public int Counter { get; private set; } = 0;
        public int Count { get; private set; } = 0;


        private void tsbExec_Click(object sender, EventArgs e)
        {
            dataPanel.Prepared = false;
            sendData();
        }

        private void TscbSrtuctTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataPanel.Prepared = false;
            
            dataPanel.StructType = ((StructTypeWrap)tscbSrtuctTypeSelector.SelectedItem).StructType;
            dataPanel.PreparingStructType = dataPanel.StructType;
        }
    }

}
