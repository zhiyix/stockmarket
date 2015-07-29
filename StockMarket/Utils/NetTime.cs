using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace StockMarket.Utils
{
    /// <summary>  
    /// 网络时间  
    /// </summary>  
    public class NetTime
    {
        private static bool debug = false;
        private static String url = @"http://shijian.duoshitong.com/time.php";

        /// <summary>  
        /// 获取标准北京时间，读取http://www.beijing-time.org/time.asp  
        /// </summary>  
        /// <returns>返回网络时间</returns>  
        public static DateTime GetBeijingTime()
        {
            DateTime dt;
            WebRequest webRequest = null;
            WebResponse webResponse = null;
            try
            {
                webRequest = WebRequest.Create(url);
                //httpWebRequest.Method = "POST";
                //httpWebRequest.Timeout = 50000;
                //httpWebRequest.ContentType = "text/html; charset=gb2312";

                webResponse = webRequest.GetResponse();
                
                string html = string.Empty;
                using (Stream stream = webResponse.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("GB2312")))
                    {
                        html = sr.ReadToEnd();
                    }
                }
                // For every encoding, get the property values.
                foreach (EncodingInfo ei in Encoding.GetEncodings())
                {
                    Encoding e = ei.GetEncoding();
                    if (ei.Name.Equals("GB2312", StringComparison.OrdinalIgnoreCase))
                    {
                        string result = Transfer.TransferEncoding(e, Encoding.UTF8, html);//欢迎来到转码世界！
                        Console.WriteLine("TransferEncoding 结果：{0}", result);
                    }
                    if (debug)
                    {
                        Console.Write("{0,-6} {1,-25} ", ei.CodePage, ei.Name);
                        Console.Write("{0,-8} {1,-8} ", e.IsBrowserDisplay, e.IsBrowserSave);
                        Console.Write("{0,-8} {1,-8} ", e.IsMailNewsDisplay, e.IsMailNewsSave);
                        Console.WriteLine("{0,-8} {1,-8} ", e.IsSingleByte, e.IsReadOnly);
                    }
                }

                string[] tempArray = html.Split(';');
                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = tempArray[i].Replace("\r\n", "");
                }

                string year = tempArray[1].Split('=')[1];
                string month = tempArray[2].Split('=')[1];
                string day = tempArray[3].Split('=')[1];
                string hour = tempArray[5].Split('=')[1];
                string minite = tempArray[6].Split('=')[1];
                string second = tempArray[7].Split('=')[1];

                dt = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + minite + ":" + second);
            }
            catch (WebException)
            {
                return DateTime.Parse("2011-1-1");
            }
            catch (Exception)
            {
                return DateTime.Parse("2011-1-1");
            }
            finally
            {
                if (webResponse != null)
                    webResponse.Close();
                if (webRequest != null)
                    webRequest.Abort();
            }
            return dt;
        }
        
        /// <summary> 
        /// 获取中国国家授时中心网络服务器时间发布的当前时间 
        /// </summary> 
        /// <returns></returns> 
        public static DateTime GetChineseDateTime()
        {
            DateTime res = DateTime.MinValue;
            try
            {
                string url = "http://www.time.ac.cn/stime.asp";
                HttpHelper helper = new HttpHelper();
                helper.Encoding = Encoding.Default;
                string html = helper.GetHtml(url);
                string patDt = @"/d{4}年/d{1,2}月/d{1,2}日";
                string patHr = @"hrs/s+=/s+/d{1,2}";
                string patMn = @"min/s+=/s+/d{1,2}";
                string patSc = @"sec/s+=/s+/d{1,2}";
                Regex regDt = new Regex(patDt);
                Regex regHr = new Regex(patHr);
                Regex regMn = new Regex(patMn);
                Regex regSc = new Regex(patSc);
                res = DateTime.Parse(regDt.Match(html).Value);
                int hr = GetInt(regHr.Match(html).Value, false);
                int mn = GetInt(regMn.Match(html).Value, false);
                int sc = GetInt(regSc.Match(html).Value, false);
                res = res.AddHours(hr).AddMinutes(mn).AddSeconds(sc);
            }
            catch { }
            return res;
        } 
        
        /// <summary> 
        /// 从指定的字符串中获取整数 
        /// </summary> 
        /// <param name="origin">原始的字符串</param> 
        /// <param name="fullMatch">是否完全匹配，若为false，则返回字符串中的第一个整数数字</param> 
        /// <returns>整数数字</returns> 
        private static int GetInt(string origin, bool fullMatch)
        {
            if (string.IsNullOrEmpty(origin))
            {
                return 0;
            }
            origin = origin.Trim();
            if (!fullMatch)
            {
                string pat = @"-?/d+";
                Regex reg = new Regex(pat);
                origin = reg.Match(origin.Trim()).Value;
            }
            int res = 0;
            int.TryParse(origin, out res);
            return res;
        }
    }
}
