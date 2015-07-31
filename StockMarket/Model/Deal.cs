using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket.Model
{
    public class Deal
    {
        private DealInfo[] test_DealArray = 
        {
            new DealInfo("600797", 800, 20.916, 0.155, new DateTime(2015, 7, 24)),
            new DealInfo("600487", 200, 44.296, 0.155, new DateTime(2015, 7, 24)),
            new DealInfo("603077", 300, 26.436, 0.155, new DateTime(2015, 7, 24)),
            new DealInfo("002636", 500, 32.604, 0.155, new DateTime(2015, 6, 24)),
            new DealInfo("603686", 100, 89.221, 0.155, new DateTime(2015, 7, 24)),
        };
        public String[] arr_DealDetailNames = 
        {
            "代码",
            "股票名称",
            "持仓量",
            "成本价",
            "市  价",
            " 市  值 ",
            "盈亏比（浮动盈亏）",
            "交易时间",
        };
        public List<DealInfo> m_DealList = new List<DealInfo>();

        public Deal()
        {
            m_DealList.AddRange(test_DealArray);
        }
    }

    public class DealInfo
    {
        private SmpStock _stock;

        private Int16 _amount;

        private bool _halt;

        private double _cost;

        private double _price;

        private double _tax;

        private DateTime _date;

        public DealInfo(string code, Int16 amount, double cost, double tax, DateTime date)
        {
            this._stock = new SmpStock(code, "");
            this._amount = amount;
            this._cost = cost;
            this._date = date;
            this._tax = tax;
            this._halt = false;
            this._price = 0;
        }

        public double FanalCost
        {
            get
            {
                return _amount * _cost;
            }
        }

        public double Value 
        {
            get
            {
                return _amount * _price;
            }
        }

        public double Profit
        {
            get
            {
                return Value - (Value * _tax / 100) - FanalCost;
            }
        }

        public SmpStock Stock { get { return _stock; } set { _stock = value; } }

        public Int16 Amount { get { return _amount; } set { _amount = value; } }

        public double Cost { get { return _cost; } set { _cost = value; } }

        public double Price { get { return _price; } set { _price = value; } }

        public double TaxRatio { get { return _tax; } set { _tax = value; } }

        public bool Halt { get { return _halt; } set { _halt = value; } }

        public DateTime Date { get { return _date; } set { _date = value; } }
    }
}
