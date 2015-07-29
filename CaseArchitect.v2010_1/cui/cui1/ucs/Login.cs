using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cui1.Properties;

namespace cui1.ucs
{
    public partial class Login : UserControl, IDataStore
    {
        public Login()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(Login_Disposed);
        }

        void Login_Disposed(object sender, EventArgs e)
        {
            if (Settings.Default.isSave)
            {
                Settings.Default.isSave = true;
                Settings.Default.userName = this.textBox1name.Text;
                Settings.Default.userPwd = this.textBox2pwd.Text;
            }
            else
            {
                Settings.Default.isSave = false;
                Settings.Default.userName = string.Empty;
                Settings.Default.userPwd = string.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Settings.Default.isSave)
            {
                Settings.Default.isSave = true;
                Settings.Default.userPwd = this.textBox2pwd.Text;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Settings.Default.isSave)
            {
                Settings.Default.isSave = true;
                Settings.Default.userPwd = this.textBox2pwd.Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Settings.Default.isSave)
            {
                Settings.Default.isSave = true;
                Settings.Default.userName = this.textBox1name.Text;
                Settings.Default.userPwd = this.textBox2pwd.Text;
            }
            else
            {
                Settings.Default.isSave = false;
                Settings.Default.userName = string.Empty;
                Settings.Default.userPwd = string.Empty;
            }
        }

        #region IDataStore 成员

        public DataTable pDataTable
        {
            get;
            set;
        }

        public System.Xml.Linq.XElement pXdata
        {
            get;
            set;
        }

        #endregion
    }
}
