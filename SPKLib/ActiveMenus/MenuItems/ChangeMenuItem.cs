using System;
using System.Windows.Forms;

namespace ActiveMenus.MenuItems
{
    public class ChangeMenuItem : BaseMenuItem
    {
        public event EventHandler<ItemEventArgs> OnChangeItem;

        protected override bool needSelectedItem => true;

        public ChangeMenuItem()
        {
            init("Изменить");
        }

        public ChangeMenuItem(string text)
        {
            init(text);
        }

        private void init(string text)
        {
            Name = "сhangeAdd";
            Text = text;
            Click += (s, e) =>
            {
                if (!itemSelected) return;

                var iea = new ItemEventArgs { Item = listBox.SelectedItem, WithoutСonfirmation = false };
                var index = listItems.IndexOf(listBox.SelectedItem);
                OnChangeItem?.Invoke(this, iea);

                if (iea.WithoutСonfirmation || confirmation())
                {
                    listItems.RemoveAt(index);
                    if (iea.Item != null)
                        listItems.Insert(index, iea.Item);
                }
            };
        }

        //protected override void ErrorMessage(Exception ex)
        //{
        //    MessageBox.Show("Ошибка", ex.Message);
        //}
    }
}
