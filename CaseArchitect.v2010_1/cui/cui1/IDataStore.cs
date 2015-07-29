using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Linq;

namespace cui1
{
    interface IDataStore
    {
        DataTable pDataTable { get; set; }
        XElement pXdata { get; set; }
    }
}
