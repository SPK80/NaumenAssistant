using System;
using System.Windows.Forms;

namespace ActiveMenus.MenuItems
{
    public class RemoveMenuItem : BaseMenuItem
    {
        public event EventHandler<ItemEventArgs> OnRemoveItem;
        protected override bool needSelectedItem => true;

        public RemoveMenuItem() : base()
        {
            Name = "tsmiRemove";
            Text = "Удалить";
            Click += (s, e) =>
            {
                if (!itemSelected) return;

                var iea = new ItemEventArgs { Item = listBox.SelectedItem, WithoutСonfirmation = false };
                OnRemoveItem?.Invoke(this, iea);                

                if (iea.WithoutСonfirmation || confirmation())
                {
                    listItems.Remove(iea.Item);
                }
            };
        }
    }
}