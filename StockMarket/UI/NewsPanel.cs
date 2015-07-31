using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
//<!
using StockMarket.Utils;

namespace StockMarket.UI
{
    public class NewsPanel : TableViewPanel
    {
        private static Int16 FONT_SIZE = 10;

        public NewsPanel(List<Links> news)
        {
            if (news.Count == 0)
                return;
            this.RowCount = news.Count + 1;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            for (int i = 0; i <= 20; i++)
            {
                Single percent = FONT_SIZE + 8;
                this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, percent));
            }

            //foreach (Links title in news)
            for (int i = 0; i <= 20; i++)
            {
                Links title = news[0];
                if (title.Title != null && title.Title.Length > 0)
                {
                    HyperlinkLabel label = new HyperlinkLabel(title);
                    label.TextAlign = ContentAlignment.BottomLeft;
                    label.Font = new Font("宋体", FONT_SIZE, this.Font.Style);
                    label.Padding = new System.Windows.Forms.Padding(1, 3, 3, 1);
                    label.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                    label.LinkClicked += new LinkLabelLinkClickedEventHandler(this.HyperlinkLabel_LinkClicked);
                    this.Controls.Add(label);
                }
            }
        }

        private void HyperlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Determine which link was clicked within the LinkLabel.
            //this.linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;

            // Display the appropriate link based on the value of the 
            // LinkData property of the Link object.
            Uri target = e.Link.LinkData as Uri;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            try
            {
                Console.WriteLine(target.IsAbsoluteUri);
                if (target.AbsoluteUri.StartsWith("file"))
                {
                    System.Diagnostics.Process.Start(target.AbsolutePath);
                }
                else
                {
                    System.Diagnostics.Process.Start(target.AbsoluteUri);
                }
            }
            catch
            {
                //MessageBox.Show("Item clicked: " + target);
            }
        }
    }
}
