using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runer.WCF
{
    using Framework.Extends;
    using Framework;
    using System.Data;
    using System.Xml;
    //using rc=Runer.ServiceReference1.Command;
    //using rcf = Runer.ServiceReference1.Filter;
    /// <summary>
    /// 本类用于包装WCF远程代理类使之实现IServer以做为此契约远程实现版本
    /// </summary>
    class wcfClass1 : Framework.IServer
    {
        //ServerClient sc;
        public wcfClass1()
        {
            //this.sc=new Runer.ServiceReference1.ServerClient();
        }
        //Filter getfilter(Framework.Filter f) {
        //    rf fr = new Filter();
        //    fr.selectColumnName = f.selectColumnName;
        //    fr.valueColumnName = f.valueColumnName;
        //    fr.condition = f.condition;
        //    if (f.values != null && f.values.Count() == 1 && f.values[0] is Framework.Filter) {
        //        fr.values = new object[1];
        //        fr.values[0] = this.getfilter((Framework.Filter)f.values[0]);
        //    } else if (f.values != null)
        //        fr.values = f.values;
        //    return fr;
        //}
        #region IServer 成员

        public object general(string summary, object p)
        {
            throw new NotImplementedException();
        }

        public DataTable get(string cmd, object[] ps)
        {
            throw new NotImplementedException();
        }

        public XmlDocument getfromxml(string xmlFileName)
        {
            throw new NotImplementedException();
        }

        public DataTable procedure(string proc, string procps, object[] ps)
        {
            throw new NotImplementedException();
        }

        public bool savetoxml(string xmlFileName, XmlDocument xe)
        {
            throw new NotImplementedException();
        }

        public bool set(string cmd, object[] ps)
        {
            throw new NotImplementedException();
        }

        #endregion
    }//ceb
}
