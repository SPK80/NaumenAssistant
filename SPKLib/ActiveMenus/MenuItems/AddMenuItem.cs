using System;
using System.Windows.Forms;

namespace ActiveMenus.MenuItems
{
    public class AddMenuItem : BaseMenuItem
    {
        protected override bool needSelectedItem => false;

        public event EventHandler<ItemEventArgs> OnNewItem;

        public AddMenuItem() : base()
        {
            Name = "tsmiAdd";
            Text = "Добавить";
            Click += (s, e) =>
            {
                    if (listItems == null) return;

                    var iea = new ItemEventArgs { Item = listBox.SelectedItem, WithoutСonfirmation = false };
                    OnNewItem?.Invoke(this, iea);

                    if (iea.WithoutСonfirmation || confirmation())
                    {                    
                        listItems.Add(iea.Item??"");
                    }
        };
        }

        //protected override void ErrorMessage(Exception ex)
        //{
        //    MessageBox.Show("Ошибка", ex.Message);
        //}
    }
}
