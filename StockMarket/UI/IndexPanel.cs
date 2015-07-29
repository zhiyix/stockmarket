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
    public class IndexPanel : CommonPanel
    {
        private bool debug = false;

        #region UI
        public event EventHandler<IndexEventArgs> IndexItemChanged;
        private ComboBox indexCombo = new ComboBox();
        private List<Label> indexLabels = new List<Label>();
        #endregion

        #region DATA
        private String[] IndexNames = new String[]{
            "上证指数",
            "深证成指",
            "中小板指",
            "创业板指",
        };
        private String[] arr_IndexItems = new String[] {
            "指数名称",
            "指数编码",
            "今日开盘价",
            "昨日收盘价",
            "当前价",
            "最高价",
            "最低价",
            "成交量",
            "成交金额",
            "刷新时间",
        };
        #endregion

        #region 属性
        private IndexType model;
        public IndexType Model { get { return model; } set { model = value; } }
        #endregion

        public IndexPanel()
        {
            indexCombo.Items.Clear();
            indexCombo.Items.AddRange(IndexNames);
            indexCombo.SelectedItem = IndexNames[0];
            indexCombo.SelectedIndexChanged +=
                new EventHandler(TabControl_Window_SelectedIndexChanged_EventHandler);

            StockIndexTable.ColumnCount = 2;
            StockIndexTable.Controls.Clear();

            foreach (string name in arr_IndexItems)
            {
                Label label1 = new Label();
                Label label2 = new Label();
                label1.Text = name;
                indexLabels.Add(label1);
                StockIndexTable.Controls.Add(label1);
                if (name.Equals(@"指数名称", StringComparison.CurrentCultureIgnoreCase))
                {
                    indexLabels.Add(label2);
                    StockIndexTable.Controls.Add(indexCombo);
                    continue;
                }
                else
                {
                    label2.Text = "-";
                    indexLabels.Add(label2);
                    StockIndexTable.Controls.Add(label2);
                }
            }
        }

        #region 消息响应处理函数
        private void TabControl_Window_SelectedIndexChanged_EventHandler(object sender, EventArgs e)
        {
            if (sender is TabControl)
            {
                TabControl tabCtrl = (TabControl)sender;
                //updateTabControl((TabControl)tabCtrl);
            }
        }

        private void IndexCombo_SelectedIndexChanged_EventHandler(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox cbx = (ComboBox)sender;
                foreach (String idx_name in IndexNames)
                {
                    if (cbx.SelectedItem.Equals(idx_name))
                    {
                        UpdateData();
                        IndexItemChanged_CallBack(cbx.SelectedIndex);
                    }
                }
            }
        }

        private void IndexItemChanged_CallBack(int threshold)
        {
            if (threshold >= 0)
            {
                IndexEventArgs args = new IndexEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnIndexItemChanged(args);
            }
        }

        protected virtual void OnIndexItemChanged(IndexEventArgs e)
        {
            EventHandler<IndexEventArgs> handler = IndexItemChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region UI界面数据更新函数
        public void UpdateData()
        {
            updateTableData(StockIndexTable);
        }
        
        private void updateTableData(TableLayoutPanel table)
        {
            foreach (IndexInfo idx in this.Model.getIndexList())
            {
                if (idx.Name.Equals(indexCombo.SelectedItem.ToString()))
                {
                    //table.Controls.Clear();
                    //indexCombo.SelectedIndexChanged -= new EventHandler(TabControl_Window_SelectedIndexChanged_EventHandler);
                    for (System.Collections.IEnumerator ie = this.indexLabels.GetEnumerator(); ie.MoveNext(); )
                    {
                        Label label1 = (Label)ie.Current;
                        String name = label1.Text;
                        if (ie.MoveNext())
                        {
                            Label label2 = (Label)ie.Current;
                            if (idx.NowPrice > idx.YestodayClosePrice)
                            {
                                label2.ForeColor = Color.Red;
                            }
                            else if (idx.NowPrice < idx.YestodayClosePrice)
                            {
                                label2.ForeColor = Color.Green;
                            }
                            else
                            {
                                label2.ForeColor = SystemColors.ControlText;
                            }
                            if (name.Equals(@"指数名称", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //table.Controls.Add(indexCombo);
                                //indexCombo.SelectedIndexChanged += 
                                //new EventHandler(TabControl_Window_SelectedIndexChanged_EventHandler);
                                continue;
                            }
                            else if (name.Equals(@"指数编码", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = SystemColors.ControlText;
                                label2.Text = idx.Code;
                            }
                            else if (name.Equals(@"当前价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = idx.NowPrice.ToString("F", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"昨日收盘价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = SystemColors.ControlText;
                                label2.Text = idx.YestodayClosePrice.ToString("F", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"今日开盘价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = idx.TodayOpenPrice.ToString("F", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"最高价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = idx.MaxPrice.ToString("F", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"最低价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = idx.MinPrice.ToString("F", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"成交量", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = SystemColors.ControlText;
                                label2.Text = idx.TradeNum.ToString("N", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"成交金额", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = SystemColors.ControlText;
                                label2.Text = idx.TradeAmount.ToString("N2", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"刷新时间", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = SystemColors.ControlText;
                                if (table.Width > 200)
                                {
                                    label2.Text = idx.Time.ToString("G", DateTimeFormatInfo.InvariantInfo);
                                }
                                else
                                {
                                    label2.Text = idx.Time.ToString("d");
                                }
                                label2.AutoSize = true;
                            }
                        }
                    }
                    /*
                    foreach (Label label in this.indexLabels)
                    {
                        Label label1 = new Label();
                        Label label2 = new Label();
                        label1.Text = name;
                        table.Controls.Add(label1);
                        if (name.Equals(@"指数名称", StringComparison.CurrentCultureIgnoreCase))
                        {
                            table.Controls.Add(indexCombo);
                            indexCombo.SelectedIndexChanged += new EventHandler(TabControl_Window_SelectedIndexChanged_EventHandler);
                            continue;
                        }
                        else if (name.Equals(@"指数编码", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.Code;
                        }
                        else if (name.Equals(@"当前价", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.NowPrice.ToString("F", CultureInfo.InvariantCulture);
                        }
                        else if (name.Equals(@"昨日收盘价", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.YestodayClosePrice.ToString("F", CultureInfo.InvariantCulture);
                        }
                        else if (name.Equals(@"今日开盘价", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.TodayOpenPrice.ToString("F", CultureInfo.InvariantCulture);
                        }
                        else if (name.Equals(@"最高价", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.MaxPrice.ToString("F", CultureInfo.InvariantCulture);
                        }
                        else if (name.Equals(@"最低价", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.MinPrice.ToString("F", CultureInfo.InvariantCulture);
                        }
                        else if (name.Equals(@"成交量", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.TradeNum.ToString("N", CultureInfo.InvariantCulture);
                        }
                        else if (name.Equals(@"成交金额", StringComparison.CurrentCultureIgnoreCase))
                        {
                            label2.Text = idx.TradeAmount.ToString("N2", CultureInfo.InvariantCulture);
                        }
                        else if (name.Equals(@"刷新时间", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (table.Width > 200)
                            {
                                label2.Text = idx.Time.ToString("G", DateTimeFormatInfo.InvariantInfo);
                            }
                            else
                            {
                                label2.Text = idx.Time.ToString("d");
                            }
                            label2.AutoSize = true;
                        }
                        table.Controls.Add(label2);
                    }*/
                }
            }
            if (debug)
            {
                Console.WriteLine("[INFO] UpdateData OK.");
                Console.WriteLine("****************************************************************");
            }
        }
        #endregion
    }

    // FireEventArgs: a custom event inherited from EventArgs.
    public class IndexEventArgs : EventArgs
    {
        public IndexEventArgs(string room, int ferocity)
        {
            this.room = room;
            this.ferocity = ferocity;
        }

        public IndexEventArgs()
        {
            this.room = "";
            this.ferocity = 0;
        }

        // The fire event will have two pieces of information-- 
        // 1) Where the fire is, and 
        // 2) how "ferocious" it is.  

        public string room;
        public int ferocity;
        public int Threshold;
        public DateTime TimeReached;

    }    //end of class FireEventArgs
}
