using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cm1.oml
{
    using Framework;
    using Framework.Extends;
    using d = Framework.Data;
    using c = Framework.Command;
    using da = Framework.Datas.Class1;
    using bcmp = Framework.BCaseModelPorter;
    using System.Reflection;
    using h = help;
    class top
    {
        public Framework.Data pData { get; set; }
        public Framework.IServer pServer { get; set; }
        public event casecallback CaseCallback;
        sus fsus;
        data fdata;
        internal rule prule { get; set; }
        public void _x_login(string name, string pwd)
        {
            this.pData.SettingStateFromCmp.Invoke();
        }
        public top()
        {
            this.fsus = new sus();
            this.fdata = new data();
            this.prule = new rule();
        }
        //----------------------------
        void OnCaseCallback(string cmd, params object[] ps)
        {
            if (this.CaseCallback != null) this.CaseCallback.Invoke(cmd, ps);
        }

        internal void _x_registry(object[] ps)
        {
            this.pData.SettingStateFromCmp.Invoke();
        }
    }
    delegate void casecallback(string cmd, params object[] ps);
}
