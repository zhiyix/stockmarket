using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//<!
using StockMarket.Model;

namespace StockMarket.UI
{
    public partial class DialogStockList : Form
    {
        private bool debug = true;

        #region EVENT
        public event EventHandler<StockChangedEventArgs> StockChecked;
        #endregion

        #region 属性
        public string KeyWord { get; set; }

        public List<CodeInfo> CodeInfoList { get; set; }
        #endregion

        #region 初始化函数
        public DialogStockList()
        {
            InitializeComponent();

            textBox1.Text = "";
            textBox1.ReadOnly = false;

            // 双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // 使能 OnNotifyMessage 事件
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            this.listView1.CheckBoxes = true;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            this.listView1.Columns.Add("股票代码", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("股票名称", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("交易所", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("所属行业", -2, HorizontalAlignment.Left);
        }

        public void InitData(string key, List<CodeInfo> list)
        {
            this.textBox1.Text = key;
            this.textBox1.ReadOnly = true;
            this.listView1.Items.Clear();
            TSSLabel_Total.Text = list.Count + "";
            foreach (CodeInfo info in list)
            {
                ListViewItem item = new ListViewItem(info.Code);
                item.SubItems.Add(info.Name);
                item.SubItems.Add(info.getMarket());
                item.SubItems.Add(info.Industry);
                this.listView1.Items.Add(item);
            }
            this.listView1.ItemChecked += new ItemCheckedEventHandler(ListView_ItemChecked);
        }
        #endregion

        #region 消息响应处理函数
        private void DialogStockList_Load(object sender, EventArgs e)
        {

        }

        private void StockChecked_CallBack(SmpStock stock)
        {
            if (stock != null)
            {
                StockChangedEventArgs args = new StockChangedEventArgs(stock);
                OnStockChecked(args);
            }
        }

        protected virtual void OnStockChecked(StockChangedEventArgs e)
        {
            EventHandler<StockChangedEventArgs> handler = StockChecked;
            if (handler != null)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                handler(this, e);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        void ListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView lw = (ListView)sender;
            ListViewItem item = e.Item;

            if (item.Checked)
            {
                this.listView1.ItemChecked -= new ItemCheckedEventHandler(ListView_ItemChecked);

                string code = item.SubItems[0].Text;
                string name = item.SubItems[1].Text;

                SmpStock stock = new SmpStock(code, name);
                stock.Checked = item.Checked;
                StockChecked_CallBack(stock);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        protected override void OnNotifyMessage(Message m)
        {
            // Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
        #endregion

    }
}
