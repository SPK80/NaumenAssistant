using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPKCollections;

namespace EnhancedNaumenControls
{
    public partial class TasksPanel : UserControl
    {
        public TasksPanel()
        {
            InitializeComponent();

            Clear();

            cbTasks.SelectionChangeCommitted += (_s, _e) =>
            {
                var selectedTask = cbTasks.SelectedItem as NamedArray<NamedTask>;
                if (selectedTask == null) return;

                clbTasks.Text = "";
                clbTasks.Items.Clear();

                clbTasks.Items.AddRange(selectedTask.ToArray());
            };


            bStart.Enabled = true;
            bCancel.Enabled = false;

            bool changed = false;
            bCancel.EnabledChanged += (_s, _e) =>
              {                  
                  if (!changed)
                  {
                      changed = true;
                      bStart.Enabled = !bCancel.Enabled;                      
                  }
                  changed = false;
              };

            bStart.EnabledChanged += (_s, _e) =>
            {
                if (!changed)
                {
                    changed = true;
                    bCancel.Enabled = !bStart.Enabled;                    
                }
                changed = false;
            };
        }

        public void Clear()
        {
            cbTasks.Items.Clear();
            clbTasks.Items.Clear();
        }
        public void AddTaskType(string name, params NamedTask[] tasks)
        {
            cbTasks.Items.Add(new NamedArray<NamedTask>(name, tasks));
        }

        public NamedArray<NamedTask>[] TaskTypes
        {
            get => cbTasks.Items.OfType<NamedArray<NamedTask>>().ToArray();
            //set
            //{
            //    cbTaskTypes.Items.Clear();
            //    if (value == null || value.Length == 0) return;
            //    cbTaskTypes.Items.AddRange(value);
            //}
        }

        public event EventHandler<TasksEventArgs> Start;
        public event EventHandler<TasksEventArgs> Cancel;
        

        private void bStart_Click(object sender, EventArgs e)
        {
            bCancel.Enabled = true;
            Start?.Invoke(this, new TasksEventArgs(clbTasks.CheckedItems.OfType<NamedTask>().ToArray()));
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            bStart.Enabled = true;
            Cancel?.Invoke(this, new TasksEventArgs(clbTasks.CheckedItems.OfType<NamedTask>().ToArray()));
        }
    }

}
