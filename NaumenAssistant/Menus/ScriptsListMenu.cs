using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using NaumenAssistant.Scripts;
using SPKCollections.Extentions;

namespace NaumenAssistant.Menus
{
    public class ScriptsListMenu : ListBoxMenu
    {
        
        public ScriptsListMenu() : base()
        {
            inits();
        }

        public ScriptsListMenu(IContainer container) : base(container)
        {
            inits();
        }

        public bool MoveFileAtAdd { get; set; } = false;

        private void inits()
        {            
            Items.Add(new ToolStripMenuItem("Новый", null, tsmiNew_Click));
            Items.Add(new ToolStripMenuItem("Переименовать", null, tsmiRename_Click));
            Items.Add(new ToolStripMenuItem("Добавить", null, tsmiAdd_Click));
        }

        private bool containsName(string name) =>
            lbItems.Cast<object>().ContainsWith(it => it.ToString() == name);

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.Multiselect = true;
            if (ofd.ShowDialog()== DialogResult.OK)
            {
                foreach(var path in ofd.FileNames)
                {
                    var p = path;
                    var dir = Path.GetDirectoryName(p);
                    var apath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NaumenScriptSettings.Directory);

                    if (dir != apath)
                    {
                        var newPath = NaumenScriptSettings.Path(Path.GetFileNameWithoutExtension(p));

                        if (MoveFileAtAdd)
                            File.Move(p, newPath);
                        else
                            File.Copy(p, newPath);

                        p = newPath;
                    }

                    var name = Path.GetFileNameWithoutExtension(p);
                    if (!containsName(name))
                    {
                        lbItems.Add(new NaumenScriptFile(Path.GetFileNameWithoutExtension(p)));
                        return;
                    }
                }
            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            if (listBox == null) return;            
            while (true)
            {
                var renamingItem = listBox.SelectedItem;
                if (renamingItem == null) break;

                var newName = getNewName(renamingItem.ToString());
                if (newName == renamingItem.ToString() || newName=="") return;

                if (!containsName(newName))
                {                    
                    ((NaumenScriptFile)renamingItem).Rename(newName);

                    var bList = listBox.DataSource as BindingList<object>;
                    if (bList!=null)
                        bList.ResetBindings();

                    return;
                }
            }
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            if (listBox == null) return;
            string newItemName = null;
            while (true)
            {
                newItemName = getNewItemName();

                if (newItemName == null) break;

                if (!containsName(newItemName))
                {
                    lbItems.Add(new NaumenScriptFile(newItemName, new string[] { }, new string[] { }));
                    return;
                }
            }
        }

        private string getNewItemName()
        {
            string name = "";

            if (Dialogs.InputBox("Новый скрипт", "Введите имя нового скрипта", ref name) == DialogResult.OK)
            {
                return name;
            }
            else return null;
        }

        private string getNewName(string name)
        {
            if (Dialogs.InputBox("Переименовать скрипт", "Введите новое имя скрипта", ref name) == DialogResult.OK)
            {
                return name;
            }
            else return "";
        }

    }

}
