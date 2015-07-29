using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.Model
{
    public class SmpStock
    {
        public SmpStock(string code, string name)
        {
            this.Code = code;
            this.Name = name;
            this.Checked = false;
        }
        public string Code { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj != null && obj is SmpStock)
            {
                SmpStock sstk = (SmpStock)obj;
                if (sstk.Code.Equals(this.Code))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class StockType
    {
        public int Showapi_Res_Code { get; set; }

        public string Showapi_Res_Error { get; set; }

        public StockBody Showapi_Res_Body { get; set; }

        public String Code { get { return _code; } set { _code = value; } }

        public String Name { get { return Showapi_Res_Body.StockMarket.Name; } }

        public SmpStock SimpleStock
        {
            get
            {
                return new SmpStock(Code, Name);
            }
        }

        public StockInfo getStockMarket()
        {
            return Showapi_Res_Body.StockMarket;
        }

        public void Copy(StockType stock)
        {
            this.Showapi_Res_Code = stock.Showapi_Res_Code;
            this.Showapi_Res_Error = stock.Showapi_Res_Error;
            this.Code = stock.Code;
            this.Showapi_Res_Body.IndexList = stock.Showapi_Res_Body.IndexList;
            this.Showapi_Res_Body.K_Pic = stock.Showapi_Res_Body.K_Pic;
            this.Showapi_Res_Body.Ret_Code = stock.Showapi_Res_Body.Ret_Code;
            this.Showapi_Res_Body.StockMarket = stock.Showapi_Res_Body.StockMarket;
        }

        public StockType()
        {
            Showapi_Res_Body = new StockBody();
        }

        private String _code = "";
    }

    public class StockBody
    {
        public List<IndexType> IndexList { get; set; }

        public StockPic K_Pic { get; set; }

        public int Ret_Code { get; set; }

        public StockInfo StockMarket { get; set; }

        public StockBody()
        {
            StockMarket = new StockInfo();
        }
    }

    public class StockInfo
    {
        public double Buy1_M { get; set; }

        public long Buy1_N { get; set; }

        public double Buy2_M { get; set; }

        public long Buy2_N { get; set; }

        public double Buy3_M { get; set; }

        public long Buy3_N { get; set; }

        public double Buy4_M { get; set; }

        public long Buy4_N { get; set; }

        public double Buy5_M { get; set; }

        public long Buy5_N { get; set; }

        public double ClosePrice { get; set; }

        public double CompetBuyPrice { get; set; }

        public double CompetSellPrice { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public double NowPrice { get; set; }

        public double OpenPrice { get; set; }

        public double Sell1_M { get; set; }

        public long Sell1_N { get; set; }

        public double Sell2_M { get; set; }

        public long Sell2_N { get; set; }

        public double Sell3_M { get; set; }

        public long Sell3_N { get; set; }

        public double Sell4_M { get; set; }

        public long Sell4_N { get; set; }

        public double Sell5_M { get; set; }

        public long Sell5_N { get; set; }

        public DateTime Time { get; set; }

        public double TodayMax { get; set; }

        public double TodayMin { get; set; }

        public double TradeAmount { get; set; }

        public long TradeNum { get; set; }

        public StockInfo()        
        {
            NowPrice = 0;
        }
    }

    public class StockPic
    {
        public string DayUrl { get; set; }

        public string MinUrl { get; set; }

        public string MonthUrl { get; set; }

        public string WeekUrl { get; set; }
    }
}
