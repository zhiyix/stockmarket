using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
//<!
using StockMarket.Model;

namespace StockMarket.UI
{
    public class StockListView : ListView
    {
        private bool debug = true;
        private string p;

        //private HashSet<Stock> stockObjArray = new HashSet<Stock>();

        public StockListView(string p)
        {
            this.p = p;
            //stockObjArray.Clear();

            this.Dock = DockStyle.Fill;
            this.View = View.Details;
            this.LabelEdit = false;
            this.CheckBoxes = false;
            this.AllowColumnReorder = true;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.Scrollable = true;
            this.Sorting = SortOrder.Ascending;
            // 双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            // 使能 OnNotifyMessage 事件
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            this.Columns.Add("股票代码", -2, HorizontalAlignment.Left);
            this.Columns.Add("股票名称", -2, HorizontalAlignment.Left);
            this.Columns.Add("当前价", -2, HorizontalAlignment.Right);
            this.Columns.Add("涨跌", -2, HorizontalAlignment.Center);
            this.Columns.Add(" 涨  幅 ", -2, HorizontalAlignment.Right);
            this.Columns.Add("涨跌价", -2, HorizontalAlignment.Right);
            this.Columns.Add("收盘价", -2, HorizontalAlignment.Right);
            this.Columns.Add("开盘价", -2, HorizontalAlignment.Right);
            this.Columns.Add("最高价", -2, HorizontalAlignment.Right);
            this.Columns.Add("最低价", -2, HorizontalAlignment.Right);
            this.Columns.Add("竞买价", -2, HorizontalAlignment.Right);
            this.Columns.Add("竞卖价", -2, HorizontalAlignment.Right);
            this.Columns.Add("成交量", 80, HorizontalAlignment.Right);
            this.Columns.Add("成交金额", 120, HorizontalAlignment.Right);
        }

        protected override void OnNotifyMessage(Message m)
        {
            // Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        public void RemoveStockData(SmpStock stock)
        {
            foreach (ListViewItem item in this.Items)
            {
                string stk_code = item.SubItems[0].Text;
                if (stk_code.Equals(stock.Code))
                {
                    this.Items.Remove(item);
                    break;
                }
            }
        }

        public void UpdateStockData(List<StockType> array)
        {
            UpdateListData(array);
        }

        public void UpdateListData(List<StockType> array)
        {
            this.Items.Clear();
            foreach (StockType stock in array)
            {
                StockInfo sm = stock.getStockMarket();
                ListViewItem item = new ListViewItem(stock.Code);
                item.SubItems.Add(stock.Name);
                if (sm.NowPrice < 1)
                {
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                }
                else
                {
                    item.SubItems.Add(sm.NowPrice.ToString("F", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.NowPrice > sm.ClosePrice ? "↑" : "↓");
                    item.SubItems.Add(string.Format("{0:F2}%", (sm.NowPrice - sm.ClosePrice) * 100 / sm.ClosePrice));
                    item.SubItems.Add(string.Format("{0:F2}", sm.NowPrice - sm.ClosePrice));
                    item.SubItems.Add(sm.ClosePrice.ToString("F", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.OpenPrice.ToString("F", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.TodayMax.ToString("F", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.TodayMin.ToString("F", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.CompetBuyPrice.ToString("F", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.CompetSellPrice.ToString("F", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.TradeNum.ToString("N0", CultureInfo.InvariantCulture));
                    item.SubItems.Add(sm.TradeAmount.ToString("C2", CultureInfo.CreateSpecificCulture("zh-CN")));
                }
                if (sm.NowPrice > sm.ClosePrice)
                {
                    item.ForeColor = Color.Red;
                }
                else if (sm.NowPrice < sm.ClosePrice)
                {
                    item.ForeColor = Color.Green;
                }
                else
                {
                    item.ForeColor = SystemColors.ControlText;
                }
                this.Items.Add(item);
            }
        }
    }
}
