using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace EnhancedNaumenControls
{
    public partial class RunnerPanel : UserControl
    {
        public RunnerPanel()
        {
            InitializeComponent();
            setWorkState(State.Stoped);
        }

        public event EventHandler<RunnerEventArgs> OnStart;
        public event EventHandler<RunnerEventArgs> OnStop;
        public event EventHandler<RunnerEventArgs> ScriptSelected;

        public object Selected => cbScripts.SelectedItem;

        //public ObjectCollection Items => cbScripts.Items;

        public string[] Paths
        {
            get => cbScripts.Items.Cast<string>().ToArray();
            set
            {
                cbScripts.Items.Clear();
                if (value.Length>0)
                    cbScripts.Items.AddRange(value);
            }
        }

        //public bool WaitConfirm { get; set; } = true;
        public void Start()
        {
            bStart_Click(this, EventArgs.Empty);
        }

        public void Stop()
        {
            bCancel_Click(this, EventArgs.Empty);
        }


        private State nextState = State.Idle;
        public void ConfirmNextState()
        {
            if (nextState != State.Idle)
            {
                setWorkState(nextState);
            }
        }

        private enum State
        {
            Started,
            Stoped,
            Idle
        }
         
        private void setWorkState(State state)
        {
            if (state== State.Idle)
            {
                cbScripts.Enabled = bStart.Enabled = bCancel.Enabled = false;
            }
            else if (state == State.Started)
            {
                cbScripts.Enabled = bStart.Enabled = !(bCancel.Enabled = true);
            }
            else if (state == State.Stoped)
            {
                cbScripts.Enabled = bStart.Enabled = !(bCancel.Enabled = false);
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            var rea = new RunnerEventArgs(Selected);
            OnStart?.Invoke(this, rea);
            if (rea.Confirm)
            {
                setWorkState(State.Started);
            }                
            else //if(WaitConfirm)
            {
                nextState = State.Started;
                setWorkState(State.Idle);
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            var rea = new RunnerEventArgs(Selected);
            OnStop?.Invoke(sender, rea);
            if (rea.Confirm)
            {
                setWorkState(State.Stoped);
            }                
            else //if(WaitConfirm)
            {
                nextState = State.Stoped;
                setWorkState(State.Idle);
            }
        }

        private object preSelected=null;
        private void cbScripts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var rea = new RunnerEventArgs(Selected);
            ScriptSelected?.Invoke(this, rea);
            if (rea.Confirm)
                setWorkState(State.Stoped);
            else
                cbScripts.SelectedItem = preSelected;
        }
    }



    public class RunnerEventArgs: EventArgs
    {
        public RunnerEventArgs(object selected, bool confirm=false)
        {
            Confirm = confirm;
            Selected = selected ?? throw new ArgumentNullException(nameof(selected));
        }

        public bool Confirm { get; set; }
        public object Selected { get; }
    }
}
