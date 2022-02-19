
using System;
using System.Windows.Forms;

namespace NaumenAssistant.Menus
{
    public class ScriptsEditorMenu : ListBoxMenu
    {
        private ToolStripMenuItem tsmiSave = new ToolStripMenuItem();
        private ToolStripMenuItem tsmiCancel = new ToolStripMenuItem();

        private void inits()
        {
            // 
            // tsmiSave
            //             
            tsmiSave.Name = "tsmiSave";
            tsmiSave.Text = "Сохранить";
            tsmiSave.Click += new EventHandler(this.tsmiSave_Click);
            // 
            // tsmiCancel
            //             
            tsmiCancel.Name = "tsmiCancel";
            tsmiCancel.Text = "Отменить";
            tsmiCancel.Click += new EventHandler(this.tsmiCancel_Click);

            Items.AddRange(new[] {
            tsmiSave,
            tsmiCancel});

        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            //listBox.Items.Clear();
            //listBox.Items.AddRange();
            //listBox.Tag
            throw new NotImplementedException();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }


}
