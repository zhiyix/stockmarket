using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Threading;
using System.Globalization;
//<!
using com.show.api;
using StockMarket.Model;

namespace StockMarket.Handle
{
    public class HandleShowApi
    {
        private static bool debug = false;
        private const int SLEEP_INTERVAL = 100;
        private bool bgWorkedError = false;

        #region UI
        public BackgroundWorker bgWorker = new BackgroundWorker();
        public event EventHandler<BgWorkerEventArgs> BgWorkerCompleted;
        #endregion

        #region DATA
        private BgWorkerEventArgs m_EventArgs = new BgWorkerEventArgs();
        #endregion

        #region INIT
        public HandleShowApi()
        {
            //Initialise background worker thread
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        }
        #endregion

        #region Operation
        //Start serial connection
        public bool Start(List<SmpStock> lst_StockSelectedArray)
        {
            if (bgWorker.IsBusy)
            {
                return false;
            }
            ApiState sas = new ApiState();
            sas.Codes = new List<String>();
            sas.Codes.Clear();
            foreach (SmpStock stock in lst_StockSelectedArray)
            {
                if (stock.Checked)
                    sas.Codes.Add(stock.Code);
            }
            if (sas.Codes.Count == 0)
            {
                sas.Mode = (Int16)ApiMode.MARKET;
            }
            else
            {
                sas.Mode = (Int16)ApiMode.STOCK;
            }
            //Pass through serial port to background worker
            Hashtable workerOptions = new Hashtable();
            workerOptions.Add("mode", sas.Mode);
            workerOptions.Add("code", sas.Codes);
            workerOptions.Add("data", "");

            //Init background worker
            bgWorker.RunWorkerAsync(workerOptions);

            if (debug)
                Console.WriteLine("[INFO] 程序已经初始化");

            return true;
        }

        //Stop serial connection
        public void Stop()
        {
            //Cancel background worker
            bgWorker.CancelAsync();

            //Update button status
            if (debug)
                Console.WriteLine("[INFO] 正在取消...");
        }
        #endregion

        #region EVENT
        //Do work in background
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ApiState sas = new ApiState();
            double totalTime = 0;
            List<StockType> stringResults = new List<StockType>();

            //Clear any errors
            bgWorkedError = false;

            //Report process started
            bgWorker.ReportProgress(0, "程序已经启动");
            if (debug)
                Console.WriteLine("[INFO] 程序已经启动");

            //Read out passed in options
            Hashtable workeroptions;
            workeroptions = (Hashtable)e.Argument;
            bgWorker.ReportProgress(11, (short)workeroptions["mode"]); // "模式: "
            bgWorker.ReportProgress(12, (List<String>)workeroptions["code"]); // "参数: "
            bgWorker.ReportProgress(13, (string)workeroptions["data"]); // "数据:" 

            sas.Mode = (Int16)workeroptions["mode"];
            sas.Codes = (List<String>)workeroptions["code"];
            try
            {
                do
                {
                    IndexType responeBuffer = null;

                    IndexService indexService = new IndexService();
                    indexService.deserialize();
                    responeBuffer = indexService.IndexEntry;
                    bgWorker.ReportProgress(50, (IndexType)responeBuffer);
                } while (false);

                foreach (String code in sas.Codes)
                {
                    StockType responeBuffer = null;
                    StockService stockService = new StockService();
                    if (debug)
                        Console.WriteLine("[INFO] 数据请求");
                    DateTime dt_start = DateTime.Now;
                    {
                        if (!stockService.deserialize(code))
                        {
                            Console.WriteLine("￥");
                        }
                        responeBuffer = stockService.StockEntry;
                    }
                    DateTime dt_stop = DateTime.Now;
                    stringResults.Add(responeBuffer);
                    TimeSpan interval = dt_stop - dt_start;

                    totalTime += interval.TotalMilliseconds;

                    if (debug)
                        Console.WriteLine("[INFO] 接收数据完成");

                    //If not awaiting cancellation
                    if (!bgWorker.CancellationPending)
                    {
                        //Wait 100 ms before checking for more data
                        Thread.Sleep(SLEEP_INTERVAL); 
                    }
                    else
                    {
                        break;
                    }
                }
                Thread.Sleep(SLEEP_INTERVAL);
                bgWorker.ReportProgress(99, totalTime);
                bgWorker.ReportProgress(100, stringResults);
            }
            catch (Exception ex)
            {
                //Report error message
                bgWorker.ReportProgress(0, ex.Message);

                if (debug)
                    Console.WriteLine("[ERR] 程序异常");

                //bgWorkedError = true;
                return;
            }
        }

        //Background work completed
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Set button back to connect
            //btnConnect.Text = "连接服务器";

            //Clear process bar status
            //toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            //toolStripProgressBar.Value = 0;

            /*
            if (e.Cancelled)
            {

            }
            else if (e.Error != null)
            {

            }
            else if (bgWorkedError == true) {

            }
            else
            {
                //finished with no errors
            }
            */
            if (debug)
                Console.WriteLine("[INFO] RunWorkerCompleted");
            OnBgWorkerCompleted(m_EventArgs);
        }

        //Background work process change
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                m_EventArgs = new BgWorkerEventArgs();
            }
            else if (e.ProgressPercentage == 11)
            {
                m_EventArgs.mode = (Int16)(e.UserState);
            }
            else if (e.ProgressPercentage == 12)
            {
                m_EventArgs.codes = (List<String>)e.UserState;
            }
            else if (e.ProgressPercentage == 50)
            {
                m_EventArgs.index = (IndexType)e.UserState;
            }
            else if (e.ProgressPercentage == 99)
            {
                m_EventArgs.timespan = (double)(e.UserState);
            }
            else if (e.ProgressPercentage == 100)
            {
                m_EventArgs.respones = (List<StockType>)e.UserState;
            }

            //Add status message to log
            //statusLogAdd("[MSG] " + e.UserState.ToString());
        }

        protected virtual void OnBgWorkerCompleted(BgWorkerEventArgs e)
        {
            EventHandler<BgWorkerEventArgs> handler = BgWorkerCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }

    public class ApiState
    {
        public Int16 Mode { get; set; }

        public List<String> Codes { get; set; }
    }

    public enum ApiMode { 
        MARKET = 0,
        STOCK = 1,
    }
    
    // FireEventArgs: a custom event inherited from EventArgs.
    public class BgWorkerEventArgs : EventArgs
    {
        public BgWorkerEventArgs()
        {
            this.codes = new List<String>();
            this.respones = new List<StockType>();
            this.index = null;
            this.timespan = 0;
            this.mode = 0;

            this.codes.Clear();
            this.respones.Clear();
        }

        // The fire event will have two pieces of information-- 
        // 1) Where the fire is, and 
        // 2) how "ferocious" it is.  

        public List<String> codes;
        public List<StockType> respones;
        public IndexType index;
        public double timespan;
        public Int16 mode;

    }    //end of class FireEventArgs
}
