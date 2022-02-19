using System;
using System.Windows.Forms;
using NaumenControls.Lists;

namespace NaumenControls.Controls
{
    public partial class CustomDataPanel : UserControl
    {
        public CustomDataPanel()
        {
            InitializeComponent();
            Prepared = false;
            DataList = new LSNumList();
            dgView.DataSource = null;
            dgView.DataSource = DataList;
            PreparingStructType = StructType.LSNum;
        }

        public IDataList DataList { get; private set; }

        public StructType PreparingStructType
        {
            get;
            set;
        }

        private StructType structType;


        public StructType StructType
        {
            get=> structType;
            set
            {
                if (structType == value) return;
                structType=value;
                DataList = structType.NewDataList();
                dgView.DataSource = null;
                dgView.DataSource = DataList;
            }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {            
            DataList.Clear();
            Prepared = false;
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {            
            DataList.PasteFromClipboard();
            if (DataList.Count>0)
                Prepared = true;
        }


        private void tsbAdd_Click(object sender, EventArgs e)
        {
            DataList.AddEmpty();
            if (DataList.Count > 0)
                Prepared = true;
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (dgView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(
                        dgView.GetClipboardContent());
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                   
                }
            }
        }

        public event EventHandler PrepareChanged;

        private bool prepare;

        public bool Prepared
        {
            get => prepare;

            set
            {
                if (!value)
                    StructType = PreparingStructType;
                prepare = value;
                PrepareChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private Type inputType;
        public Type InputType
        {
            get=> inputType;

            internal set
            {
                inputType = value;


            }
        }
        public Type OutputType { get; internal set; }
    }
}
