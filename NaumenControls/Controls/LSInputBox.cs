using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaumenControls.Controls
{
    public partial class LSInputBox : TextBox
    {
        public LSInputBox()
        {
            InitializeComponent();
        }

        public LSInputBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Multiline)
                {
                    var newStr = Lines[Lines.Length - 2];
                    int i;
                    if (!int.TryParse(newStr, out i))
                    {
                        var tmp = new List<string>(Lines);
                        tmp.RemoveAt(tmp.Count - 2);
                        Lines = tmp.ToArray();
                        SelectionStart = Text.Length;
                    }
                }
                else Text = "";
            }
        }
    }
}
