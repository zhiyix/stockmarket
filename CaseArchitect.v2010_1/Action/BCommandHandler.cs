using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework;

namespace Action
{
    using d = Framework.Data;
    using c = Framework.Command;
    using R = Properties.Resources;
    using System.Threading;
    using System.Diagnostics;

    public class BCommandHandler
    {
        //data
        internal NotifyIcon pNotifyIconp { get; set; }
        internal event Action<bool> Visiable;
        protected virtual void OnVisiable(bool b)
        {
            if (this.Visiable != null)
                this.Visiable.Invoke(b);
        }
        internal event Action<string> SetTitle;
        protected virtual void OnSetTitle(string msg)
        {
            if (this.SetTitle != null) this.SetTitle.Invoke(msg);
        }
        //
        protected IUI[] uis;
        protected ICase Case;
        //constructure
        public BCommandHandler(IUI[] uis, ICase c)
        {
            this.uis = uis; this.Case = c;
        }
        protected IUI this[string name]
        {
            get
            {
                foreach (var item in this.uis)
                {
                    if (name == item.pTag)
                        return item;
                }
                return null;
            }
        }
        public void InitialProject()
        {
            this.LoadProgram();
            this.LoadpNotifyIcon();
            this.LoadUICommands();
        }

        protected virtual void LoadpNotifyIcon()
        {
            this.pNotifyIconp.Icon = R.IconGray;
            var cm = new ContextMenuStrip();
            cm.Items.Add("Open", R.undo).Click += delegate { this.OnVisiable(true); this.pNotifyIconp.Icon = R.IconGreen; };
            cm.Items.Add("Close", R.prohibit).Click += delegate { this.OnVisiable(false); this.pNotifyIconp.Icon = R.IconYellow; };
            cm.Items.Add("-");
            cm.Items.Add("Exit", R.exit).Click += delegate { Application.Exit(); };
            this.pNotifyIconp.ContextMenuStrip = cm;
        }
        protected virtual void LoadProgram()
        {
            ServiceSelector ss = new ServiceSelector(this.Case.pData.ServiceNames.ToArray());
            ss.ServiceSelected += (sn) =>
            {
                d.sn = sn.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Case.CaseLogic(d.gcs(c._scmd_sn赋值完毕));
            };
            ss.ShowDialog();
        }

        protected virtual void LoadUICommands()
        {
            ToolStripMenuItem v3 = (ToolStripMenuItem)this.Case.pipo.pMenuStrip.Items.Add("工具 ");
            ToolStripMenuItem v4 = (ToolStripMenuItem)this.Case.pipo.pMenuStrip.Items.Add("帮助 ");
            //
            v3.DropDownItems.Add("选项  ");
            v4.DropDownItems.Add("文档  ").Click += (sender, e) =>
            {
                Process p = new Process();
                p.StartInfo.FileName = "iexplore.exe";
                p.StartInfo.Arguments = Application.StartupPath + "\\CaseDocument.xml";
                p.Start();
                p.Close();
            };
            v4.DropDownItems.Add("-");
            v4.DropDownItems.Add("关于  ").Click += delegate
            {
                new AboutBox1().ShowDialog();
            };
        }
    }
}
