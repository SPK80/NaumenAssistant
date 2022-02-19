using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ActiveMenus.MenuItems;
using CommonLib;
using NaumenAssistant.Scripts;
using SPKCollections.Extentions;

namespace NaumenAssistant.Menus
{
    public class RenameScriptMenuItem : ChangeMenuItem
    {
        public RenameScriptMenuItem(): base("Переименовать")
        {
            this.OnChangeItem += renameScript;
        }
       
        private string getNewName(string name)
        {
            if (Dialogs.InputBox("Переименовать скрипт", "Введите новое имя скрипта", ref name) == DialogResult.OK)
            {
                return name;
            }
            else return "";
        }

        private bool containsName(string name) =>
            listBox.Items.Cast<object>().ContainsWith(it => it.ToString() == name);

        private void renameScript(object sender, ItemEventArgs e)
        {
            if (listBox == null) return;
            while (true)
            {
                var renamingItem = e.Item;//listBox.SelectedItem;
                if (renamingItem == null) break;

                var newName = getNewName(renamingItem.ToString());
                if (newName == renamingItem.ToString() || newName == "") return;

                if (!containsName(newName))
                {
                    ((NaumenScriptFile)renamingItem).Rename(newName);

                    var bList = listBox.DataSource as BindingList<object>;
                    if (bList != null) bList.ResetBindings();

                    e.WithoutСonfirmation = true;
                    return;
                }
            }
        }        
    }

}
