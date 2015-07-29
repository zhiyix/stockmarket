using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;
using Framework;

namespace Framework
{
    using d = Framework.Data;
    using c = Framework.Command;
    using System.Xml;
    using System.ServiceModel;
    using System.Data.SqlClient;

    [ServiceContract]
    [XmlSerializerFormat]
    public interface IServer
    {

        #region sql处理范式
        [OperationContract]
        bool set(string cmd, object[] ps);
        [OperationContract]
        DataTable get(string cmd, object[] ps);
        [OperationContract]
        DataTable procedure(string proc, string procps, object[] ps);
        #endregion

        #region xml处理范式
        [OperationContract]
        bool savetoxml(string xmlFileName, XmlDocument xe);
        [OperationContract]
        XmlDocument getfromxml(string xmlFileName);
        #endregion

        #region 一般服务范式
        [OperationContract]
        object general(string summary, object p);
        #endregion
        //todo to under place the orther server service
    }
}
