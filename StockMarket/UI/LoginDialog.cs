using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//<!
using com.show.api;
using StockMarket.Utils;

namespace StockMarket.UI
{
    public partial class LoginDialog : Form
    {
        private bool debug = false;

        private TextBox textBoxAppID = new TextBox();
        private TextBox textBoxSecret = new TextBox();
        private Button btnDlgOK = new Button();
        private Color clrSubmit = Color.FromArgb(9, 163, 220);
        private Color clrCancel = Color.FromArgb(60, 195, 245);
        private Timer m_UpdateTimer = new Timer();
        private Links register = new Links("注册帐号", "https://www.showapi.com/auth/reg");

        enum LoginFSM
        {
            LOGIN_FSM_IDLE = 0,
            LOGIN_FSM_INIT = 10,
            LOGIN_FSM_INPUT = 20,
            LOGIN_FSM_SUBMIT = 30,
            LOGIN_FSM_LOGINING = 90,
            LOGIN_FSM_END = 100,
        };
        private LoginFSM loginFSMState = LoginFSM.LOGIN_FSM_INIT;
        private Int16 loginDelay;

        public LoginDialog()
        {
            InitializeComponent();

            textBoxAppID.Text = "APPID";
            textBoxAppID.Size = new Size(200, 21);
            textBoxAppID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxAppID.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(textBoxAppID, 1, 0);
         
            textBoxSecret.Text = "SECRET";
            textBoxSecret.Size = new Size(200, 21);
            textBoxSecret.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxSecret.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(textBoxSecret, 1, 1);

            btnDlgOK.Size = new Size(200, 32);
            btnDlgOK.FlatStyle = FlatStyle.Flat;
            btnDlgOK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            //btnDlgOK.Dock = DockStyle.Fill;
            btnDlgOK.Text = "Submit";
            btnDlgOK.BackColor = clrSubmit;
            btnDlgOK.Click += new EventHandler(Button_Click);
            this.tableLayoutPanel1.Controls.Add(btnDlgOK, 1, 2);

            HyperlinkLabel label = new HyperlinkLabel(register);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label.Dock = DockStyle.Fill;
            label.LinkClicked += new LinkLabelLinkClickedEventHandler(HyperlinkLabel_LinkClicked);
            this.tableLayoutPanel1.Controls.Add(label, 2, 0);

            foreach (Control ctrl in this.tableLayoutPanel1.Controls)
            {
                if (debug)
                    Console.WriteLine(ctrl.Size);
            }

            m_UpdateTimer.Interval = 500;
            m_UpdateTimer.Enabled = true;
            m_UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            m_UpdateTimer.Start();
            loginFSMState = LoginFSM.LOGIN_FSM_INIT;
        }

        void UpdateTimer_Tick(object sender, EventArgs e)
        {
            switch (loginFSMState)
            {
                case LoginFSM.LOGIN_FSM_INIT:
                    if (SettingConfigs.loadAPIConfiguration(ref apiSection))
                    {
                        if (apiSection.ApiElement.AppID.Length > 0 &&
                            apiSection.ApiElement.Secret.Length > 0)
                        {
                            loginFSMState = LoginFSM.LOGIN_FSM_SUBMIT;
                            break;
                        }
                    }
                    textBoxAppID.Focus();
                    loginFSMState = LoginFSM.LOGIN_FSM_INPUT;
                    break;
                case LoginFSM.LOGIN_FSM_INPUT:
                    btnDlgOK.Text = "Submit";
                    btnDlgOK.BackColor = clrSubmit;
                    textBoxAppID.ReadOnly = false;
                    textBoxSecret.ReadOnly = false;
                    break;
                case LoginFSM.LOGIN_FSM_SUBMIT:
                    btnDlgOK.Text = "Cancel";
                    btnDlgOK.BackColor = clrCancel;
                    textBoxAppID.Text = apiSection.ApiElement.AppID;
                    textBoxAppID.ReadOnly = true;
                    textBoxSecret.ReadOnly = true;
                    ShowAPI.setAppSection(apiSection);
                    if (ShowAPI.getMarketIndex() != null)
                    {
                        loginDelay = 5;
                        loginFSMState = LoginFSM.LOGIN_FSM_LOGINING;
                    }
                    else
                    {
                        loginFSMState = LoginFSM.LOGIN_FSM_INPUT;
                    }
                    break;
                case LoginFSM.LOGIN_FSM_LOGINING:
                    if (loginDelay-- <= 0)
                    {
                        loginFSMState = LoginFSM.LOGIN_FSM_END;
                    }
                    break;
                case LoginFSM.LOGIN_FSM_END:
                    bool bResult = SettingConfigs.storeAPIConfiguration(apiSection);
                    if (bResult)
                    {
                        m_UpdateTimer.Stop();
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else {
                        MessageBox.Show("LoginDialog's Config IO ERROR!");
                        loginFSMState = LoginFSM.LOGIN_FSM_INIT;
                    }
                    break;
            }
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
        }

        void Button_Click(object sender, EventArgs e)
        {
            if (btnDlgOK.Text.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                textBoxAppID.Focus();
                loginFSMState = LoginFSM.LOGIN_FSM_INPUT;
            }
            else if (btnDlgOK.Text.Equals("Submit", StringComparison.OrdinalIgnoreCase))
            {
                apiSection.ApiElement.AppID = textBoxAppID.Text;
                apiSection.ApiElement.Secret = textBoxSecret.Text;
                loginFSMState = LoginFSM.LOGIN_FSM_SUBMIT;
            }
        }

        void HyperlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Uri target = e.Link.LinkData as Uri;
            try
            {
                Console.WriteLine(target.IsAbsoluteUri);
                if (target.AbsoluteUri.StartsWith("http"))
                {
                    System.Diagnostics.Process.Start(target.AbsoluteUri);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LoginDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public APISection apiSection = new APISection();

        public UserProperties SettingConfigs;
    }

    public class TableLabel : Label 
    {
        public TableLabel(String text)
        {
            this.Text = text;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Dock = DockStyle.Fill;
        }
    }
}
