using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using SPKCollections;

namespace NaumenAssistant.Menus
{
    public class ListBoxMenu : ContextMenuStrip
    {
        
        protected ListBox listBox => SourceControl as ListBox;
        protected IList lbItems => listBox.DataSource as IList;
        public bool Moving => listBox?.DataSource is MovingBindingList<object>;

        public ListBoxMenu()
        {
            inits();
        }

        public ListBoxMenu(IContainer container) : base(container)
        {
            inits();
        }
        
        //protected ToolStripMenuItem tsmiNew = new ToolStripMenuItem();
        protected ToolStripMenuItem tsmiClear = new ToolStripMenuItem();
        protected ToolStripMenuItem tsmiRemove = new ToolStripMenuItem();
        protected ToolStripMenuItem tsmiShiftUp = new ToolStripMenuItem();
        protected ToolStripMenuItem tsmiShiftDown = new ToolStripMenuItem();

        protected override void OnOpening(CancelEventArgs e)
        {
            base.OnOpening(e);            
            tsmiShiftUp.Visible = Moving;
            tsmiShiftDown.Visible = Moving;            
        }

        private void inits()
        {            
            // 
            // tsmiClear
            // 
            tsmiClear.Name = "tsmiClear";
            tsmiClear.Text = "Очистить";
            tsmiClear.Click += new EventHandler(tsmiClear_Click);
            // 
            // tsmiRemove
            // 
            tsmiRemove.Name = "tsmiRemove";
            tsmiRemove.Text = "Удалить";
            tsmiRemove.Click += new EventHandler(tsmiRemove_Click);
            // 
            // tsmiShiftUp
            // 
            tsmiShiftUp.Name = "tsmiShiftUp";
            tsmiShiftUp.Text = "Сдвинуть Вверх";
            tsmiShiftUp.Click += new EventHandler(tsmiShiftUp_Click);
            // 
            // tsmiShiftDown
            // 
            tsmiShiftDown.Name = "tsmiShiftDown";
            tsmiShiftDown.Text = "Сдвинуть Вниз";
            tsmiShiftDown.Click += new EventHandler(tsmiShiftDown_Click);
            
            Items.AddRange(new [] 
            {
            //tsmiNew,
            tsmiClear,
            tsmiRemove,
            tsmiShiftUp,
            tsmiShiftDown
            });
        }        

        private void tsmiShiftDown_Click(object sender, EventArgs e)
        {
            if (!Moving) return;
            var mbl = listBox.DataSource as MovingBindingList<object>;

            int from = listBox.SelectedIndex;
            if (listBox == null || from >= lbItems.Count - 1) return;
            var movingItem = listBox.SelectedItem;
            
            mbl.Move(movingItem, mbl.IndexOf(movingItem)+1);            
        }

        private void tsmiShiftUp_Click(object sender, EventArgs e)
        {
            if (!Moving) return;
            var mbl = listBox.DataSource as MovingBindingList<object>;

            int from = listBox.SelectedIndex;
            if (listBox == null || from < 1) return;
            var movingItem = listBox.SelectedItem;

            mbl.Move(movingItem, mbl.IndexOf(movingItem) - 1);
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            if (listBox == null) return;

            if (MessageBox.Show($"Удалить{listBox.SelectedItem}?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                lbItems.Remove(listBox.SelectedItem);
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            if (listBox == null) return;
            if (MessageBox.Show($"Очистить?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                lbItems.Clear();
        }

        //private event EventHandler<NewItemEventArgs> onNewItem;
        //public event EventHandler<NewItemEventArgs> OnNewItem
        //{
        //    add
        //    {
        //        if (value == null) return;
        //        onNewItem+= value;
        //        tsmiNew.Visible = true;
        //    }
        //    remove
        //    {
        //        if (value == null) return;
        //        onNewItem -= value;
        //        if (onNewItem == null)
        //            tsmiNew.Visible = false;
        //    }
        //}

        //private void tsmiNew_Click(object sender, EventArgs e)
        //{
        //    if (listBox == null) return;
        //    object newItem =null;
        //    while (true)
        //    {
        //        var niea = new NewItemEventArgs();

        //        onNewItem?.Invoke(this, niea);
        //        newItem = niea.NewItem;
        //        if (newItem == null) return;
                          

        //        if (!listBox.Items.Cast<object>().
        //            ContainsWith(it => it.ToString() == newItem.ToString()))
        //        {
        //            lbItems.Add(newItem);
                    
        //            return;
        //        }
        //    }
        //}
    }

}
