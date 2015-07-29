using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Action
{
    public partial class ServiceSelector : Form
    {
        public ServiceSelector(string[] sns)
        {
            InitializeComponent();
            this.sns = sns;
        }
        string[] sns;
        public event Action<string> ServiceSelected;
        void OnServiceSelected(string sn)
        {
            if (this.ServiceSelected != null) this.ServiceSelected.Invoke(sn);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            this.OnServiceSelected(this.listView1.SelectedItems[0].Text);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ServiceSelector_Load(object sender, EventArgs e)
        {
            foreach (var item in this.sns)
            {
                this.listView1.Items.Add(item);
            }
        }
    }
}
