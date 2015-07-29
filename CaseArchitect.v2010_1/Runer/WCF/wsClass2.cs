using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;

namespace Runer.WCF
{
    using Framework.Extends;
    using System.Data;
    using System.Xml;
    //using rc=Runer.ServiceReference1.Command;
    //using rcf = Runer.ServiceReference1.Filter;
    //using Runer.ServiceReference2;

    class wsClass2 : IServer
    {
        //WebService1SoapClient sc;
        public wsClass2()
        {
            //this.sc = new Runer.ServiceReference2.WebService1SoapClient();
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
    }
}
