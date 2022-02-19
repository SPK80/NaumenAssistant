using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveMenus
{
    public partial class ListBoxContextMenuStrip : ContextMenuStrip
    {
        public ListBoxContextMenuStrip(IContainer container) : base(container)
        {
        }

        public ListBoxContextMenuStrip()
        {
        }

        protected ListBox listBox => SourceControl as ListBox;

        public bool SelectItemOnOpeningMenu { get; set; } = true;

        protected override void OnOpening(CancelEventArgs e)
        {
            if (listBox == null) return;
            var p = listBox.PointToClient(new System.Drawing.Point(Left, Top));
            var selectedIndex = listBox.IndexFromPoint(p);

            // выделение/(снятие выделоения) при открытии меню
            if (SelectItemOnOpeningMenu)
            {
                if (selectedIndex < 0)
                {
                    listBox.ClearSelected();
                }
                else
                {
                    listBox.SelectedIndex = selectedIndex;
                }
            }

            base.OnOpening(e);
        }
    }
}
