using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CommonLib.Extentions;

namespace EnhancedNaumenControls
{
    public partial class StringTableView : UserControl
    {
        public StringTableView()
        {
            InitializeComponent();
            Rows = new TableRows(dgView);
        }

        public string[] ColumnCaptions
        {
            get => dgView.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText).ToArray();

            set
            {
                if (value == null) return;
                
                dgView.Columns.Clear();
                foreach (var v in value)
                {
                    dgView.Columns.Add(v, v);
                }
            }
        }

        public TableRows Rows;

       

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (dgView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(
                        dgView.GetClipboardContent());
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                }
            }
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var table = ClipboardExt.TableFromClipboard();
            if (table == null)
            {
                dgView.Rows.Add();
                return;
            }                

            foreach(var row in table)
                Rows.Add(row);
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dgView.Rows.Clear();
            ToolStripMenuItem3_Click(sender, e);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            dgView.Rows.Clear();
            dgView.Columns.Clear();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Select();
            SendKeys.Send("{DEL}");
        }
    }

    static class DataGridViewExt
    {
        public static void ExpandColumns(this DataGridView dataGridView,  int count)
        {
            if (dataGridView.ColumnCount < count)
            {
                for (int i = dataGridView.ColumnCount; i < count; i++)
                    dataGridView.Columns.Add(i.ToString(), i.ToString());
            }
        }
    }
    public class TableRows : IEnumerable<string[]>
    {
        //DataGridViewRowCollection rows;
        DataGridView dataGridView;
        

        public TableRows(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView ?? throw new ArgumentNullException(nameof(dataGridView));
        }

        public IEnumerator<string[]> GetEnumerator()
        {
            foreach (var row in dataGridView.Rows.Cast<DataGridViewRow>().
                Select(r => r.Cells.Cast<DataGridViewTextBoxCell>().
                Select(c => c.Value?.ToString() ?? "").ToArray()))
            {
                yield return row;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear() => dataGridView.Rows.Clear();

        public void Add(string[] item)
        {
            if (item == null) return;
            if (item.Length == dataGridView.ColumnCount)
            {
                dataGridView.Rows.Add(item);
                return;
            }

            dataGridView.ExpandColumns(item.Length);

            var row = new string[dataGridView.ColumnCount];
            for (int c = 0; c < dataGridView.ColumnCount; c++)
            {
                if (c >= item.Length)
                    break;
                row[c] = item[c];
            }
            dataGridView.Rows.Add(row);
        }

        public void RemoveAt(int index)=> dataGridView.Rows.RemoveAt(index);

    }
}
