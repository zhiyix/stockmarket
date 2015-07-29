using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Framework
{
    public interface ICase
    {
        void CaseLogic(string cmd, params object[] ps);
        AutoResetEvent AsynCaseLogic(IUI ui, string cmd, params object[] ps);
        //
        event CaseCallbackEventHandler eCaseCallback;
        Data pData { get; set; }
        IPropertyOperate pipo { get; set; }
    }
    public delegate void CaseLogicEventHandler(string cmd, params object[] ps);
    public delegate AutoResetEvent AsynCaseLogicEventHandler(IUI ui, string cmd, params object[] ps);

    public delegate void CmpCallbackHandler(params object[] ps);
    public delegate void CaseCallbackEventHandler(IUI ui, string cmd, params object[] ps);
    public interface IPropertyOperate
    {
        Size pSettingSize { get; set; }
        MenuStrip pMenuStrip { get; }
        ToolStrip pToolStrip { get; set; }
        ToolStripProgressBar pProgressBar { get; set; }
        TabControl pLeftTabControl { get; }
        TabControl pRitghtTabControl { get; }
        SplitContainer pSplitContainer { get; }
        string pMainWindowName { get; set; }
        string pNotify { set; }
        Size pMainFormClientSize { get; set; }
        Rectangle pRestoreBounds { get; }
        double pOpacity { get; set; }
        FormBorderStyle pFormBorderStyle { get; set; }
        bool pMaximizeBox { get; set; }
        bool pMinimizeBox { get; set; }
        //
        void OpenUC(string ucName, int ucState);
        void CloseUC(string tag);
        void ClearLeftPanel();
        void ClearRightPanel();
        void ClearAllPanel();
        void ShowPrograssBarState();
        void ShowMessage(string msg);
        void ShowMessage(string msg, Color fontColor);
        void CloseMessageForm();
        void Hide();
        void Show();
        void About();
    }
}
