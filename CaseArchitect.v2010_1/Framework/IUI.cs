using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Framework
{
    public interface IUI
    {
        ICase Case { get; set; }
        void Open(int state);
        void Close();
        /// <summary>
        /// 参数为客户端的方法，最大值为3分别是Close,Load,pNotify三个事件
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        IUI Clone();
        void CaseCallbackHandl(string cmd);
        event Action<IUI> eClose;
        event Action<IUI> eLoad;
        event Action<string> pNotify;
        event GetIconEventHandler eGetIcon;
        UIType pType { get; set; }
        string pTag { get; set; }
        bool pIsClone { get; set; }
    }
    public delegate Bitmap GetIconEventHandler(IconType it);
    public enum UIType
    {
        navigate,
        tool,
        monopolize,
        content,
        setting,
        modeluf,
        unmodeluf,
        signal,
    }
}
