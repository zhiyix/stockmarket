using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Globalization;
//<!
using StockMarket.Utils;
using StockMarket.Model;

namespace StockMarket.UI
{
    public class DealPanel : TableViewPanel
    {
        private static Int16 COLUMNS = 1;
        private static Int16 ROWS = 2;
        private static Int16 STOCK_CODE_LEN = 6;

        // 初始总资产
        private static double Init_Asset = 60937.96F;
        // 剩余额度
        private static double Avail_Quota = 2120.99F;
        // Close Asset
        private static double Close_Day_Asset = 47041.99F;

        #region UI
        public event EventHandler<IndexEventArgs> IndexItemChanged;
        private BoardPanel m_BoardPanel = new BoardPanel();
        private StockListView m_DealList = new StockListView();
        private Deal m_DealObj = new Deal();
        private Color Color_Green = Color.Green;
        private Color Color_Red = Color.FromArgb(255, 50, 50);
        private ToolTip tooltip;
        #endregion

        public DealPanel()
            : base(COLUMNS, ROWS)
        {
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));

            this.Controls.Add(this.m_BoardPanel, 0, 0);
            this.Controls.Add(this.m_DealList, 0, 1);
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            HorizontalAlignment align = HorizontalAlignment.Left;
            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            foreach (String name in m_DealObj.arr_DealDetailNames)
            {
                if (name.Equals("持仓量"))
                {
                    align = HorizontalAlignment.Right;
                }
                this.m_DealList.Columns.Add(name, -2, align);
            }
            UpdateListData(m_DealObj.m_DealList);
        }

        private bool UpdateListData(List<DealInfo> deals)
        {
            double total_cost = 0;
            double total_value = 0;
            this.m_DealList.Items.Clear();
            foreach (DealInfo deal in deals)
            {
                ListViewItem item = new ListViewItem(deal.Stock.Code);
                // 股  票
                item.SubItems.Add(deal.Stock.Name);
                item.SubItems.Add(deal.Amount.ToString("N0", CultureInfo.InvariantCulture));
                item.SubItems.Add(deal.Cost.ToString("F3", CultureInfo.InvariantCulture));
                if (deal.Price < 1)
                {
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                } else {
                    // 市  价
                    item.SubItems.Add(deal.Price.ToString("F2", CultureInfo.InvariantCulture));
                    // 市  值
                    item.SubItems.Add(deal.Value.ToString("F2", CultureInfo.InvariantCulture));
                    // 浮动盈亏
                    item.SubItems.Add(String.Format("{1:F2}%({0:F2})",
                        deal.Profit, deal.Profit * 100 / (deal.Amount * deal.Cost)));
                }
                // 交易时间
                item.SubItems.Add(deal.Date.ToString("d"));
                if (deal.Halt)
                {
                    if (deal.Profit > 0)
                    {
                        item.ForeColor = Color.DarkRed;
                    }
                    else if (deal.Profit < 0)
                    {
                        item.ForeColor = Color.LightSeaGreen;
                    }
                }
                else
                {
                    if (deal.Profit > 0)
                    {
                        item.ForeColor = Color_Red;
                    }
                    else if (deal.Profit < 0)
                    {
                        item.ForeColor = Color_Green;
                    }
                }
                this.m_DealList.Items.Add(item);
                this.m_DealList.Sort();
                total_cost += deal.Cost * deal.Amount;
                total_value += deal.Value;
            }
            m_BoardPanel.UpdateData(Init_Asset, Avail_Quota, Close_Day_Asset, total_value, total_cost);
            return true;
        }

        public bool UpdateStockData(List<StockType> list)
        {
            bool bUpdate = false;
            foreach (DealInfo deal in m_DealObj.m_DealList)
            {      
                string code = deal.Stock.Code;
                if (code.Length == STOCK_CODE_LEN)
                {
                    foreach (StockType stock in list)
                    {
                        if (code.Equals(stock.Code) && stock.Name != null)
                        {
                            // 股  票
                            deal.Stock.Name = stock.Name;
                            // 市  价
                            deal.Price = stock.getStockMarket().NowPrice;
                            if (deal.Price < 1)
                            {
                                deal.Halt = true;
                                deal.Price = stock.getStockMarket().ClosePrice;
                            }
                            else
                            {
                                deal.Halt = false;
                            }
                            bUpdate = true;
                        }
                    }
                }
            }
            if (bUpdate)
            {
                UpdateListData(m_DealObj.m_DealList);
                return true;
            }
            else {
                return false;
            }
        }
    }

    public class BoardPanel : TableViewPanel
    {
        private static Int16 COLUMNS = 5;
        private static Int16 ROWS = 1;
        private static String[] Stick_Names = 
        {
            "总资产",
            "总市值",
            "可用额",
            "日盈亏",
            "总盈亏",
        };

        public StickPanel[] sticks = new StickPanel[COLUMNS];
        
        public BoardPanel()
            : base(COLUMNS, ROWS)
        {
            this.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;

            for (int i = 0; i < COLUMNS; i++)
            {
                Single percent = 100F / COLUMNS;
                this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, percent));
            }
            for (int i = 0; i < COLUMNS; i++)
            {
                sticks[i] = new StickPanel(Stick_Names[i]);

                this.Controls.Add(sticks[i]);
            }
            this.HScroll = false;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
        }

        public void UpdateData(double Init_Asset, double Avail_Quota, double Close_Day_Asset, double Total_Value, double Total_Cost)
        {
            Asset asset = new Asset(Init_Asset, Avail_Quota, Close_Day_Asset);
            asset.Value = Total_Value;
            // "总资产"
            sticks[0].Value.Text = asset.NowAsset.ToString("F2", CultureInfo.InvariantCulture);
            // "总市值"
            sticks[1].Value.Text = asset.Value.ToString("F2", CultureInfo.InvariantCulture);
            // "可用额"
            sticks[2].Value.Text = asset.Quota.ToString("F2", CultureInfo.InvariantCulture);
            // "日盈亏"
            sticks[3].Value.Text = String.Format("{0:F2}\n{1:F2}%",
                asset.DayProfit, asset.DayProfit * 100 / asset.CloseDayAsset);
            if (asset.DayProfit > 0)
            {
                sticks[3].Value.ForeColor = Color.Red;
            }
            else if (asset.DayProfit < 0)
            {
                sticks[3].Value.ForeColor = Color.Green;
            }
            // "总盈亏"
            sticks[4].Value.Text = String.Format("{0:F2}\n{1:F2}%",
                asset.NowProfit, asset.NowProfit * 100 / Total_Cost);
            if (asset.NowProfit > 0)
            {
                sticks[4].Value.ForeColor = Color.Red;
            }
            else if (asset.NowProfit < 0)
            {
                sticks[4].Value.ForeColor = Color.Green;
            }
        }
    }

    public class StickPanel : TableViewPanel
    {
        private static Int16 COLUMNS = 1;
        private static Int16 ROWS = 2;

        public Label Caption = new Label();
        public Label Value = new Label();

        public StickPanel(String title)
            : base(COLUMNS, ROWS)
        {
            this.Caption.Dock = DockStyle.Fill;
            this.Caption.Text = title;
            this.Caption.TextAlign = ContentAlignment.MiddleCenter;

            this.Value.Dock = DockStyle.Fill;
            this.Value.Text = "--";
            this.Value.Font = new Font("Arial", 15, this.Font.Style);
            this.Value.TextAlign = ContentAlignment.MiddleCenter;

            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));

            this.AutoScroll = false;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Caption);
        }
    }
}
