using System;
using System.Windows.Forms;

namespace ActiveMenus.MenuItems
{
    public class ClearMenuItem : BaseMenuItem
    {
        public event EventHandler<ItemEventArgs> OnClearItems;
        protected override bool needSelectedItem => false;

        public ClearMenuItem() : base()
        {
            Name = "tsmiClear";
            Text = "Очистить";
            Click += (s, e) =>
            {
                if (listItems==null) return;
                var iea = new ItemEventArgs { Item = listBox.SelectedItem, WithoutСonfirmation = false };
                OnClearItems?.Invoke(this, iea);
                if (iea.WithoutСonfirmation || confirmation())
                {
                    listItems.Clear();
                }
            };
        }
    }


}
