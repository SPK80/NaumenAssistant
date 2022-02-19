using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ListScripts;
using NaumenAssistant.Scripts;
using SPKCollections;

namespace NaumenAssistant
{
    public partial class ScriptsMenager : Form
    {

        private MovingBindingList<object> scripts = new MovingBindingList<object>();        

        public string[] Scripts
        {
            get => scripts.Select(s=>s.ToString()).ToArray();
            set
            {
                //scripts = new MovingBindingList<object>(value.Select(v => (object)new ListScriptEditor(v)).ToList());
                foreach (var name in value)
                {                    
                    try
                    {
                        scripts.Add(new NaumenScriptFile(name));
                    }
                    catch
                    {
                    }
                }                
            }
        }

        //private APIAdapterWrap[] APIAdapters
        //{
        //    get => cbAllOperations.Items.Cast<APIAdapterWrap>().ToArray();
        //    set
        //    {
        //        if (value == null) return;
        //        cbAllOperations.Items.Clear();
        //        cbAllOperations.Items.AddRange(value);
        //    }
        //}

        //public class APIAdapterWrap : APIAdapter
        //{
        //    private string name;
        //    public APIAdapterWrap(string name, APIAdapter aPIAdapter) : base(aPIAdapter.InputFields, aPIAdapter.Operation)
        //    {
        //        this.name = name;
        //    }

        //    public override string ToString()
        //    {
        //        return name;
        //    }
        //}

        public ScriptsMenager()
        {
            InitializeComponent();            
        }

        private void ScriptsMenager_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;            
        }

        private void ScriptsMenager_Load(object sender, EventArgs e)
        {
            //var nsr = new NaumenScriptRunner()

            //APIAdapters =  
            //    Select(kv => new ScriptsMenager.APIAdapterWrap(kv.Key, kv.Value)).ToArray();

            cbAllOperations.Tag = lbScriptOperations;
            lbScriptOperations.Tag = cbAllOperations;

            lbScriptOperations.Enabled = false;
            lbScriptInputFields.Enabled = false;

            lbScripts.DataSource = scripts;

            cbAllOperations.Items.Clear();
            cbAllOperations.Items.AddRange(NaumenAPIAdapters.Names);            
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            selectedScript.Save();
        }

        private NaumenScriptFile selectedScript => (NaumenScriptFile)lbScripts.SelectedItem;

        private IList curentScriptOperations => (IList)lbScriptOperations.DataSource;
        private IList curentScriptInputFields => (IList)lbScriptInputFields.DataSource;

        /// <summary>
        /// Добавляет SelectedItem из sender в destControl указанный в sender.Tag 
        /// </summary>
        private void addItemToList(object sender, EventArgs e)
        {            
            var sourceControl = (sender as ComboBox);
            if (sourceControl == null) return;

            var destControl = sourceControl.Tag as ListControl;
            if (destControl == null) return;

            var selectedItem = sourceControl.SelectedItem;
            if (selectedItem == null) return;
            ((IList)(destControl).DataSource).Add(selectedItem.ToString());            
        }

        private void lbScripts_SelectedValueChanged(object sender, EventArgs e)
        {            
            this.Text = selectedScript.ToString();

            lbScriptOperations.DataSource = null;
            lbScriptOperations.DataSource = selectedScript.Operations;

            lbScriptInputFields.DataSource = null;
            lbScriptInputFields.DataSource = selectedScript.InputFields;
        }

        private void dataSourceChanged(object sender, EventArgs e)
        {
            var senderControl = (sender as ListControl);
            if (senderControl == null) return;
            if (senderControl.DataSource!=null && senderControl.DataSource is IList)
            {
                senderControl.Enabled = true;                
            }
            else
            {
                senderControl.Enabled = false;
            }
        }

        private void enabledChanged(object sender, EventArgs e)
        {
            var senderControl = (sender as Control);
            if (senderControl == null) return;
            if (senderControl.Tag!=null && senderControl.Tag is Control)
            {
                (senderControl.Tag as Control).Enabled = senderControl.Enabled;
            }
        }

        private void CbAllOperations_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var senderControl = (sender as ComboBox);
            
            addItemToList(sender, e); //добавляем выбранный элемент CbAllOperations в lbScriptOperations

            if (senderControl.SelectedItem != null && senderControl.SelectedItem is APIAdapter)
            {
                addInputFields(((APIAdapter)senderControl.SelectedItem).InputFields);

                //lbScriptInputFields.DataSource                    

            }

            senderControl.SelectedItem = null;
        }

        private void addInputFields(string[] inputFields)
        {
            foreach (var inp in inputFields)
                if(!curentScriptInputFields.Contains(inp))
                    curentScriptInputFields.Add(inp);
        }

        private void listBoxContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        //private void ToolStripButton2_Click(object sender, EventArgs e)
        //{
        //    string choice;
        //    Dialogs.ChoiceBox<string>("ChoiceBox", "ChoiceBox", new [] {"0","1","2"}, out choice);
        //}
    }
}
