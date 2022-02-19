using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib.Config;

namespace NaumenAssistant
{
    public partial class UserDialog : Form
    {
        public UserDialog()
        {
            InitializeComponent();
            //this.UserSettings = UserSettings?? throw new ArgumentNullException(nameof(UserSettings));            
            initHidePass();
        }

        //private ISettingsCatalog userSettings;
        //public ISettingsCatalog UserSettings
        //{
        //    get => userSettings;
        //    set
        //    {
        //        if (value == null) return;
        //        userSettings = value;
        //        tbLogin.Text = UserSettings["UserName"];
        //        tbPassword.Text = UserSettings["Password"];
        //    }
        //}

        public string UserName
        {
            get => tbLogin.Text;
            set => tbLogin.Text=value;
        }
        public string Password
        {
            get => tbPassword.Text;
            set => tbPassword.Text = value;
        }

        //public new static UserDialog ShowDialog()
        //{
        //    var result = new UserDialog();
        //    result.ShowDialog();
        //    return result;
        //}

        private void bAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UserDialog_Load(object sender, EventArgs e)
        {

        }

        private void CbHidePass_CheckedChanged(object sender, EventArgs e)
        {
            initHidePass();
        }
        private void initHidePass()
        {
            if (cbHidePass.Checked)
                tbPassword.PasswordChar = '*';
            else
                tbPassword.PasswordChar = '\0';
        }
    }
}
