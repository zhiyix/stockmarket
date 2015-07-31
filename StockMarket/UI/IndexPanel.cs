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
    public class IndexPanel : TableViewPanel
    {
        private bool debug = false;

        #region UI
        public event EventHandler<IndexEventArgs> IndexItemChanged;
        private ComboBox indexCombo = new ComboBox();
        private List<Label> indexLabels = new List<Label>();
        private ToolTip tooltip;
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
            "今开盘价",
            "昨收盘价",
            "实时价格",
            "涨 跌 幅",
            "最高价格",
            "最低价格",
            "成交均价",
            "成 交 量",
            "成交金额",
            "刷新时间",
        };
        private static Int16 COLUMNS = 2;
        private static Int16 ROWS = 1;
        #endregion

        #region 属性
        private IndexType model;
        public IndexType Model { get { return model; } set { model = value; } }
        #endregion

        public IndexPanel()
            : base(COLUMNS, ROWS)
        {
            indexCombo.Items.Clear();
            indexCombo.Items.AddRange(IndexNames);
            indexCombo.SelectedItem = IndexNames[0];
            indexCombo.SelectedIndexChanged +=
                new EventHandler(TabControl_Window_SelectedIndexChanged_EventHandler);

            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.Controls.Clear();

            foreach (string name in arr_IndexItems)
            {
                Label label1 = new Label();
                Label label2 = new Label();

                label1.Text = name;
                indexLabels.Add(label1);
                this.Controls.Add(label1);
                if (name.Equals(@"指数名称", StringComparison.CurrentCultureIgnoreCase))
                {
                    indexLabels.Add(label2);
                    this.Controls.Add(indexCombo);
                    continue;
                }
                else
                {
                    label2.Text = "-";
                    label2.MouseHover += new EventHandler(Labels_MouseHover);
                    indexLabels.Add(label2);
                    this.Controls.Add(label2);
                }
            }
            this.tooltip = new ToolTip();
            this.tooltip.AutoPopDelay = 5000;
            this.tooltip.InitialDelay = 1000;
            this.tooltip.ReshowDelay = 500;
            this.tooltip.ShowAlways = true;
        }

        void Labels_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label label = (Label)sender;
                if (label.Tag != null)
                {
                    LabelTip obj = (LabelTip)label.Tag;
                    //this.tooltip.SetToolTip(label, obj.ToString());
                    this.tooltip.ForeColor = obj.ForeColor;
                    this.tooltip.Show(obj.ToString(), label);
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
            updateTableData(this);
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

                            if (name.Equals(@"指数名称", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //table.Controls.Add(indexCombo);
                                //indexCombo.SelectedIndexChanged += 
                                //new EventHandler(TabControl_Window_SelectedIndexChanged_EventHandler);
                                continue;
                            }
                            else if (name.Equals(@"指数编码", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = idx.Code;
                            }
                            else if (name.Equals(@"实时价格", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = calcColor(idx.NowPrice, idx.YestodayClosePrice);
                                label2.Text = idx.NowPrice.ToString("F", CultureInfo.InvariantCulture);
                                label2.Tag = new LabelTip(
                                    String.Format("{0:F2}%", (idx.NowPrice - idx.YestodayClosePrice) * 100 / idx.YestodayClosePrice), 
                                    label2.ForeColor);
                            }
                            else if (name.Equals(@"涨 跌 幅", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = calcColor(idx.NowPrice, idx.YestodayClosePrice);
                                label2.Text = String.Format("{0:F2}%({1:F2})",
                                    (idx.NowPrice - idx.YestodayClosePrice) * 100 / idx.YestodayClosePrice,
                                    (idx.NowPrice - idx.YestodayClosePrice));
                            }
                            else if (name.Equals(@"昨收盘价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = idx.YestodayClosePrice.ToString("F", CultureInfo.InvariantCulture);
                            }
                            else if (name.Equals(@"今开盘价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = calcColor(idx.TodayOpenPrice, idx.YestodayClosePrice);
                                label2.Text = idx.TodayOpenPrice.ToString("F", CultureInfo.InvariantCulture);
                                label2.Tag = new LabelTip(
                                    String.Format("{0:F2}%", (idx.TodayOpenPrice - idx.YestodayClosePrice) * 100 / idx.YestodayClosePrice),
                                    label2.ForeColor);
                            }
                            else if (name.Equals(@"最高价格", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = calcColor(idx.MaxPrice, idx.YestodayClosePrice);
                                label2.Text = idx.MaxPrice.ToString("F", CultureInfo.InvariantCulture);
                                label2.Tag = new LabelTip(
                                    String.Format("{0:F2}%", (idx.MaxPrice - idx.YestodayClosePrice) * 100 / idx.YestodayClosePrice),
                                    label2.ForeColor);
                            }
                            else if (name.Equals(@"最低价格", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.ForeColor = calcColor(idx.MinPrice, idx.YestodayClosePrice);
                                label2.Text = idx.MinPrice.ToString("F", CultureInfo.InvariantCulture);
                                label2.Tag = new LabelTip(
                                    String.Format("{0:F2}%", (idx.MinPrice - idx.YestodayClosePrice) * 100 / idx.YestodayClosePrice),
                                    label2.ForeColor);
                            }
                            else if (name.Equals(@"成交均价", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = String.Format("{0:F2}", (idx.TradeAmount) / idx.TradeNum);
                            }
                            else if (name.Equals(@"成 交 量", StringComparison.CurrentCultureIgnoreCase))
                            {
                                label2.Text = idx.TradeNum.ToString("N0", CultureInfo.InvariantCulture);
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
                        }
                    }
                }
            }
            if (debug)
            {
                Console.WriteLine("[INFO] UpdateData OK.");
                Console.WriteLine("****************************************************************");
            }
        }
        #endregion

        private Color calcColor(double first, double second)
        {
            if (first > second)
            {
                return Color.Red;
            }
            else {
                return Color.Green;
            }
        }
    }

    public class LabelTip
    {
        private String info;
        private Color color;

        public LabelTip(string p, Color color)
        {
            this.Info = p;
            this.color = color;
        }

        public String Info { get { return info; } set { info = value; } }
        public Color ForeColor { get { return color; } set { color = value; } }

        public override string ToString()
        {
            return info;
        }
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
