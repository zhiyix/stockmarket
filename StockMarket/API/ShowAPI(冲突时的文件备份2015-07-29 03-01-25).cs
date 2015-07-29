using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.show.api;
using System.Web.Script.Serialization;
using StockMarket.Model;

namespace com.show.api
{
    class ShowAPI
    {
        private static bool debug = false;

        #region DATA
        public static String[] URL = 
        {
            "http://route.showapi.com/131-45",
            "http://route.showapi.com/131-44",
        };
        public static String APPID = "4262";
        public static String SECRET = "dfdbf54261cd467ab337c4ed8b944e7e";
        #endregion

        private static StockType getStockMarket(string code)
        {
            String json = new ShowApiRequest(URL[1], APPID, SECRET)
            .addTextPara("code", code)
            .post();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(p);

            var obj = serializer.Deserialize<StockType>(json);

            if (obj.Showapi_Res_Code == 0)
            {
                if (debug)
                    Console.WriteLine("[INFO] Code: " + obj.Showapi_Res_Code + " <OK>.");
                //Console.WriteLine(ReferenceEquals(p,p1));
                
                obj.Code = code;
                return obj;
            }
            else
            {
                Console.WriteLine("[ERR] Code: " + obj.Showapi_Res_Code + " => Error: " + obj.Showapi_Res_Error + ".");

                return null;
            }
        }

        public static bool getStockByCode(ref SmpStock stock)
        {
            StockType st = getStockMarket(stock.Code);
            if (st != null)
            {
                stock.Name = st.Name;
                return true;
            }
            return false;
        }
    }
}
