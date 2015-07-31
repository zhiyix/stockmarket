using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockMarket.UI
{
    public partial class TableViewPanel : System.Windows.Forms.TableLayoutPanel
    {
        public TableViewPanel()
        {
            InitializeComponent(1, 1);
        }

        public TableViewPanel(int column, int row)
        {
            InitializeComponent(column, row);
        }

        private void InitializeComponent(int column, int row)
        {
            this.SuspendLayout();
            // 
            // TableView
            // 
            this.ColumnCount = column;
            //this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColumnStyles.Clear();
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.RowCount = row;
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RowStyles.Clear();
            //this.Size = new System.Drawing.Size(284, 262);
            this.TabIndex = 0;
            this.AutoScroll = true;

            this.Name = "TableViewPanel";
            this.Text = "TableViewPanel";
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeLayout(false);
        }
    }
}
