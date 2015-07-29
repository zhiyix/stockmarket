using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.Script.Serialization;
//<!
using com.show.api;

namespace StockMarket.Model
{
    public class IndexService
    {
        private bool debug = false;
        
        #region 属性
        private IndexType idx_model;
        public IndexType IndexEntry { get { return idx_model; } set { idx_model = value; } }
        #endregion

        public IndexService()
        {
        }

        public bool deserialize()
        {
            String json = new ShowApiRequest(ShowAPI.URL[0], ShowAPI.APPID, ShowAPI.SECRET)
            .post();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(p);

            var obj = serializer.Deserialize<IndexType>(json);

            if (obj.Showapi_Res_Code == 0)
            {
                if (debug)
                    Console.WriteLine("[INFO] Code: " + obj.Showapi_Res_Code + " <OK>.");
                //Console.WriteLine(ReferenceEquals(p,p1));

                IndexEntry = obj;
                return true;
            }
            else
            {
                Console.WriteLine("[ERR] Code: " + obj.Showapi_Res_Code + " => Error: " + obj.Showapi_Res_Error + ".");

                IndexEntry = null;
                return false;
            }
        }
    }
}
