using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace StockMarket.Utils
{
    [StructLayout(LayoutKind.Sequential)]
    class NtpTime
    {
        BigEndianUInt32 seconds;
        BigEndianUInt32 fraction;

        static readonly DateTime baseTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static implicit operator DateTime(NtpTime time)
        {
            /* rfc1305的ntp时间中，时间是用64bit来表示的，记录的是1900年后的秒数（utc格式）
             * 高32位是整数部分，低32位是小数部分 */

            var milliseconds = (int)(((double)time.fraction / uint.MaxValue) * 1000);
            return baseTime.AddSeconds(time.seconds).AddMilliseconds(milliseconds).ToLocalTime();
        }

        public override string ToString()
        {
            return ((DateTime)this).ToString("o");
        }
    }
}
