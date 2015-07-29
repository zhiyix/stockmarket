using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace StockMarket.Utils
{
    [StructLayout(LayoutKind.Sequential)]
    class NTPData
    {
        byte header = 0;
        byte Stratum = 1;           //系统时钟的层数，取值范围为1～16，它定义了时钟的准确度
        byte Poll = 1;              //轮询时间，即两个连续NTP报文之间的时间间隔
        byte Precision = 1;         //系统时钟的精度
        BigEndianUInt32 rootDelay;
        BigEndianUInt32 referenceIdentifier;
        BigEndianUInt32 ReferenceIdentifier;

        public NtpTime ReferenceTimestamp { get; private set; }
        public NtpTime OriginateTimestamp { get; private set; }
        public NtpTime ReceiveTimestamp { get; private set; }
        public NtpTime TransmitTimestamp { get; private set; }

        public NTPData()
        {
            this.header = GetHeader();
        }

        byte GetHeader()
        {
            var LI = "00";
            var VN = "011";         //NTP的版本号为3
            var Mode = "011";       //客户模式

            return Convert.ToByte(LI + VN + Mode, 2);
        }

        public static NTPData Test(IPAddress ntpServer)
        {
            var data = MarshalExtend.GetData(new NTPData());

            var udp = new System.Net.Sockets.UdpClient();
            udp.Send(data, data.Length, new IPEndPoint(ntpServer, 123));

            var ep = new IPEndPoint(IPAddress.Any, 0);
            var replyData = udp.Receive(ref ep);

            return MarshalExtend.GetStruct<NTPData>(replyData, replyData.Length);
        }
    }
}
