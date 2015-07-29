using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework;

namespace Action
{
    using R = Properties.Resources;
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class Form1 : Form, IPropertyOperate
    {
        public Form1()
        {
            InitializeComponent();
            InitialUserCom();
        }
        public static void Run(Form1 f)
        {
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            Application.EnableVisualStyles();
            Application.Run(f);
        }
        private void InitialUserCom()
        {
            this.pSettingSize = new Size(860, 573);
            this.Load += new EventHandler(Form1_Load);
            //
            this.timer1.Interval = 1000 * 10;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer1.Start();
            //
            this.toolStripStatusLabel1.Text = string.Empty;
            this.toolStripProgressBar1.Visible = false;
            this.CheckSurface();
        }
        public Data pData { get; set; }
        public BCommandHandler CommandHandler { get; set; }
        public BCaseCallbackHandler CaseCallbackHandler { get; set; }
        void Form1_Load(object sender, EventArgs e)
        {
            InitialCommandHandler();
            InitialCaseCallbackHandler();
            //
            try
            {
                this.Visible = false;
                this.CommandHandler.InitialProject();
                this.Visible = true;
            }
            catch
            {
                Application.Exit();
            }
        }

        private void InitialCaseCallbackHandler()
        {
            this.CaseCallbackHandler.pNotify += this.item_pNotify;
            this.OriginalCase.eCaseCallback += this.CaseCallbackHandler.CaseCallbackHandler;
        }

        private void InitialCommandHandler()
        {
            this.CommandHandler.pNotifyIconp = this.pNotifyIcon1;
            this.CommandHandler.Visiable += (o) => { this.Visible = o; };
            this.CommandHandler.SetTitle += (o) => { this.Text = o; };
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Empty;
        }
        public ICase OriginalCase { get; set; }
        //
        private void InitialUI()
        {
            if (this.OriginalCase != null)
                foreach (var item in this.iuis)
                {
                    item.Case = this.OriginalCase;
                    item.eLoad += new Action<IUI>(item_Load);
                    item.eClose += new Action<IUI>(item_eClose);
                    item.pNotify += new Action<string>(item_pNotify);
                    item.eGetIcon += new GetIconEventHandler(item_eGetIcon);
                }
        }
        Bitmap item_eGetIcon(IconType it)
        {
            Bitmap b = default(Bitmap);
            switch (it)
            {
                case IconType._new:
                    b = R._new;
                    break;
                case IconType.add:
                    b = R.add;
                    break;
                case IconType.book:
                    b = R.book;
                    break;
                case IconType.box:
                    b = R.box;
                    break;
                case IconType.brush:
                    b = R.brush;
                    break;
                case IconType.cd:
                    b = R.cd;
                    break;
                case IconType.close:
                    b = R.close;
                    break;
                case IconType.diamond:
                    b = R.diamond;
                    break;
                case IconType.diamond2:
                    b = R.diamond2;
                    break;
                case IconType.down:
                    b = R.down;
                    break;
                case IconType.exit:
                    b = R.exit;
                    break;
                case IconType.exit2:
                    b = R.exit2;
                    break;
                case IconType.fish:
                    b = R.fish;
                    break;
                case IconType.folder:
                    b = R.folder;
                    break;
                case IconType.foot:
                    b = R.foot;
                    break;
                case IconType.help:
                    b = R.help;
                    break;
                case IconType.home:
                    b = R.home;
                    break;
                case IconType.info:
                    b = R.info;
                    break;
                case IconType.key:
                    b = R.key;
                    break;
                case IconType.left:
                    b = R.left;
                    break;
                case IconType.offline_user:
                    b = R.offline_user;
                    break;
                case IconType.pen:
                    b = R.pen;
                    break;
                case IconType.pin:
                    b = R.pin;
                    break;
                case IconType.prohibit:
                    b = R.prohibit;
                    break;
                case IconType.refurbish:
                    b = R.refurbish;
                    break;
                case IconType.right:
                    b = R.right;
                    break;
                case IconType.serachFolder:
                    b = R.serachFolder;
                    break;
                case IconType.size:
                    b = R.size;
                    break;
                case IconType.stop:
                    b = R.stop;
                    break;
                case IconType.tool:
                    b = R.tool;
                    break;
                case IconType.undo:
                    b = R.undo;
                    break;
                case IconType.BlueFish:
                    b = R.BlueFish;
                    break;
                case IconType.RedFish:
                    b = R.RedFish;
                    break;
                case IconType.GreenFish:
                    b = R.GreenFish;
                    break;
                case IconType.YellowFish:
                    b = R.YellowFish;
                    break;
                default:
                    break;
            }
            return b;
        }
        void item_pNotify(string obj)
        {
            if (obj[0] == '-')
            {
                this.toolStripStatusLabel1.ForeColor = Color.Red;
                this.toolStripStatusLabel1.Text = obj.Substring(1, obj.Length - 1);
            }
            else
            {
                this.toolStripStatusLabel1.ForeColor = Color.Green; this.toolStripStatusLabel1.Text = obj;
            }
        }
        void item_eClose(IUI ui)
        {
            switch (ui.pType)
            {
                case UIType.navigate:
                    this.tabControl1.TabPages.RemoveByKey(ui.pTag);
                    break;
                case UIType.tool:
                    this.tabControl1.TabPages.RemoveByKey(ui.pTag);
                    break;
                case UIType.monopolize:
                    this.tabControl2.TabPages.RemoveByKey(ui.pTag);
                    break;
                case UIType.content:
                    this.tabControl2.TabPages.RemoveByKey(ui.pTag);
                    break;
                case UIType.setting:
                    this.tabControl2.TabPages.RemoveByKey(ui.pTag);
                    break;
                case UIType.unmodeluf:
                    var v1 = (UserControl)ui;
                    var v2 = (Form)v1.Parent;
                    v2.Close();
                    break;
                case UIType.modeluf:
                    var v3 = (UserControl)ui;
                    var v4 = (Form)v3.Parent;
                    v4.Close();
                    break;
                case UIType.signal:
                    var v5 = (UserControl)ui;
                    var v6 = (Form)v5.Parent;
                    v6.Close();
                    break;
                default:
                    break;
            }
            this.CheckSurface();
            if (ui.pIsClone)
                ((UserControl)ui).Dispose();
        }
        void item_Load(IUI ui)
        {
            if (ui.pTag != null || ui.pTag != string.Empty)
                switch (ui.pType)
                {
                    case UIType.navigate:
                        this.LoadUI(this.tabControl1, ui);
                        break;
                    case UIType.tool:
                        this.LoadUI(this.tabControl1, ui);
                        break;
                    case UIType.monopolize:
                        if (this.LoadUI(this.tabControl2, ui))
                            this.CheckSurface();
                        this.splitContainer1.Panel1Collapsed = true;
                        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                        this.MaximizeBox = false;
                        return;
                    case UIType.content:
                        this.LoadUI(this.tabControl2, ui);
                        break;
                    case UIType.setting:
                        this.LoadUI(this.tabControl2, ui);
                        this.CheckSurface();
                        this.Setting();
                        return;
                    case UIType.unmodeluf:
                        Form f1 = new Form();
                        f1.Text = ui.pTag;
                        var v1 = (UserControl)ui;
                        f1.ClientSize = v1.Size;
                        f1.ControlBox = false;
                        f1.MaximizeBox = false;
                        f1.FormBorderStyle = FormBorderStyle.FixedDialog;
                        f1.Controls.Add(v1);
                        f1.Show();
                        break;
                    case UIType.modeluf:
                        Form f2 = new Form();
                        f2.Text = ui.pTag;
                        var v2 = (UserControl)ui;
                        f2.ClientSize = v2.Size;
                        f2.ControlBox = false;
                        f2.MaximizeBox = false;
                        f2.FormBorderStyle = FormBorderStyle.FixedDialog;
                        f2.Controls.Add(v2);
                        f2.ShowDialog();
                        break;
                    case UIType.signal:
                        Form f3 = new Form();
                        var v3 = (UserControl)ui;
                        f3.StartPosition = FormStartPosition.CenterParent;
                        f3.ClientSize = v3.Size;
                        f3.ControlBox = false;
                        f3.MaximizeBox = false;
                        f3.FormBorderStyle = FormBorderStyle.FixedSingle;
                        f3.Controls.Add(v3);
                        f3.ShowDialog();
                        break;
                    default:
                        break;
                }
            else
                this.item_pNotify("_UC.Tag值不能为空或string.Empty");
            this.CheckSurface();
        }
        private void CheckSurface()
        {
            if (this.tabControl1.TabCount < 1 && this.tabControl2.TabCount < 1)
            {
                this.splitContainer1.Visible = false;
            }
            else if (this.tabControl1.TabCount > 0 && this.tabControl2.TabCount < 1)
            {
                this.splitContainer1.Visible = true;
                this.splitContainer1.Panel1Collapsed = false;
                this.splitContainer1.Panel2Collapsed = false;
                this.tabControl1.Visible = true;
                this.tabControl2.Visible = false;
            }
            else if (this.tabControl1.TabCount > 0 && this.tabControl2.TabCount > 0)
            {
                this.splitContainer1.Visible = true;
                this.splitContainer1.Panel1Collapsed = false;
                this.splitContainer1.Panel2Collapsed = false;
                this.tabControl1.Visible = true;
                this.tabControl2.Visible = true;
            }
            else if (this.tabControl1.TabCount < 1 && this.tabControl2.TabCount > 0)
            {
                this.splitContainer1.Visible = true;
                this.splitContainer1.Panel1Collapsed = true;
                this.splitContainer1.Panel2Collapsed = false;
                this.tabControl1.Visible = false;
                this.tabControl2.Visible = true;
            }
            this.UnSetting();
        }
        private bool LoadUI(TabControl tc, IUI p)
        {
            foreach (TabPage item in tc.TabPages)
            {
                if (item.Text == p.pTag) return false;
            }
            TabPage tp = new TabPage(p.pTag);
            tp.Name = p.pTag;
            var v = p as Control;
            v.Dock = DockStyle.Fill;
            tp.Controls.Add(v);
            tc.TabPages.Add(tp);
            tc.SelectedTab = tp;
            return true;
        }

        IUI[] iuis;
        public IUI[] UIs
        {
            get { return this.iuis; }
            set
            {
                if (this.iuis == null)
                {
                    this.iuis = value;
                    this.InitialUI();
                }
            }
        }
        //
        void Setting()
        {
            this.Size = this.pSettingSize;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
        void UnSetting()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
        }
        //
        #region IPropertyOperate 成员
        public Size pSettingSize { get; set; }
        public MenuStrip pMenuStrip
        {
            get { return this.menuStrip1; }
        }

        public string pNotify
        {
            set
            {
                this.item_pNotify(value);
            }
        }

        public ToolStripProgressBar pProgressBar
        {
            get
            {
                return this.toolStripProgressBar1;
            }
            set
            {
                this.toolStripProgressBar1 = value;
            }
        }

        public ToolStrip pToolStrip
        {
            get
            {
                return this.toolStrip1;
            }
            set
            {
                this.toolStrip1 = value;
            }
        }
        public TabControl pLeftTabControl { get { return this.tabControl1; } }
        public TabControl pRitghtTabControl { get { return this.tabControl2; } }
        public SplitContainer pSplitContainer { get { return this.splitContainer1; } }
        public string pMainWindowName { get { return this.Text; } set { this.Text = value; } }
        public Size pMainFormClientSize { get { return this.ClientSize; } set { this.ClientSize = value; } }
        public void ShowMessage(string msg)
        {
            MessageForm.pMessageForm.Show(msg);
        }
        public void ShowMessage(string msg, Color fontColor)
        {
            MessageForm.pMessageForm.Show(msg, fontColor);
        }
        public void CloseMessageForm()
        {
            MessageForm.pMessageForm.Close();
            this.pNotify = "消息通知窗口已经关闭！";
        }
        //
        public void ClearAllPanel()
        {
            this.tabControl1.TabPages.Clear();
            this.tabControl2.TabPages.Clear();
            this.CheckSurface();
        }

        public void ClearLeftPanel()
        {
            this.tabControl1.TabPages.Clear();
            this.CheckSurface();
        }

        public void ClearRightPanel()
        {
            this.tabControl2.TabPages.Clear();
            this.CheckSurface();
        }

        public void CloseUC(string tag)
        {
            foreach (TabPage item in this.tabControl2.TabPages)
            {
                if (item.Text == tag) ((IUI)item.Controls[0]).Close(); return;
            }
            foreach (TabPage item in this.tabControl1.TabPages)
            {
                if (item.Text == tag) ((IUI)item.Controls[0]).Close(); return;
            }
        }

        public void OpenUC(string ucName, int ucState)
        {
            foreach (var item in this.iuis)
            {
                if (item.GetType().Name == ucName)
                {
                    item.Clone().Open(ucState);
                    break;
                }
            }
        }
        public void ShowPrograssBarState()
        {
            this.Invoke(this.OriginalCase.pData.GetDelegate(this, () =>
            {
                this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                this.toolStripProgressBar1.Visible = true;
            }));
        }


        public double pOpacity
        {
            get { return this.Opacity; }
            set { this.Opacity = value; }
        }

        public Rectangle pRestoreBounds
        {
            get { return this.RestoreBounds; }
        }

        public FormBorderStyle pFormBorderStyle { get { return this.FormBorderStyle; } set { this.FormBorderStyle = value; } }

        public bool pMaximizeBox { get { return this.MaximizeBox; } set { this.MaximizeBox = value; } }

        public bool pMinimizeBox { get { return this.MinimizeBox; } set { this.MinimizeBox = value; } }

        void IPropertyOperate.Hide() { this.Hide(); }
        void IPropertyOperate.Show() { this.Show(); }
        public void About()
        {
            new AboutBox1().ShowDialog();
        }
        #endregion
    }//class end border
}
