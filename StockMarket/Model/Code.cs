using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace StockMarket.Model
{
    public class CodeType
    {
        public int Showapi_Res_Code { get; set; }

        public string Showapi_Res_Error { get; set; }

        public CodeBody Showapi_Res_Body { get; set; }

        public int Count { get { return StockInfo.Count; } }

        public List<CodeInfo> StockInfo { get { return Showapi_Res_Body.List; } }
    }

    public class CodeBody
    {
        public List<CodeInfo> List { get; set; }

        public int Ret_Code { get; set; }
    }

    // [DataContract]
    public class CodeInfo
    {
        public string Code { get; set; }

        [DataMember(Name = "industry")]
        public string Industry { get; set; }

        public string Market { get; set; }

        public string Name { get; set; }

        // The JavaScriptSerializer ignores this field.
        // [IgnoreDataMember]
        // [ScriptIgnore]
        // public string Pinyin { get; set; }

        public string getMarket()
        {
            if (this.Market != null && this.Market.Length > 0)
            { 
                if (this.Market.Equals("sh", StringComparison.OrdinalIgnoreCase))
                {
                    if (Code.StartsWith("60"))
                    {
                        return "沪市A股";
                    }
                    else if (Code.StartsWith("900"))
                    {
                        return "沪市B股";
                    }
                }
                else if (this.Market.Equals("sz", StringComparison.OrdinalIgnoreCase))
                {
                    if (Code.StartsWith("000"))
                    {
                        return "深市A股";
                    }
                    else if (Code.StartsWith("200"))
                    {
                        return "深市B股";
                    }
                    else if (Code.StartsWith("002"))
                    {
                        return "中小板";
                    }
                    else if (Code.StartsWith("300"))
                    {
                        return "创业板";
                    }
                }
                return this.Market;
            }
            return null;
        }
    }
}
