using System.Windows.Forms;

namespace StockMarket.UI
{
    partial class CommonPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TableView = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // TableView
            // 
            this.TableView.ColumnCount = 1;
            //this.TableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //this.TableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableView.Location = new System.Drawing.Point(0, 0);
            this.TableView.Name = "TableView";
            this.TableView.RowCount = 1;
            //this.TableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //this.TableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableView.Size = new System.Drawing.Size(284, 262);
            this.TableView.TabIndex = 0;
            this.TableView.AutoScroll = true;
            this.TableView.RowStyles.Clear();

            // 
            // StockIndexPanel
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.TableView);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockIndexPanel";
            this.Text = "StockIndexPanel";
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TableView;
    }
}