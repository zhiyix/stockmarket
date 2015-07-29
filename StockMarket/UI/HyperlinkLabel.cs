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
    public class HyperlinkLabel : LinkLabel
    {
        public HyperlinkLabel(Links news)
        {
            this.AutoSize = true;

            // Configure the appearance. 
            // Set the DisabledLinkColor so that a disabled link will show up against the form's background.
            this.DisabledLinkColor = System.Drawing.Color.Red;
            this.VisitedLinkColor = System.Drawing.Color.Blue;
            this.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkColor = System.Drawing.Color.Navy;

            // Add an event handler to do something when the links are clicked.
            //this.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);

            // Identify that the first link is visited already.
            this.Links[0].Visited = true;

            // Set the Text property to a string.
            this.Text = news.Title;

            this.Links[0].LinkData = news.URL;
            //  The second link is disabled and will appear as red.
            this.Links[0].Enabled = true;
        }
    }

    public class Links
    {
        public String Title { get; set; }
        public Uri URL { get; set; }

        public Links(string title, string url)
        {
            Title = title;
            try
            {
                URL = new Uri(url);
            }
            catch
            {
                string filename = FileManager.getApplicationInstallationPath() + "/" + url;
                filename = filename.Replace("//", "/");
                if (File.Exists(filename))
                {
                    URL = new Uri(filename);
                }
                else
                {
                    URL = null;
                }
            }
        }
    }
}
