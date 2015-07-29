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
    public class NewsPanel : CommonPanel
    {
        public NewsPanel(List<Links> news)
        {
            StockIndexTable.ColumnCount = 1;

            foreach (Links title in news)
            {
                if (title.Title != null && title.Title.Length > 0)
                {
                    HyperlinkLabel label = new HyperlinkLabel(title);
                    this.Font = new Font("宋体", 10, this.Font.Style);
                    label.Dock = DockStyle.Fill;
                    label.LinkClicked += new LinkLabelLinkClickedEventHandler(this.HyperlinkLabel_LinkClicked);
                    StockIndexTable.Controls.Add(label);
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
