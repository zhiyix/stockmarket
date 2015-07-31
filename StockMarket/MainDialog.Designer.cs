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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.SplitContainer_Frame = new System.Windows.Forms.SplitContainer();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.SplitContainer_Win = new System.Windows.Forms.SplitContainer();
            this.TabControl_Index = new System.Windows.Forms.TabControl();
            this.TabPage_Market = new System.Windows.Forms.TabPage();
            this.TabPage_Stock = new System.Windows.Forms.TabPage();
            this.TabPage_News = new System.Windows.Forms.TabPage();
            this.TabControl_Deal = new System.Windows.Forms.TabControl();
            this.TabPage_Deal = new System.Windows.Forms.TabPage();
            this.TabPage_History = new System.Windows.Forms.TabPage();
            this.TabControl_Stock = new System.Windows.Forms.TabControl();
            this.TabPage_StockDetail = new System.Windows.Forms.TabPage();
            this.TabPage_Reserve = new System.Windows.Forms.TabPage();
            this.StatusStrip_Index = new System.Windows.Forms.StatusStrip();
            this.ToolStripLabel_DateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripLabel_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar_Time = new System.Windows.Forms.ToolStripProgressBar();
            this.ToolStripLabel_Reserve = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripButton_Trade = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripButton_Info = new System.Windows.Forms.ToolStripSplitButton();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Frame)).BeginInit();
            this.SplitContainer_Frame.Panel1.SuspendLayout();
            this.SplitContainer_Frame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Win)).BeginInit();
            this.SplitContainer_Win.Panel1.SuspendLayout();
            this.SplitContainer_Win.Panel2.SuspendLayout();
            this.SplitContainer_Win.SuspendLayout();
            this.TabControl_Index.SuspendLayout();
            this.TabControl_Deal.SuspendLayout();
            this.TabControl_Stock.SuspendLayout();
            this.StatusStrip_Index.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer_Frame
            // 
            this.SplitContainer_Frame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_Frame.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Frame.Name = "SplitContainer_Frame";
            // 
            // SplitContainer_Frame.Panel1
            // 
            this.SplitContainer_Frame.Panel1.Controls.Add(this.SplitContainer_Main);
            this.SplitContainer_Frame.Panel1MinSize = 240;
            this.SplitContainer_Frame.Panel2MinSize = 240;
            this.SplitContainer_Frame.Size = new System.Drawing.Size(1008, 637);
            this.SplitContainer_Frame.SplitterDistance = 760;
            this.SplitContainer_Frame.TabIndex = 0;
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
            this.SplitContainer_Main.Panel1.Controls.Add(this.SplitContainer_Win);
            this.SplitContainer_Main.Panel1MinSize = 240;
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.TabControl_Stock);
            this.SplitContainer_Main.Panel2MinSize = 240;
            this.SplitContainer_Main.Size = new System.Drawing.Size(760, 637);
            this.SplitContainer_Main.SplitterDistance = 393;
            this.SplitContainer_Main.TabIndex = 0;
            // 
            // SplitContainer_Win
            // 
            this.SplitContainer_Win.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Win.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Win.Name = "SplitContainer_Win";
            // 
            // SplitContainer_Win.Panel1
            // 
            this.SplitContainer_Win.Panel1.Controls.Add(this.TabControl_Index);
            this.SplitContainer_Win.Panel1MinSize = 200;
            // 
            // SplitContainer_Win.Panel2
            // 
            this.SplitContainer_Win.Panel2.Controls.Add(this.TabControl_Deal);
            this.SplitContainer_Win.Size = new System.Drawing.Size(760, 393);
            this.SplitContainer_Win.SplitterDistance = 200;
            this.SplitContainer_Win.TabIndex = 3;
            // 
            // TabControl_Index
            // 
            this.TabControl_Index.Controls.Add(this.TabPage_Market);
            this.TabControl_Index.Controls.Add(this.TabPage_Stock);
            this.TabControl_Index.Controls.Add(this.TabPage_News);
            this.TabControl_Index.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Index.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Index.Name = "TabControl_Index";
            this.TabControl_Index.SelectedIndex = 0;
            this.TabControl_Index.Size = new System.Drawing.Size(200, 393);
            this.TabControl_Index.TabIndex = 1;
            // 
            // TabPage_Market
            // 
            this.TabPage_Market.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Market.Name = "TabPage_Market";
            this.TabPage_Market.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Market.Size = new System.Drawing.Size(192, 367);
            this.TabPage_Market.TabIndex = 0;
            this.TabPage_Market.Text = "股票指数";
            this.TabPage_Market.UseVisualStyleBackColor = true;
            // 
            // TabPage_Stock
            // 
            this.TabPage_Stock.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Stock.Name = "TabPage_Stock";
            this.TabPage_Stock.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Stock.Size = new System.Drawing.Size(232, 367);
            this.TabPage_Stock.TabIndex = 1;
            this.TabPage_Stock.Text = "股票搜索";
            this.TabPage_Stock.UseVisualStyleBackColor = true;
            // 
            // TabPage_News
            // 
            this.TabPage_News.Location = new System.Drawing.Point(4, 22);
            this.TabPage_News.Name = "TabPage_News";
            this.TabPage_News.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_News.Size = new System.Drawing.Size(232, 367);
            this.TabPage_News.TabIndex = 2;
            this.TabPage_News.Text = "小贴士";
            this.TabPage_News.UseVisualStyleBackColor = true;
            // 
            // TabControl_Deal
            // 
            this.TabControl_Deal.Controls.Add(this.TabPage_Deal);
            this.TabControl_Deal.Controls.Add(this.TabPage_History);
            this.TabControl_Deal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Deal.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Deal.Name = "TabControl_Deal";
            this.TabControl_Deal.SelectedIndex = 0;
            this.TabControl_Deal.Size = new System.Drawing.Size(556, 393);
            this.TabControl_Deal.TabIndex = 0;
            // 
            // TabPage_Deal
            // 
            this.TabPage_Deal.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Deal.Name = "TabPage_Deal";
            this.TabPage_Deal.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Deal.Size = new System.Drawing.Size(548, 367);
            this.TabPage_Deal.TabIndex = 0;
            this.TabPage_Deal.Text = "交易";
            this.TabPage_Deal.UseVisualStyleBackColor = true;
            // 
            // TabPage_History
            // 
            this.TabPage_History.Location = new System.Drawing.Point(4, 22);
            this.TabPage_History.Name = "TabPage_History";
            this.TabPage_History.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_History.Size = new System.Drawing.Size(756, 367);
            this.TabPage_History.TabIndex = 1;
            this.TabPage_History.Text = "历史盈亏";
            this.TabPage_History.UseVisualStyleBackColor = true;
            // 
            // TabControl_Stock
            // 
            this.TabControl_Stock.Controls.Add(this.TabPage_StockDetail);
            this.TabControl_Stock.Controls.Add(this.TabPage_Reserve);
            this.TabControl_Stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Stock.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Stock.Name = "TabControl_Stock";
            this.TabControl_Stock.SelectedIndex = 0;
            this.TabControl_Stock.Size = new System.Drawing.Size(760, 240);
            this.TabControl_Stock.TabIndex = 2;
            // 
            // TabPage_StockDetail
            // 
            this.TabPage_StockDetail.Location = new System.Drawing.Point(4, 22);
            this.TabPage_StockDetail.Name = "TabPage_StockDetail";
            this.TabPage_StockDetail.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_StockDetail.Size = new System.Drawing.Size(752, 214);
            this.TabPage_StockDetail.TabIndex = 0;
            this.TabPage_StockDetail.Text = "自选股";
            this.TabPage_StockDetail.UseVisualStyleBackColor = true;
            // 
            // TabPage_Reserve
            // 
            this.TabPage_Reserve.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Reserve.Name = "TabPage_Reserve";
            this.TabPage_Reserve.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Reserve.Size = new System.Drawing.Size(1000, 214);
            this.TabPage_Reserve.TabIndex = 1;
            this.TabPage_Reserve.UseVisualStyleBackColor = true;
            // 
            // StatusStrip_Index
            // 
            this.StatusStrip_Index.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel_DateTime,
            this.ToolStripLabel_Time,
            this.ToolStripProgressBar_Time,
            this.ToolStripLabel_Reserve,
            this.ToolStripButton_Trade,
            this.ToolStripButton_Info});
            this.StatusStrip_Index.Location = new System.Drawing.Point(0, 640);
            this.StatusStrip_Index.Name = "StatusStrip_Index";
            this.StatusStrip_Index.Size = new System.Drawing.Size(1008, 22);
            this.StatusStrip_Index.TabIndex = 0;
            this.StatusStrip_Index.Text = "StatusStrip_Index";
            // 
            // ToolStripLabel_DateTime
            // 
            this.ToolStripLabel_DateTime.AutoSize = false;
            this.ToolStripLabel_DateTime.Name = "ToolStripLabel_DateTime";
            this.ToolStripLabel_DateTime.Size = new System.Drawing.Size(130, 17);
            this.ToolStripLabel_DateTime.Text = "2015-01-01 00:00:00";
            this.ToolStripLabel_DateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolStripLabel_Time
            // 
            this.ToolStripLabel_Time.AutoSize = false;
            this.ToolStripLabel_Time.Name = "ToolStripLabel_Time";
            this.ToolStripLabel_Time.Size = new System.Drawing.Size(100, 17);
            this.ToolStripLabel_Time.Text = "0";
            // 
            // ToolStripProgressBar_Time
            // 
            this.ToolStripProgressBar_Time.AutoSize = false;
            this.ToolStripProgressBar_Time.Maximum = 255;
            this.ToolStripProgressBar_Time.Name = "ToolStripProgressBar_Time";
            this.ToolStripProgressBar_Time.Size = new System.Drawing.Size(255, 16);
            this.ToolStripProgressBar_Time.Step = 1;
            // 
            // ToolStripLabel_Reserve
            // 
            this.ToolStripLabel_Reserve.Name = "ToolStripLabel_Reserve";
            this.ToolStripLabel_Reserve.Size = new System.Drawing.Size(442, 17);
            this.ToolStripLabel_Reserve.Spring = true;
            this.ToolStripLabel_Reserve.Text = "toolStripStatusLabel1";
            // 
            // ToolStripButton_Trade
            // 
            this.ToolStripButton_Trade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Trade.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Trade.Image")));
            this.ToolStripButton_Trade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Trade.Name = "ToolStripButton_Trade";
            this.ToolStripButton_Trade.Size = new System.Drawing.Size(32, 20);
            this.ToolStripButton_Trade.Text = "toolStripSplitButton1";
            this.ToolStripButton_Trade.Click += new System.EventHandler(this.ToolStripButton_Trade_Click);
            // 
            // ToolStripButton_Info
            // 
            this.ToolStripButton_Info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Info.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Info.Image")));
            this.ToolStripButton_Info.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Info.Name = "ToolStripButton_Info";
            this.ToolStripButton_Info.Size = new System.Drawing.Size(32, 20);
            this.ToolStripButton_Info.Text = "toolStripSplitButton1";
            this.ToolStripButton_Info.Click += new System.EventHandler(this.ToolStripButton_Info_Click);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.StatusStrip_Index);
            this.Controls.Add(this.SplitContainer_Frame);
            this.Name = "MainDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockMarket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDialog_FormClosing);
            this.Load += new System.EventHandler(this.MainDialog_Load);
            this.SplitContainer_Frame.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Frame)).EndInit();
            this.SplitContainer_Frame.ResumeLayout(false);
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.SplitContainer_Win.Panel1.ResumeLayout(false);
            this.SplitContainer_Win.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Win)).EndInit();
            this.SplitContainer_Win.ResumeLayout(false);
            this.TabControl_Index.ResumeLayout(false);
            this.TabControl_Deal.ResumeLayout(false);
            this.TabControl_Stock.ResumeLayout(false);
            this.StatusStrip_Index.ResumeLayout(false);
            this.StatusStrip_Index.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer_Frame;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.StatusStrip StatusStrip_Index;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripLabel_DateTime;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripLabel_Time;
        private System.Windows.Forms.ToolStripSplitButton ToolStripButton_Info;
        private System.Windows.Forms.SplitContainer SplitContainer_Win;
        private System.Windows.Forms.TabControl TabControl_Index;
        private System.Windows.Forms.TabPage TabPage_Market;
        private System.Windows.Forms.TabPage TabPage_Stock;
        private System.Windows.Forms.TabPage TabPage_News;
        private System.Windows.Forms.TabControl TabControl_Stock;
        private System.Windows.Forms.TabPage TabPage_StockDetail;
        private System.Windows.Forms.TabPage TabPage_Reserve;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar_Time;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripLabel_Reserve;
        private System.Windows.Forms.ToolStripSplitButton ToolStripButton_Trade;
        private System.Windows.Forms.TabControl TabControl_Deal;
        private System.Windows.Forms.TabPage TabPage_Deal;
        private System.Windows.Forms.TabPage TabPage_History;
    }
}

