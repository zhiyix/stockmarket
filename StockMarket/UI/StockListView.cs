using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockMarket.UI
{
    public class StockListView : ListView
    {
        public StockListView()
        {
            this.Items.Clear();
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
        }
    }
}
