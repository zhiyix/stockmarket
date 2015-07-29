using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Framework
{
    public interface IDocumentLayerManager
    {
        void DefineTask(string name, Func<object, object> df);
        object AppointTask(string name, object p);
        void ResetEvents();
        event Func<float[], RowStyle[]> egetrs;
        event Func<float[], ColumnStyle[]> egetcs;
        event Func<Control, int, ucontrol> egetuc;
        event TopicReportEventHandler eReport;
        RowStyle[] Onegetrs(params float[] ps);
        ColumnStyle[] Onegetcs(params float[] ps);
        ucontrol Onegetuc(Control c, int ps);
        void OneReport(string tag, UIType uiType, RowStyle[] rss, ColumnStyle[] css, params ucontrol[] ucs);
        //
        Control CreateControl(ControlType ct, string name, string text, int style, object data, Func<object, object> click);
        Control CreateControl(ControlType ct, string name, string text, int style, object data, string taskkey, object taskdata);
        List<Control> pControlStore { get; set; }
        Dictionary<string, Func<object, object>> pCaseTasks { get; }
        Dictionary<string, object> pTaskCallbackDatas { get; }
        //
        void BeginTopic(Command c);
        void EndTopic();
        void ErrorTopic(Exception e);
    }
    public sealed class ucontrol
    {
        public Control c;
        public int rowPosition, columnPosition, rowSpan, columnSpan;
    }
    public enum ControlType
    {
        TextBox, Label, ListView, ListBox, TreeView, CheckBox, DataGridView, Button, WebBrowser, PictureBox, ComboBox, DateTimePicker, RichTextBox
    }
    public delegate void TopicReportEventHandler(string tag, UIType uiType, RowStyle[] rss, ColumnStyle[] css, ucontrol[] ucs);
}
