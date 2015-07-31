using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.Model
{
    public class Asset
    {
        // 初始总资产
        private double _init_asset = 60937.96F;
        // 剩余额度
        private double _avail_quota = 2120.99F;

        private double _total;

        private double _value;
        // Close Asset
        private double _close_day_asset = 47041.99F;

        // 总市值
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        // 可用额度
        public double Quota
        {
            get { return _avail_quota; }
            set { _avail_quota = value; }
        }
        
        // 上个交易日总资产
        public double CloseDayAsset
        {
            get { return _close_day_asset; }
            set { _close_day_asset = value; }
        }

        // 总资产
        public double NowAsset
        {
            get
            {
                return _value + _avail_quota;
            }
        }

        // 总盈亏
        public double NowProfit
        {
            get
            {
                return NowAsset - _init_asset;
            }
        }

        // 当日盈亏
        public double DayProfit
        {
            get
            {
                return NowAsset - CloseDayAsset;
            }
        }

        public Asset()
        {
        }

        public Asset(double init, double quota, double day_asset)
        {
            _init_asset = init;
            _avail_quota = quota;
            _close_day_asset = day_asset;
        }
    }
}
