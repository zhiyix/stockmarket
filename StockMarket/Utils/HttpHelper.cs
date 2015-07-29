using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace StockMarket.Utils
{
    public class HttpHelper
    {
        public Encoding Encoding { get; set; }

        public string GetHtml(string url)
        {
            string responseStr = null;
            HttpWebRequest webRequest = null;
            HttpWebResponse webResponse = null;
            try
            {
                webRequest = (HttpWebRequest)WebRequest.Create(url);
                //webRequest.Method = "POST";
                webRequest.Timeout = 10000;
                //httpWebRequest.ContentType = "text/html; charset=gb2312";

                webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch { }
            finally {
                if (webResponse != null)
                {
                    //获得网络响应流
                    using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding("GB2312")))
                    {
                        responseStr = responseReader.ReadToEnd();//获得返回流中的内容
                    }
                    webResponse.Close();//关闭web响应流
                }
            }
            return responseStr;
        }
    }
}
