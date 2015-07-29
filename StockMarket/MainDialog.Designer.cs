namespace StockMarket
{
    partial class MainDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.SplitContainer_Up = new System.Windows.Forms.SplitContainer();
            this.TabControl_Left = new System.Windows.Forms.TabControl();
            this.TabPage_Market = new System.Windows.Forms.TabPage();
            this.StatusStrip_Index = new System.Windows.Forms.StatusStrip();
            this.Label_DateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabPage_Stock = new System.Windows.Forms.TabPage();
            this.SplitContainer_Win = new System.Windows.Forms.SplitContainer();
            this.TabControl_Right = new System.Windows.Forms.TabControl();
            this.TabPage_StkDtl = new System.Windows.Forms.TabPage();
            this.TabPage_Rrv = new System.Windows.Forms.TabPage();
            this.TabControl_News = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Up)).BeginInit();
            this.SplitContainer_Up.Panel1.SuspendLayout();
            this.SplitContainer_Up.Panel2.SuspendLayout();
            this.SplitContainer_Up.SuspendLayout();
            this.TabControl_Left.SuspendLayout();
            this.TabPage_Market.SuspendLayout();
            this.StatusStrip_Index.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Win)).BeginInit();
            this.SplitContainer_Win.Panel1.SuspendLayout();
            this.SplitContainer_Win.SuspendLayout();
            this.TabControl_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            this.SplitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.SplitContainer_Up);
            this.SplitContainer_Main.Panel1MinSize = 250;
            this.SplitContainer_Main.Panel2Collapsed = true;
            this.SplitContainer_Main.Size = new System.Drawing.Size(1008, 322);
            this.SplitContainer_Main.SplitterDistance = 297;
            this.SplitContainer_Main.TabIndex = 0;
            // 
            // SplitContainer_Up
            // 
            this.SplitContainer_Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Up.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Up.Name = "SplitContainer_Up";
            // 
            // SplitContainer_Up.Panel1
            // 
            this.SplitContainer_Up.Panel1.Controls.Add(this.TabControl_Left);
            this.SplitContainer_Up.Panel1MinSize = 250;
            // 
            // SplitContainer_Up.Panel2
            // 
            this.SplitContainer_Up.Panel2.Controls.Add(this.SplitContainer_Win);
            this.SplitContainer_Up.Size = new System.Drawing.Size(1008, 322);
            this.SplitContainer_Up.SplitterDistance = 250;
            this.SplitContainer_Up.TabIndex = 0;
            // 
            // TabControl_Left
            // 
            this.TabControl_Left.Controls.Add(this.TabPage_Market);
            this.TabControl_Left.Controls.Add(this.TabPage_Stock);
            this.TabControl_Left.Controls.Add(this.TabControl_News);
            this.TabControl_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Left.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Left.Name = "TabControl_Left";
            this.TabControl_Left.SelectedIndex = 0;
            this.TabControl_Left.Size = new System.Drawing.Size(250, 322);
            this.TabControl_Left.TabIndex = 0;
            this.TabControl_Left.SelectedIndexChanged += new System.EventHandler(this.TabWindow_SelectedIndexChanged_EventHandler);
            // 
            // TabPage_Market
            // 
            this.TabPage_Market.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Market.Name = "TabPage_Market";
            this.TabPage_Market.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Market.Size = new System.Drawing.Size(242, 296);
            this.TabPage_Market.TabIndex = 0;
            this.TabPage_Market.Text = "股票指数";
            this.TabPage_Market.UseVisualStyleBackColor = true;
            // 
            // StatusStrip_Index
            // 
            this.StatusStrip_Index.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_DateTime,
            this.Label_Time});
            this.StatusStrip_Index.Location = new System.Drawing.Point(3, 271);
            this.StatusStrip_Index.Name = "StatusStrip_Index";
            this.StatusStrip_Index.Size = new System.Drawing.Size(236, 22);
            this.StatusStrip_Index.TabIndex = 0;
            this.StatusStrip_Index.Text = "StatusStrip_Index";
            // 
            // Label_DateTime
            // 
            this.Label_DateTime.AutoSize = false;
            this.Label_DateTime.Name = "Label_DateTime";
            this.Label_DateTime.Size = new System.Drawing.Size(130, 17);
            this.Label_DateTime.Text = "2015-01-01 00:00:00";
            this.Label_DateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Time
            // 
            this.Label_Time.Name = "Label_Time";
            this.Label_Time.Size = new System.Drawing.Size(91, 17);
            this.Label_Time.Spring = true;
            this.Label_Time.Text = "0";
            // 
            // TabPage_Stock
            // 
            this.TabPage_Stock.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Stock.Name = "TabPage_Stock";
            this.TabPage_Stock.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Stock.Size = new System.Drawing.Size(242, 296);
            this.TabPage_Stock.TabIndex = 1;
            this.TabPage_Stock.Text = "股票搜索";
            this.TabPage_Stock.UseVisualStyleBackColor = true;
            // 
            // SplitContainer_Win
            // 
            this.SplitContainer_Win.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Win.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Win.Name = "SplitContainer_Win";
            // 
            // SplitContainer_Win.Panel1
            // 
            this.SplitContainer_Win.Panel1.Controls.Add(this.TabControl_Right);
            this.SplitContainer_Win.Panel1MinSize = 250;
            this.SplitContainer_Win.Panel2Collapsed = true;
            this.SplitContainer_Win.Panel2MinSize = 250;
            this.SplitContainer_Win.Size = new System.Drawing.Size(754, 322);
            this.SplitContainer_Win.SplitterDistance = 250;
            this.SplitContainer_Win.TabIndex = 1;
            // 
            // TabControl_Right
            // 
            this.TabControl_Right.Controls.Add(this.TabPage_StkDtl);
            this.TabControl_Right.Controls.Add(this.TabPage_Rrv);
            this.TabControl_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Right.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Right.Name = "TabControl_Right";
            this.TabControl_Right.SelectedIndex = 0;
            this.TabControl_Right.Size = new System.Drawing.Size(754, 322);
            this.TabControl_Right.TabIndex = 0;
            // 
            // TabPage_StkDtl
            // 
            this.TabPage_StkDtl.Controls.Add(this.StatusStrip_Index);
            this.TabPage_StkDtl.Location = new System.Drawing.Point(4, 22);
            this.TabPage_StkDtl.Name = "TabPage_StkDtl";
            this.TabPage_StkDtl.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_StkDtl.Size = new System.Drawing.Size(746, 296);
            this.TabPage_StkDtl.TabIndex = 0;
            this.TabPage_StkDtl.Text = "自选股";
            this.TabPage_StkDtl.UseVisualStyleBackColor = true;
            // 
            // TabPage_Rrv
            // 
            this.TabPage_Rrv.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Rrv.Name = "TabPage_Rrv";
            this.TabPage_Rrv.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Rrv.Size = new System.Drawing.Size(746, 296);
            this.TabPage_Rrv.TabIndex = 1;
            this.TabPage_Rrv.UseVisualStyleBackColor = true;
            // 
            // TabControl_News
            // 
            this.TabControl_News.Location = new System.Drawing.Point(4, 22);
            this.TabControl_News.Name = "TabControl_News";
            this.TabControl_News.Padding = new System.Windows.Forms.Padding(3);
            this.TabControl_News.Size = new System.Drawing.Size(242, 296);
            this.TabControl_News.TabIndex = 2;
            this.TabControl_News.Text = "小贴士";
            this.TabControl_News.UseVisualStyleBackColor = true;
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 322);
            this.Controls.Add(this.SplitContainer_Main);
            this.Name = "MainDialog";
            this.Text = "StockMarket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDialog_FormClosing);
            this.Load += new System.EventHandler(this.MainDialog_Load);
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.SplitContainer_Up.Panel1.ResumeLayout(false);
            this.SplitContainer_Up.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Up)).EndInit();
            this.SplitContainer_Up.ResumeLayout(false);
            this.TabControl_Left.ResumeLayout(false);
            this.TabPage_Market.ResumeLayout(false);
            this.TabPage_Market.PerformLayout();
            this.StatusStrip_Index.ResumeLayout(false);
            this.StatusStrip_Index.PerformLayout();
            this.SplitContainer_Win.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Win)).EndInit();
            this.SplitContainer_Win.ResumeLayout(false);
            this.TabControl_Right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.SplitContainer SplitContainer_Up;
        private System.Windows.Forms.TabControl TabControl_Left;
        private System.Windows.Forms.TabPage TabPage_Market;
        private System.Windows.Forms.TabPage TabPage_Stock;
        private System.Windows.Forms.SplitContainer SplitContainer_Win;
        private System.Windows.Forms.TabControl TabControl_Right;
        private System.Windows.Forms.TabPage TabPage_StkDtl;
        private System.Windows.Forms.TabPage TabPage_Rrv;
        private System.Windows.Forms.StatusStrip StatusStrip_Index;
        private System.Windows.Forms.ToolStripStatusLabel Label_DateTime;
        private System.Windows.Forms.ToolStripStatusLabel Label_Time;
        private System.Windows.Forms.TabPage TabControl_News;
    }
}

