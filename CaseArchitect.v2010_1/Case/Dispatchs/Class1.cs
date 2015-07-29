using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case.Dispatchs
{
    using d = Framework.Data;
    using c = Framework.Command;
    using da = Framework.Datas.Class1;
    using Framework.Extends;

    public class Class1 : Dispatch
    {
        protected override void CaseService(string cmd, object[] ps)
        {
            base.CaseService(cmd, ps);
        }
    }//class end border
}
