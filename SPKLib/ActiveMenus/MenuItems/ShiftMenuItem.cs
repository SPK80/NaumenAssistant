using System;
using System.Windows.Forms;
using SPKCollections;

namespace ActiveMenus.MenuItems
{
    public abstract class ShiftMenuItem : BaseMenuItem
    {
        //protected ShiftMenuItem(int shift, bool withoutСonfirmation)
        //{
        //    Shift = shift;
        //    this.withoutСonfirmation = withoutСonfirmation;
        //}

        protected override bool needSelectedItem => true;

        protected bool moving => (listBox!=null)&&
            (listBox.DataSource is MovingBindingList<object> || listBox.DataSource==null);

        public event EventHandler<ItemEventArgs> OnShiftItem;

        private bool isMovingBindingList => listBox.DataSource is MovingBindingList<object>;

        public int Shift { get; set; } = 0;

        protected void shiftItem()
        {
            if (!itemSelected) return;
            if (Shift == 0) return;
            int from = listBox.SelectedIndex;
            if (from + Shift < 0 || from + Shift >= listItems.Count) return;

            var iea = new ItemEventArgs { Item = listBox.SelectedItem, WithoutСonfirmation = false };
            OnShiftItem?.Invoke(this, iea);
            if (iea.WithoutСonfirmation || confirmation()) //MessageBox.Show($"Сдвинуть на {Shift}?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                
                var movingItem = listBox.SelectedItem;

                if (isMovingBindingList)
                {
                    var mbl = (MovingBindingList<object>)listBox.DataSource;
                    mbl.Move(movingItem, mbl.IndexOf(movingItem) + Shift);
                }
                else
                {
                    listItems.Remove(movingItem);
                    listItems.Insert(from + Shift, movingItem);
                }
            }
        }
    }

    public class ShiftUpMenuItem : ShiftMenuItem
    {
        public ShiftUpMenuItem() : base()
        {
            Name = "tsmiShiftUp";
            Text = "Сдвиг Вверх";
            Shift = -1;
            withoutСonfirmation = true;
            Click += (s, e) =>
            {
                shiftItem();
            };
        }
    }

    public class ShiftDownMenuItem : ShiftMenuItem
    {
        public ShiftDownMenuItem() : base()
        {
            Name = "tsmiShiftDown";
            Text = "Сдвиг Вниз";
            Shift = 1;
            withoutСonfirmation = true;
            Click += (s, e) =>
            {
                shiftItem();
            };
        }
    }

}