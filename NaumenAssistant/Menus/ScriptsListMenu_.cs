using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ActiveMenus;
using ActiveMenus.MenuItems;
using CommonLib;
using NaumenAssistant.Scripts;
using SPKCollections.Extentions;

namespace NaumenAssistant.Menus
{
    public class ScriptsListMenu_ : ListBoxContextMenuStrip
    {
        public ScriptsListMenu_()
        {
            inits();
        }

        public ScriptsListMenu_(IContainer container) : base(container)
        {
            inits();
        }

        public bool MoveFileAtAdd { get; set; } = false;

        private void inits()
        {
            var addMenuItem = new AddMenuItem();
            addMenuItem.OnNewItem += addScript;
            Items.Add(addMenuItem);

            //var clearMenuItem = new ClearMenuItem();
            //clearMenuItem.OnClearItems += clearScripts;
            //Items.Add(clearMenuItem);

            Items.Add(new RemoveScriptMenuItem());

            Items.Add(new RenameScriptMenuItem());
            

            var shiftUpMenuItem = new ShiftUpMenuItem();
            Items.Add(shiftUpMenuItem);

            var shiftDownMenuItem = new ShiftDownMenuItem();
            Items.Add(shiftDownMenuItem);
        }
        
        private bool containsName(string name) =>
            listBox.Items.Cast<object>().ContainsWith(it => it.ToString() == name);

        private void addScript(object sender, ItemEventArgs e)
        {
            if (listBox == null) return;
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var path in ofd.FileNames)
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
                        e.Item = new NaumenScriptFile(Path.GetFileNameWithoutExtension(p));
                        e.WithoutСonfirmation = true;
                        return;
                    }
                }
            }
        }

    //private void renameScript(object sender, ItemEventArgs e)
    //{
    //        if (listBox == null) return;
    //        while (true)
    //        {
    //            var renamingItem = e.Item;//listBox.SelectedItem;
    //            if (renamingItem == null) break;

    //            var newName = getNewName(renamingItem.ToString());
    //            if (newName == renamingItem.ToString() || newName == "") return;

    //            if (!containsName(newName))
    //            {
    //                ((NaumenScriptFile)renamingItem).Rename(newName);

    //                var bList = listBox.DataSource as BindingList<object>;
    //                if (bList != null) bList.ResetBindings();

    //                e.WithoutСonfirmation = true;
    //                return;
    //            }
    //        }
    //    }

        //private void tsmiNew_Click(object sender, EventArgs e)
        //{
        //    if (listBox == null) return;
        //    string newItemName = null;
        //    while (true)
        //    {
        //        newItemName = getNewItemName();

        //        if (newItemName == null) break;

        //        if (!containsName(newItemName))
        //        {
        //            lbItems.Add(new NaumenScriptFile(newItemName, new string[] { }, new string[] { }));
        //            return;
        //        }
        //    }
        //}

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