using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
//<!
using com.show.api;

namespace StockMarket.Model
{
    public class StockService
    {
        private bool debug = false;

        private String[] stk_name = new String[] {
            "指数名称",
            "指数编码",
            "今日开盘价",
            "昨日收盘价",
            "当前价",
            "最高价",
            "最低价",
            "成交量",
            "成交金额",
            "刷新时间",
        };

        #region 属性
        private StockType stk_model;
        public StockType StockEntry { get { return stk_model; } set { stk_model = value; } }
        #endregion

        public StockService()
        {
        }

        public bool deserialize(String code)
        {
            String json = new ShowApiRequest(ShowAPI.URL[1], ShowAPI.APPID, ShowAPI.SECRET)
            .addTextPara("code", code)
            .post();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(p);

            var obj = serializer.Deserialize<StockType>(json);

            if (obj.Showapi_Res_Code == 0)
            {
                if (obj.Showapi_Res_Body.Ret_Code == 0)
                {
                    if (debug)
                        Console.WriteLine("[INFO] Code: " + obj.Showapi_Res_Code + " <OK>.");
                    //Console.WriteLine(ReferenceEquals(p,p1));

                    stk_model = obj;
                    stk_model.Code = code;
                    return true;
                }
                else {
                    System.Windows.Forms.MessageBox.Show("操作不存在的代码.", "错误", 
                        System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore,
                        System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            else
            {
                Console.Error.WriteLine("[ERR] Code: " + obj.Showapi_Res_Code + " => Error: " + obj.Showapi_Res_Error + ".");
            }
            stk_model = new StockType();
            stk_model.Code = code;
            return false;
        }
    }
}
