using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace StockMarket.Utils
{
    class NptClient
    {
        IPAddress ntpServer;
        public NptClient(IPAddress ntpServer)
        {
            this.ntpServer = ntpServer;
        }

        public DateTime GetServerTime()
        {
            var startTime = DateTime.Now;
            var ntpTime = NTPData.Test(ntpServer);
            var recvTime = DateTime.Now;

            var offset = ((ntpTime.ReceiveTimestamp - startTime) + (ntpTime.TransmitTimestamp - recvTime));
            offset = offset.Subtract(TimeSpan.FromSeconds(offset.TotalSeconds / 2));

            return recvTime + offset;
        }
    }
}
