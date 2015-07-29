using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Case.Service
{
    using d = Framework.Data;
    using c = Framework.Command;
    using s = Properties.Settings;
    using da = Framework.Datas.Class1;
    using Framework.Extends;
    using Framework;
    using System.Data;
    using System.Xml;

    // 注意: 如果更改此处的类名 "Service1"，也必须更新 Web.config 中对 "Service1" 的引用。
    public partial class Service1 : Framework.IServer
    {
        //DataClasses1DataContext dc;

    }
}
