using System.Windows.Forms;
using ActiveMenus.MenuItems;
using NaumenAssistant.Scripts;

namespace NaumenAssistant.Menus
{
    public class RemoveScriptMenuItem: RemoveMenuItem
    {
        public RemoveScriptMenuItem() : base()
        {
            OnRemoveItem += removeScript;
        }

        private void removeScript(object sender, ItemEventArgs e)
        {
            if (MessageBox.Show($"Удалить{e.Item} полностью?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var removingItem = e.Item as NaumenScriptFile;
                removingItem.Remove();
            }
            e.WithoutСonfirmation = true;
        }
    }
}
