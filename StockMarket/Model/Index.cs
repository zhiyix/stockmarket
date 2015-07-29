using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.Model
{
    public class IndexType
    {
        public int Showapi_Res_Code { get; set; }

        public string Showapi_Res_Error { get; set; }

        public IndexBody Showapi_Res_Body { get; set; }

        public List<IndexInfo> getIndexList()
        {
            return Showapi_Res_Body.IndexList;
        }
    }

    public class IndexBody
    {
        public List<IndexInfo> IndexList { get; set; }

        public int Ret_Code { get; set; }
    }

    public class IndexInfo
    {
        public string Code { get; set; }

        public double MaxPrice { get; set; }

        public double MinPrice { get; set; }

        public string Name { get; set; }

        public double NowPrice { get; set; }

        public DateTime Time { get; set; }

        public double TodayOpenPrice { get; set; }

        public double TradeAmount { get; set; }

        public long TradeNum { get; set; }

        public double YestodayClosePrice { get; set; }
    }
}
