using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
//<!
using StockMarket.Model;

namespace StockMarket.UI
{
    public class StockPanel : TableViewPanel
    {
        private bool debug = true;

        #region EVENT
        public event EventHandler<StockChangedEventArgs> StockChanged;
        public event EventHandler<StockChangedEventArgs> StockChecked;
        #endregion

        #region UI
        private TextBox stockText = new TextBox();
        private StockListView stockList = new StockListView();
        private ListViewColumnSorter lvwColumnSorter;
        #endregion

        #region DATA
        private static Int16 STOCK_CODE_LEN = 6;
        private static Int16 COLUMNS = 1;
        private static Int16 ROWS = 2;
        #endregion

        public StockPanel()
            : base(COLUMNS, ROWS)
        {
            // 创建一个ListView排序类的对象，并设置listView1的排序器
            lvwColumnSorter = new ListViewColumnSorter(0);
            stockList.ListViewItemSorter = lvwColumnSorter;
            stockList.CheckBoxes = true;

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            stockList.Columns.Add("股票代码", -2, HorizontalAlignment.Left);
            stockList.Columns.Add("股票名称", -2, HorizontalAlignment.Left);
            stockList.ColumnClick += new ColumnClickEventHandler(StockList_ColumnClick);

            stockText.Dock = DockStyle.Fill;
            stockText.Multiline = true;
            stockText.TextChanged += new EventHandler(StockText_TextChanged_EventHandler);

            this.VisibleChanged += new EventHandler(StockPanel_VisibleChanged);
        }

        void StockPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                stockList.ItemChecked += new ItemCheckedEventHandler(StockList_ItemChecked);
            }
            else
            {
                stockList.ItemChecked -= new ItemCheckedEventHandler(StockList_ItemChecked);
            }
        }

        #region 消息响应处理函数
        void StockList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (sender is ListView)
            {
                // 检查点击的列是否是现在的排序列.
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // 重新设置此列的排序方法.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    return;
                    // 设置排序列，默认为正向排序
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
                // 用新的排序方法对ListView排序
                ((ListView)sender).Sort();
            }
        }

        void StockList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView lw = (ListView)sender;
            ListViewItem item = e.Item;

            string code = item.SubItems[0].Text;
            string name = item.SubItems[1].Text;

            SmpStock stock = new SmpStock(code, name);
            stock.Checked = item.Checked;
            StockChecked_CallBack(stock);
        }

        private void StockText_TextChanged_EventHandler(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox = (TextBox)sender;
                if (textBox.SelectionStart > 0)
                {
                    if (textBox.Text.IndexOf('\n') > 0)
                    {
                        char[] separator = { '\r', '\n', };
                        string[] splits = textBox.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (splits.Length > 0)
                        {
                            string pattern = @"[0-9]{6,6}";
                            Regex rgx = new Regex(pattern);
                            //if (splits[0].Length == STOCK_CODE_LEN && Int32.TryParse(splits[0], out nCode))
                            if (rgx.IsMatch(splits[0]))
                            {
                                // Find matches.
                                MatchCollection matches = rgx.Matches(splits[0]);
                                Match match = matches[0];
                                GroupCollection groups = match.Groups;
                                if (groups[0].Value.Length == STOCK_CODE_LEN)
                                {
                                    SmpStock stock = new SmpStock(groups[0].Value, "--");
                                    StockChanged_CallBack(stock);
                                    stockText.TextChanged -= new EventHandler(StockText_TextChanged_EventHandler);
                                    textBox.Text = groups[0].Value;
                                    textBox.SelectAll();
                                    stockText.TextChanged += new EventHandler(StockText_TextChanged_EventHandler);
                                }
                            }
                            else
                            {
                                SmpStock stock = new SmpStock("", splits[0]);
                                StockChanged_CallBack(stock);
                                stockText.TextChanged -= new EventHandler(StockText_TextChanged_EventHandler);
                                textBox.Clear();
                                stockText.TextChanged += new EventHandler(StockText_TextChanged_EventHandler);
                            }
                            //textBox.SelectionStart = textBox.Text.Length;
                        }
                    }
                }
            }
        }

        private void StockChanged_CallBack(SmpStock stock)
        {
            if (stock != null)
            {
                StockChangedEventArgs args = new StockChangedEventArgs(stock);
                OnStockChanged(args);
            }
        }

        protected virtual void OnStockChanged(StockChangedEventArgs e)
        {
            EventHandler<StockChangedEventArgs> handler = StockChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void StockChecked_CallBack(SmpStock stock)
        {
            if (stock != null && stock.Code.Length == STOCK_CODE_LEN)
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
        #endregion

        #region UI界面数据更新函数
        public void InitData(List<SmpStock> stocks)
        {
            InitTableComp(this);
            InitListData(stockList, stocks);
        }

        public void AddStockData(SmpStock stock)
        {
            addListData(stockList, stock);
        }

        private void InitTableComp(TableLayoutPanel table)
        {
            Label stockTip = new Label();
            stockTip.Text = "请在提示框内输入股票代码或名称：";
            stockTip.AutoSize = true;
            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 23));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.Controls.Clear();
            table.Controls.Add(stockTip);
            table.Controls.Add(stockText);
            table.Controls.Add(stockList);
        }
        private void InitListData(ListView listView, List<SmpStock> array)
        {
            listView.Items.Clear();
            foreach (SmpStock stock in array)
            {
                ListViewItem item = new ListViewItem(stock.Code);
                item.Checked = stock.Checked;
                item.SubItems.Add(stock.Name);
                listView.Items.Add(item);
            }
        }
        private void addListData(ListView listView, SmpStock stock)
        {
            ListViewItem item = new ListViewItem(stock.Code);
            item.SubItems.Add(stock.Name);
            listView.Items.Add(item);
            listView.Sort();
        }
        #endregion
    }

    // FireEventArgs: a custom event inherited from EventArgs.
    public class StockChangedEventArgs : EventArgs
    {
        public StockChangedEventArgs(SmpStock stock)
        {
            this.stock = stock;
        }

        // The fire event will have two pieces of information-- 
        // 1) Where the fire is, and 
        // 2) how "ferocious" it is.  

        public SmpStock stock;

    }    //end of class FireEventArgs
}
