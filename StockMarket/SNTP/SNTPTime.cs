using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.SNTP
{
    public class SNTPTime
    {
        private static String[] NTP_SERVERS = 
        {
            "time.asia.apple.com",  // 0
            "ntp.sjtu.edu.cn",      // 1 上海交通大学网络中心NTP服务器地址
            "time-a.nist.gov",      // 2
            "time-b.nist.gov",      // 3
            "time.windows.com",     // 4
            "time.nist.gov",        // 5
            "time-nw.nist.gov",     // 6
            "130.149.17.21",        // 7
            "clock.via.net",        // 8
            "ntp.nasa.gov",         // 9
            "210.72.145.44",        // 10 中国国家授时中心服务器IP地址
        };
        private static int NTP_SERVER_NO = 3;// 0[OK]; 1[OK]; 2[OK]; 3[OK]; 7[WARN]; 
        private static bool debug = true;
        
        public static DateTime getChineseTime()
        {
            SNTPClient sc = new SNTPClient(NTP_SERVERS[NTP_SERVER_NO]);
            sc.Connect(false);
            if (debug)
                Console.WriteLine(sc);
            return DateTime.Now.AddMilliseconds(sc.LocalClockOffset);
        }

        public static bool calibrationTime()
        {
            StringBuilder sb = new StringBuilder();
            for (int idx = 0; idx <= NTP_SERVER_NO; idx++)
            {
                sb.Clear();
                SntpEntry = new SNTPClient(NTP_SERVERS[NTP_SERVER_NO]);
                try
                {
                    SntpEntry.Connect(false, 5000);
                }
                catch
                {
                    Console.WriteLine("[ERR] Time acquisition failure.");
                    continue;
                }
                if (debug)
                {
                    sb.Append(SntpEntry.ToString());
                }
                sb.Append(TrueDateTime.ToString());
                Console.WriteLine(sb.ToString());
                return true;
            }
            return false;
        }

        public static SNTPClient SntpEntry { get; set; }

        public static DateTime TrueDateTime
        {
            get
            {
                return DateTime.Now.AddMilliseconds(SntpEntry.LocalClockOffset);
            }
        }
    }
}
