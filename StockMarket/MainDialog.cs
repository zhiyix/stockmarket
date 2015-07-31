using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Configuration;
//<!
using StockMarket.Model;
using StockMarket.UI;
using StockMarket.Utils;
using StockMarket.Handle;
using com.show.api;
using StockMarket.SNTP;

namespace StockMarket
{
    public partial class MainDialog : Form
    {
        private bool debug = true;

        #region CONFIG
        private static String StockFileName = "stock.config";
        private UserProperties m_StockConfigs = new UserProperties(StockFileName);
        private static String UserCfgFileName = "setting.config";
        private UserProperties m_SettingConfigs = new UserProperties(UserCfgFileName);
        private static String NewsCfgFileName = "news.config";
        private UserProperties m_NewsConfigs = new UserProperties(NewsCfgFileName);
        #endregion

        #region UI
        private NewsPanel m_NewsPanel;
        private DealPanel m_DealPanel;
        private IndexPanel m_IndexPanel;
        private StockPanel m_StockPanel;
        private StockDetailView m_StockList;
        private Timer m_UpdateTimer = new Timer();
        private Timer m_SecondTimer = new Timer();
        private HandleShowApi m_HandleShowApi = new HandleShowApi();
        #endregion

        #region DATA
        private List<SmpStock> lst_Stocks = new List<SmpStock>();
        private List<Links> lst_News = new List<Links>();
        #endregion

        #region 初始化函数
        public MainDialog()
        {
            InitializeComponent();

            lst_Stocks.Clear();

            m_StockPanel = new StockPanel();
            m_StockPanel.StockChanged += new EventHandler<StockChangedEventArgs>(StockPanel_StockChanged_EventHandler);
            m_StockPanel.StockChecked += new EventHandler<StockChangedEventArgs>(StockPanel_StockChecked_EventHandler);
            TabPage_Stock.Controls.Add(m_StockPanel);

            m_IndexPanel = new IndexPanel();
            m_IndexPanel.IndexItemChanged += new EventHandler<IndexEventArgs>(IndexPanel_IndexItemChanged_EventHandler);
            TabPage_Market.Controls.Add(m_IndexPanel);

            m_StockList = new StockDetailView("");
            TabPage_StockDetail.Controls.Add(m_StockList);

            m_DealPanel = new DealPanel();
            TabPage_Deal.Controls.Add(m_DealPanel);
        }
        #endregion

        #region 消息响应处理函数
        private void MainDialog_Load(object sender, EventArgs e)
        {
            DialogLogin loginDlg = new DialogLogin();
            loginDlg.SettingConfigs = m_SettingConfigs;

            if (loginDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                Environment.Exit(0);
            }
            this.Text = getCaption(loginDlg.apiSection.ApiElement.AppID);
            if (m_StockConfigs.load())
            {
                foreach (KeyValuePair<string, string> kvce in m_StockConfigs.appConfigs)
                {
                    SmpStock stock = new SmpStock(kvce.Key, kvce.Value);
                    stock.Checked = true;
                    lst_Stocks.Add(stock);
                }
            }
            if (m_NewsConfigs.load())
            {
                foreach (KeyValuePair<string, string> kvce in m_NewsConfigs.appConfigs)
                {
                    Links theNews = new Links(kvce.Key, kvce.Value);
                    lst_News.Add(theNews);
                }
            }
            m_NewsPanel = new NewsPanel(lst_News);
            TabPage_News.Controls.Add(m_NewsPanel);

            m_StockPanel.InitData(lst_Stocks);

            m_UpdateTimer.Interval = 1000;
            m_UpdateTimer.Enabled = true;
            m_UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick_EventHandler);
            m_UpdateTimer.Start();

            m_SecondTimer.Interval = 1000;
            m_SecondTimer.Enabled = true;
            m_SecondTimer.Tick += new EventHandler(SecondTimer_Tick_EventHandler);
            m_SecondTimer.Start();

            CfgManager.ReadConnectionStrings();
            CfgManager.MapMachineConfiguration();
            SNTPTime.calibrationTime();

            m_HandleShowApi.BgWorkerCompleted += new EventHandler<BgWorkerEventArgs>(HandleShowApi_BgWorkerCompleted);
        }

        private void MainDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_StockConfigs.clear();
            foreach (SmpStock stock in lst_Stocks)
            {
                if (stock.Checked)
                    m_StockConfigs.setProperty(stock.Code, stock.Name);
            }
            m_StockConfigs.store();
            CfgManager.MapExeConfiguration();
        }

        private void TabWindow_SelectedIndexChanged_EventHandler(object sender, EventArgs e)
        {
            if (sender is TabControl)
            {
                TabControl tabCtrl = (TabControl)sender;
                //updateTabControl((TabControl)tabCtrl);
            }
        }

        void IndexPanel_IndexItemChanged_EventHandler(object sender, IndexEventArgs e)
        {
            if (debug)
                Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
        }

        void StockPanel_StockChanged_EventHandler(object sender, StockChangedEventArgs e)
        {
            StockPanel_Update(e.stock);
        }

        void StockPanel_StockChecked_EventHandler(object sender, StockChangedEventArgs e)
        {
            StockList_Update(e.stock);
        }

        void UpdateTimer_Tick_EventHandler(object sender, EventArgs e)
        {
            Timer tim = (Timer)sender;
            tim.Stop();
            {
                m_HandleShowApi.Start(lst_Stocks);
            }
            //tim.Start();
        }

        void SecondTimer_Tick_EventHandler(object sender, EventArgs e)
        {
            TimeSpan curr = SNTPTime.TrueDateTime.TimeOfDay;
            if (curr < new TimeSpan(9, 15, 0))
            {
                ToolStripProgressBar_Time.Value = ToolStripProgressBar_Time.Minimum;
            }
            else if (curr < new TimeSpan(9, 30, 0))
            {
                TimeSpan ts = curr - new TimeSpan(9, 15, 0);
                ToolStripProgressBar_Time.Value = (Int16)ts.TotalMinutes;
            }
            else if (curr < new TimeSpan(11, 30, 0))
            {
                TimeSpan ts = curr - new TimeSpan(9, 15, 0);
                ToolStripProgressBar_Time.Value = (Int16)ts.TotalMinutes;
            }
            else if (curr < new TimeSpan(13, 0, 0))
            {
                ToolStripProgressBar_Time.Value = 135;
            }
            else if (curr < new TimeSpan(15, 0, 0))
            {
                TimeSpan ts = curr - new TimeSpan(13, 0, 0);
                ToolStripProgressBar_Time.Value = 135 + (Int16)ts.TotalMinutes;
            }
            else
            {
                ToolStripProgressBar_Time.Value = ToolStripProgressBar_Time.Maximum;
            }
        }

        void HandleShowApi_BgWorkerCompleted(object sender, BgWorkerEventArgs e)
        {
            Int16 nCount = 0;
            if (e.index != null)
            {
                IndexPanel_Update(e.index);
            }
            if (true) 
            {
                for (System.Collections.IEnumerator ie = e.respones.GetEnumerator(); ie.MoveNext(); )
                {
                    if (ie.Current != null)
                    {
                        nCount ++;
                    }
                }
                m_StockList.UpdateStockData(e.respones);
                m_DealPanel.UpdateStockData(e.respones);
            }
            String spend_time = e.timespan.ToString("N0", CultureInfo.InvariantCulture);
            Console.WriteLine("[INFO] Update [" + nCount + "] spend " + spend_time);
            ToolStripLabel_DateTime.Text = SNTPTime.TrueDateTime.ToString("G", DateTimeFormatInfo.InvariantInfo);
            ToolStripLabel_Time.Text = spend_time;
            m_UpdateTimer.Start();
        }

        private void ToolStripButton_Info_Click(object sender, EventArgs e)
        {
            SplitContainer_Frame.Panel2Collapsed = !SplitContainer_Frame.Panel2Collapsed;
        }
        private void ToolStripButton_Trade_Click(object sender, EventArgs e)
        {
            SplitContainer_Main.Panel2Collapsed = !SplitContainer_Main.Panel2Collapsed;
        }
        #endregion

        #region UI界面数据更新函数
        private void IndexPanel_Update(IndexType index)
        {
            if (index != null)
            {
                m_IndexPanel.Model = index;
                m_IndexPanel.UpdateData();
            }
        }

        private void StockPanel_Update(SmpStock stock)
        {
            if (stock.Code.Length > 0)
            {
                if (!lst_Stocks.Contains(stock))
                {
                    if (ShowAPI.getStockByCode(ref stock))
                    {
                        lst_Stocks.Add(stock);
                        m_StockPanel.AddStockData(stock);
                    }
                }
            }
            else if (stock.Name.Length > 0)
            {
                do 
                {
                    List<CodeInfo> list = ShowAPI.getStockByName(ref stock);
                    if (list != null && list.Count > 0)
                    {
                        DialogStockList infoDlg = new DialogStockList();
                        infoDlg.InitData(stock.Name, list);
                        infoDlg.StockChecked += new EventHandler<StockChangedEventArgs>(StockPanel_StockChanged_EventHandler);
                        infoDlg.ShowDialog();
                        infoDlg.StockChecked -= new EventHandler<StockChangedEventArgs>(StockPanel_StockChanged_EventHandler);
                        break;
                    }
                    else
                    {
                        DialogResult box = System.Windows.Forms.MessageBox.Show("操作不存在的代码.", "错误",
                            System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore,
                            System.Windows.Forms.MessageBoxIcon.Warning);
                        if (box == System.Windows.Forms.DialogResult.Abort ||
                            box == System.Windows.Forms.DialogResult.Ignore)
                        {
                            break;
                        }
                    }
                } while (true);
            }
        }

        private void StockList_Update(SmpStock stock)
        {
            if (lst_Stocks.Contains(stock))
            {
                int idx = lst_Stocks.IndexOf(stock);
                if (idx >= 0 && idx < lst_Stocks.Count)
                {
                    lst_Stocks[idx].Checked = stock.Checked;
                }
            }
        }

        private String getCaption(String appid)
        {
            String caption = "StockMarket Demo V";
            AssemblyInfoHelper asm = new AssemblyInfoHelper(this.GetType());
            string ver = asm.VersionInfo.Version;
            char[] separators = { '.' };
            int mv = Int32.Parse(ver.Split(separators)[2]);
            if (mv % 2 == 0)
            {
                caption += ver + " Release";
            }
            else
            {
                caption += ver + " Beta";
            }
            caption += " Author:wazhiyi Email:wazhiyi@qq.com 3Q:ShowApi ID: ";
            caption += appid;
            return caption;
        }
        #endregion

    }
}
