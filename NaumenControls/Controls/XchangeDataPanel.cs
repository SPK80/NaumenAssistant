using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NaumenControls.Lists.Structures;

namespace NaumenControls.Controls
{
    public partial class XchangeDataPanel : UserControl
    {
        public XchangeDataPanel()
        {
            InitializeComponent();
        }

        private void tsbExec_Click(object sender, System.EventArgs e)
        {
            execAll();
        }

        private void execAll()
        {
            var dataStructs = dataPanel.DataList.Cast<IDataStruct>().ToArray();

            dataPanel.DataList.Clear();
            //dataPanel.OutputType = selectedTask.OutputType;

            foreach (var dataStruct in dataStructs)
            {
                var received = selectedTask.Exec(dataStruct);
                dataPanel.DataList.AddRecievedData(dataStruct.LS, received);
            }
        }

        private INaumenTask selectedTask => (INaumenTask)tscbTaskSelector.SelectedItem;

        private INaumenTask[] tasks;
        
        public INaumenTask[] Tasks
        {
            get => tasks;
            set
            {
                tasks = value;
                if (tasks == null) return;
                tscbTaskSelector.Items.Clear();
                tscbTaskSelector.Items.AddRange(tasks);
            }
        }

        private void TscbTaskSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataPanel.InputType = selectedTask.InputType;
        }
    }
}
