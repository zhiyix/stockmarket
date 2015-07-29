using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Framework.Extends
{
    /// <summary>
    /// 本类用于书写扩展方法
    /// </summary>
    public static class ex
    {
        public static T getc<T>(this TableLayoutPanel tlp, string name) where T : Control
        {
            T t = default(T);
            foreach (Control item in tlp.Controls)
            {
                if (item.Name == name && item is T)
                    t = (T)item;
            }
            return t;
        }
        public static T getc<T>(this TableLayoutPanel tlp, int rowPosition, int columnPosition) where T : Control
        {
            T t = default(T);
            var v = tlp.GetControlFromPosition(columnPosition, rowPosition);
            if (v != null && v is T)
                t = (T)v;
            return t;
        }
        public static T getc<T>(this List<Control> lc, string name) where T : Control, new()
        {
            T t = default(T);
            foreach (var item in lc)
            {
                if (item.Name == name)
                {
                    t = item as T;
                    break;
                }
            }
            return t;
        }
    }
}
