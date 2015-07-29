using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace StockMarket.UI
{
    class ListViewColumnSorter: IComparer
    {
        private int ColumnToSort;// 指定按照哪个列排序
        private SortOrder OrderOfSort;// 指定排序的方式
        private CaseInsensitiveComparer ObjectCompare;// 声明CaseInsensitiveComparer类对象，
        public ListViewColumnSorter(int column)// 构造函数
        {
            ColumnToSort = column;// 默认按第一列排序
            OrderOfSort = SortOrder.Ascending;// 排序方式为不排序
            ObjectCompare = new CaseInsensitiveComparer();// 初始化CaseInsensitiveComparer类对象
        }
        // 重写IComparer接口.
        // <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
            // 将比较对象转换为ListViewItem对象
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            // 比较
            string X_TEXT, Y_TEXT;
            X_TEXT = listviewX.SubItems[ColumnToSort].Text;
            Y_TEXT = listviewY.SubItems[ColumnToSort].Text;
            int X_INT, Y_INT;
            try
            {
                X_INT = Int32.Parse(X_TEXT);
                Y_INT = Int32.Parse(Y_TEXT);
                compareResult = ObjectCompare.Compare(X_INT, Y_INT);
            }
            catch
            {
                compareResult = ObjectCompare.Compare(X_TEXT, Y_TEXT);
            }
            // 根据上面的比较结果返回正确的比较结果
            if (OrderOfSort == SortOrder.Ascending)
            {
                // 因为是正序排序，所以直接返回结果
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // 如果是反序排序，所以要取负值再返回
                return (-compareResult);
            }
            else
            {
                // 如果相等返回0
                return 0;
            }
        }
        /// 获取或设置按照哪一列排序.
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
        /// 获取或设置排序方式.
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}
