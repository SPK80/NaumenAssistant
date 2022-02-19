using System;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using CommonLib.LogHelper;
using NaumenAPI;
using NaumenAssistant.Scripts;

namespace NaumenAssistant
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Application.ProductName}@{Application.CompanyName} v{Application.ProductVersion}";

            var naumenRunner = new NaumenScriptWorker();

            tscbAPIMode.Items.Add("Определяется Скриптом");
            tscbAPIMode.Items.AddRange(Enum.GetNames(typeof(NMode)));
            tscbAPIMode.Text = NaumenApi.Mode.ToString();

            tscbAPIMode.SelectedIndexChanged += (_s, _e) =>
            {
                if (tscbAPIMode.Text != "Определяется Скриптом")
                {
                    NaumenApi.Mode = (NMode)Enum.Parse(typeof(NMode), tscbAPIMode.Text);
                }                
            };            

            naumenRunner.RunWorkerCompleted += (rs,re)=> runnerPanel.Stop();
            naumenRunner.ProgressChanged += (rs, re) =>
            {
                Action action = () => Text = re.UserState?.ToString()??"";
                Invoke(action);
            };

            runnerPanel.ScriptSelected += (_s, _e) =>
            {
                try
                {
                    var script = new NaumenScriptFile(_e.Selected.ToString());
                    //NaumenScriptRunner(_e.Selected.ToString(), stringTableView, cbResultsToCols.Checked);
                    lbScriptPreview.Items.Clear();
                    lbScriptPreview.Items.AddRange(script.Operations);
                    stringTableView.ColumnCaptions = script.InputFields;
                    _e.Confirm = true;
                }
                catch { _e.Confirm = false; }
            };

            runnerPanel.OnStart += (_s, _e) =>
            {
                try
                {
                    var flags = new Flags();
                    if (cbSingleRowResults.Checked) flags.Add(NsrOptions.singleRowResults);
                    if (cbInsertEmptyRow.Checked) flags.Add(NsrOptions.insertEmptyRow);

                    naumenRunner.RunWorkerAsync(
                        new NaumenTaskArgs(
                            _e.Selected.ToString(),
                            new[] { stringTableView.ColumnCaptions }.Concat(stringTableView.Rows),
                            stringTableView,
                            flags
                            )
                    );
                    _e.Confirm = true;
                }
                catch
                {
                    _e.Confirm = false;
                    return;
                } 
            };

            runnerPanel.OnStop += (_s, _e) =>
            {
                if (naumenRunner.IsBusy)
                {                    
                    naumenRunner.CancelAsync();
                    _e.Confirm = false;
                }else
                _e.Confirm = true;
            };            
            
            runnerPanel.Paths = ScriptsSettings.Items;            
        }

        
        private void tsmiUser_Click(object sender, EventArgs e)
        {
            var userDialog = new UserDialog();
            userDialog.UserName = User.Name;
            userDialog.Password = User.Password;

            userDialog.ShowDialog(this);
            if (userDialog.DialogResult == DialogResult.OK)
            {
                User.Name = userDialog.UserName;
                User.Password = userDialog.Password;
            }
        }

        private void tsmiScripts_Click(object sender, EventArgs e)
        {
            var scriptsMenager = new ScriptsMenager();
            
            scriptsMenager.Scripts = ScriptsSettings.Items;

            if (scriptsMenager.ShowDialog() == DialogResult.OK)
            {
                ScriptsSettings.Items = runnerPanel.Paths = scriptsMenager.Scripts;
            }            
        }
        
    }
}
