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
    /// <summary>
    /// 业务规则类
    /// </summary>
    class rule
    {
        #region 外部设置成员
        public Framework.Data pData { get; set; }
        public Framework.IServer pServer { get; set; }
        #endregion
    }
}
