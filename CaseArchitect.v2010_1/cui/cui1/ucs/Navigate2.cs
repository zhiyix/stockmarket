using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cui1.ucs
{
    public partial class Navigate2 : UserControl, IDataStore
    {
        public Navigate2()
        {
            InitializeComponent();
        }
        #region IData 成员

        public DataTable pDataTable
        {
            get;
            set;
        }

        public System.Xml.Linq.XElement pXdata
        {
            get;
            set;
        }

        #endregion
    }
}
