using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Extends;
using System.Drawing;

namespace cui1
{
    using d = Framework.Data;
    using c = Framework.Command;
    using da = Framework.Datas.Class1;
    using size = System.Drawing.Size;

    public partial class uipcui1 : BaseUC
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // uipcui1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Name = "uipcui1";
            this.Size = new System.Drawing.Size(263, 243);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public uipcui1()
        {
            this.InitializeComponent();
        }
        protected override void InitialUserCom()
        {
            base.InitialUserCom();
            this.pTag = "MainUI";
        }
        protected override IUI GetSubui()
        {
            return new uipcui1();
        }

        protected override void LocalSettingExtend()
        {
            d.pCurrentUC = this;
            switch (this.UIState)
            {
                case 0: this.Load0(); break;
                case 1: this.Load1(); break;
                case 2: this.Load2(); break;
                case 3: this.Load3(); break;
                case 4: this.Load4(); break;

                case 5: this.Load5(); break;
                case 6: this.Load6(); break;
                case 7: this.Load7(); break;
                case 8: this.Load8(); break;
                case 9: this.Load9(); break;

                case 10: this.Load10(); break;
                case 11: this.Load11(); break;
                case 12: this.Load12(); break;
                case 13: this.Load13(); break;
                case 14: this.Load14(); break;
                case 15: this.Load15(); break;

                case 16: this.Load16(); break;
                case 17: this.Load17(); break;
                case 18: this.Load18(); break;
                case 19: this.Load19(); break;
                case 20: this.Load20(); break;
                default:
                    break;
            }
        }

        static int loadmark = 0;
        protected override void OnLoad()
        {
            if (loadmark == 0)
            {
                this.Case.pipo.pLeftTabControl.Click += new EventHandler(TabControl_Click);
                this.Case.pipo.pRitghtTabControl.Click += new EventHandler(TabControl_Click);
            }
            loadmark++;
            base.OnLoad();
        }

        void TabControl_Click(object sender, EventArgs e)
        {
            if (this.Case.pipo.pLeftTabControl.SelectedTab != null)
            {
                var buc = this.Case.pipo.pLeftTabControl.SelectedTab.Controls[0] as BaseUC;
                switch (this.Case.pipo.pLeftTabControl.SelectedTab.Text)
                {
                    case "": break;
                    default: break;
                }
            }
            if (this.Case.pipo.pRitghtTabControl.SelectedTab != null)
            {
                var buc = this.Case.pipo.pRitghtTabControl.SelectedTab.Controls[0] as BaseUC;
                switch (this.Case.pipo.pRitghtTabControl.SelectedTab.Text)
                {
                    case "": break;
                    default: break;
                }
            }
        }
    }
}
