//#define product
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework;

namespace Action.CommandHandler
{
    using d = Framework.Data;
    using c = Framework.Command;
    using da = Framework.Datas.Class1;
    using Framework.Extends;

    public class Class1 : BCommandHandler
    {
        public Class1(IUI[] uis, ICase c)
            : base(uis, c)
        {
        }
        protected override void LoadUICommands()
        {
            base.LoadUICommands();
        }
        protected override void LoadProgram()
        {
#if product
            this.LoadProgram("wcfClass1");
#elif !product
            base.LoadProgram();
#endif
            this.OnSetTitle("CaseArchtecture201003_");
            if (this["MainUI"] != null)
                this["MainUI"].Open(0);
        }
        protected override void LoadpNotifyIcon()
        {
            base.LoadpNotifyIcon();
        }
        //
        protected virtual void LoadProgram(string sn)
        {
            d.sn = sn;
            base.Case.CaseLogic(d.gcs(c._scmd_sn赋值完毕));
        }
    }//class end border
}
