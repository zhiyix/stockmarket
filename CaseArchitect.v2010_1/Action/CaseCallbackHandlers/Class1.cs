using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;

namespace Action.CaseCallbackHandlers
{
    using d = Framework.Data;
    using c = Framework.Command;
    using da = Framework.Datas.Class1;
    using Framework.Extends;

    public class Class1 : BCaseCallbackHandler
    {
        public Class1(IUI[] uis, ICase c)
            : base(uis, c)
        {

        }
        protected override void RealCaseCallbackHandl(string cmd, params object[] ps)
        {
            base.RealCaseCallbackHandl(cmd, ps);
        }
        protected override void NonParameterHandle(string cmd)
        {
            //todo
        }
        protected override void HaveParameterHandle(string cmd, object[] ps)
        {
            //todo
        }
    }
}
