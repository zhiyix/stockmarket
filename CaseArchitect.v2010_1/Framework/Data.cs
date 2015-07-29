using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Framework
{
    using Extends;
    public class Data : IDocumentLayerManager
    {
        object temp;
        public void Set<T>(T t)
        {
            this.temp = t;
        }
        public T Get<T>()
        {
            T t = default(T);
            t = (T)this.temp;
            return t;
        }
        public Data()
        {
            this.pArel = new List<AutoResetEvent>();
            this.fCaseTasks = new Dictionary<string, Func<object, object>>();
            this.pCaseMap = new XElement("case_map");
            ((IDocumentLayerManager)(this)).pControlStore = new List<Control>();
            this.pTaskCallbackDatas = new Dictionary<string, object>();
        }
        //
        #region static methods
        /// <summary>
        /// GetCommandString
        /// </summary>
        /// <param name="cmds"></param>
        /// <returns></returns>
        public static string gcs(params Command[] cmds)
        {
            string cmd = string.Empty;
            foreach (var item in cmds)
            {
                cmd += item.ToString();
            }
            return cmd;
        }
        /// <summary>
        /// GetCommandConstitutes
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static Command[] gcc(string cmd)
        {
            List<Command> ls = new List<Command>();
            Command[] cmds = default(Command[]);
            var v = cmd.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            if (v.Length % 2 != 0)
                throw new Exception("传入指令串可能有错误");
            for (int i = 0, j = 0; j < v.Length; i++, j = i * 2)
            {
                StringBuilder subcmd = new StringBuilder();
                subcmd.Append("_");
                subcmd.Append(v[j]);
                subcmd.Append("_");
                subcmd.Append(v[j + 1]);
                ls.Add((Command)Enum.Parse(typeof(Command), subcmd.ToString()));
            }
            cmds = new Command[ls.Count];
            ls.CopyTo(cmds);
            return cmds;
        }
        /// <summary>
        /// GetCommandType
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string gct(Command cmd)
        {
            string cmdType = default(string);
            cmdType = cmd.ToString().Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).First();
            return cmdType;
        }
        /// <summary>
        /// GetCommandContent
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string gcc(Command cmd)
        {
            string cmdContent = default(string);
            cmdContent = cmd.ToString().Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).Last();
            return cmdContent;
        }
        /// <summary>
        /// is point command
        /// </summary>
        /// <param name="cmdstring"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool ipc(string cmdstring, Command cmd)
        {
            bool b = false;
            var v = gcc(cmdstring);
            foreach (var item in v)
            {
                if (cmd == item)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        /// <summary>
        /// get table type command
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static Command[] gtt(string cmd)
        {
            Command[] cs = default(Command[]);
            List<Command> lcs = new List<Command>();
            foreach (var item in gcc(cmd))
            {
                if (gct(item) == "table")
                    lcs.Add(item);
            }
            cs = new Command[lcs.Count];
            lcs.Sort();
            lcs.CopyTo(cs);
            return cs;
        }
        #endregion
        //
        #region properties
        public static BaseUC pCurrentUC { get; set; }
        internal XElement pCaseMap { get; set; }
        internal XDocument pCaseDoc { get; set; }
        public string Message { get; set; }
        public bool pIsAsynchronism { get; set; }
        public List<AutoResetEvent> pArel { get; set; }
        #endregion

        /// <summary>
        /// case call back handle
        /// </summary>
        public CmpCallbackHandler SettingStateFromCmp { get; set; }

        #region case operation--tasks project document layer
        internal Dictionary<string, Func<object, object>> fCaseTasks;
        Dictionary<string, Func<object, object>> IDocumentLayerManager.pCaseTasks { get { return this.fCaseTasks; } }
        public Dictionary<string, object> pTaskCallbackDatas { get; internal set; }
        public void DefineTask(string name, Func<object, object> df)
        {
            this.fCaseTasks.Add(name, df);
        }
        object IDocumentLayerManager.AppointTask(string name, object p)
        {
            XElement xe = new XElement("task");
            var m = this.fCaseTasks[name];
            xe.Add(new XAttribute("describe", name));
            this.pCaseMap.Add(xe);
            var r = this.fCaseTasks[name].Invoke(p);
            foreach (var item in this.pTaskCallbackDatas.Keys)
            {
                if (name != item) continue;
                else goto jump;
            }
            this.pTaskCallbackDatas.Add(name, r);
        jump:
            return r;
        }
        public event Func<float[], RowStyle[]> egetrs;
        public event Func<float[], ColumnStyle[]> egetcs;
        public event Func<Control, int, ucontrol> egetuc;
        public event TopicReportEventHandler eReport;
        RowStyle[] IDocumentLayerManager.Onegetrs(params float[] ps)
        {
            if (this.egetrs != null)
                return this.egetrs.Invoke(ps);
            throw new Exception("设置行样式时出错");
        }
        ColumnStyle[] IDocumentLayerManager.Onegetcs(params float[] ps)
        {
            if (this.egetcs != null)
                return this.egetcs.Invoke(ps);
            throw new Exception("设置列样式时出错");
        }
        ucontrol IDocumentLayerManager.Onegetuc(Control c, int ps)
        {
            if (this.egetuc != null)
                return this.egetuc.Invoke(c, ps);
            throw new Exception("设置控件位置时出错");
        }
        void IDocumentLayerManager.OneReport(string tag, UIType uiType, RowStyle[] rss, ColumnStyle[] css, params ucontrol[] ucs)
        {
            if (this.eReport != null) this.eReport.Invoke(tag, uiType, rss, css, ucs);
        }
        List<Control> IDocumentLayerManager.pControlStore { get; set; }

        Control IDocumentLayerManager.CreateControl(ControlType ct, string name, string text, int style, object data, Func<object, object> click)
        {
            Control c = default(Control);
            switch (ct)
            {
                case ControlType.TextBox:
                    TextBox tb = new TextBox();
                    tb.BorderStyle = (BorderStyle)style;
                    tb.Multiline = true;
                    c = tb;
                    break;
                case ControlType.Label:
                    Label l = new Label();
                    l.BorderStyle = (BorderStyle)style;
                    c = l;
                    break;
                case ControlType.ListView:
                    ListView lv = new ListView();
                    lv.View = (View)style;
                    var v = data as ListView.ListViewItemCollection;
                    lv.Items.AddRange(v);
                    c = lv;
                    break;
                case ControlType.ListBox:
                    ListBox lb = new ListBox();
                    lb.BorderStyle = (BorderStyle)style;
                    lb.Items.AddRange(data as ListBox.ObjectCollection);
                    c = lb;
                    break;
                case ControlType.TreeView:
                    TreeView tv = new TreeView();
                    tv.BorderStyle = (BorderStyle)style;
                    tv.Nodes.AddRange(data as TreeNode[]);
                    c = tv;
                    break;
                case ControlType.CheckBox:
                    CheckBox cb = new CheckBox();
                    cb.FlatStyle = (FlatStyle)style;
                    cb.Checked = (bool)data;
                    c = cb;
                    break;
                case ControlType.DataGridView:
                    DataGridView dgv = new DataGridView();
                    dgv.BorderStyle = (BorderStyle)style;
                    dgv.DataSource = data;
                    c = dgv;
                    break;
                case ControlType.Button:
                    Button b = new Button();
                    b.FlatStyle = (FlatStyle)style;
                    c = b;
                    break;
                case ControlType.WebBrowser:
                    WebBrowser wb = new WebBrowser();
                    wb.DocumentText = (string)data;
                    c = wb;
                    break;
                case ControlType.PictureBox:
                    PictureBox pb = new PictureBox();
                    pb.BorderStyle = (BorderStyle)style;
                    pb.Image = data as Image;
                    c = pb;
                    break;
                case ControlType.ComboBox:
                    ComboBox cb2 = new ComboBox();
                    cb2.FlatStyle = (FlatStyle)style;
                    cb2.Items.AddRange(data as object[]);
                    c = cb2;
                    break;
                case ControlType.DateTimePicker:
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Value = (DateTime)data;
                    c = dtp;
                    break;
                case ControlType.RichTextBox:
                    RichTextBox rtb = new RichTextBox();
                    rtb.BorderStyle = (BorderStyle)style;
                    c = rtb;
                    break;
                default:
                    break;
            }
            if (c != null)
            {
                c.Name = name;
                c.Text = text;
                c.Dock = DockStyle.Fill;
                c.Click += (sender, e) =>
                {
                    if (click != null)
                    {
                        XElement xe = new XElement("task");
                        var m = (from t in this.fCaseTasks
                                 where t.Value == click
                                 select t).First();
                        xe.Add(new XAttribute("describe", m.Key));
                        this.pCaseMap.Add(xe);
                        var r = click.Invoke(sender);
                        foreach (var item in this.pTaskCallbackDatas.Keys)
                        {
                            if (name != item) continue;
                            else goto jump;
                        }
                        this.pTaskCallbackDatas.Add(name, r);
                    jump: ;
                    }
                };
                ((IDocumentLayerManager)(this)).pControlStore.Add(c);
            }
            return c;
        }

        Control IDocumentLayerManager.CreateControl(ControlType ct, string name, string text, int style, object data, string taskkey, object taskdata)
        {
            Control c = default(Control);
            switch (ct)
            {
                case ControlType.TextBox:
                    TextBox tb = new TextBox();
                    tb.BorderStyle = (BorderStyle)style;
                    tb.Multiline = true;
                    c = tb;
                    break;
                case ControlType.Label:
                    Label l = new Label();
                    l.BorderStyle = (BorderStyle)style;
                    c = l;
                    break;
                case ControlType.ListView:
                    ListView lv = new ListView();
                    lv.View = (View)style;
                    var v = data as ListView.ListViewItemCollection;
                    lv.Items.AddRange(v);
                    c = lv;
                    break;
                case ControlType.ListBox:
                    ListBox lb = new ListBox();
                    lb.BorderStyle = (BorderStyle)style;
                    lb.Items.AddRange(data as ListBox.ObjectCollection);
                    c = lb;
                    break;
                case ControlType.TreeView:
                    TreeView tv = new TreeView();
                    tv.BorderStyle = (BorderStyle)style;
                    tv.Nodes.AddRange(data as TreeNode[]);
                    c = tv;
                    break;
                case ControlType.CheckBox:
                    CheckBox cb = new CheckBox();
                    cb.FlatStyle = (FlatStyle)style;
                    cb.Checked = (bool)data;
                    c = cb;
                    break;
                case ControlType.DataGridView:
                    DataGridView dgv = new DataGridView();
                    dgv.BorderStyle = (BorderStyle)style;
                    dgv.DataSource = data;
                    c = dgv;
                    break;
                case ControlType.Button:
                    Button b = new Button();
                    b.FlatStyle = (FlatStyle)style;
                    c = b;
                    break;
                case ControlType.WebBrowser:
                    WebBrowser wb = new WebBrowser();
                    wb.DocumentText = (string)data;
                    c = wb;
                    break;
                case ControlType.PictureBox:
                    PictureBox pb = new PictureBox();
                    pb.BorderStyle = (BorderStyle)style;
                    pb.Image = data as Image;
                    c = pb;
                    break;
                case ControlType.ComboBox:
                    ComboBox cb2 = new ComboBox();
                    cb2.FlatStyle = (FlatStyle)style;
                    cb2.Items.AddRange(data as object[]);
                    c = cb2;
                    break;
                case ControlType.DateTimePicker:
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Value = (DateTime)data;
                    c = dtp;
                    break;
                case ControlType.RichTextBox:
                    RichTextBox rtb = new RichTextBox();
                    rtb.BorderStyle = (BorderStyle)style;
                    c = rtb;
                    break;
                default:
                    break;
            }
            if (c != null)
            {
                c.Name = name;
                c.Text = text;
                c.Dock = DockStyle.Fill;
                c.Click += (sender, e) =>
                {
                    ((IDocumentLayerManager)(this)).AppointTask(taskkey, taskdata);
                };
                ((IDocumentLayerManager)(this)).pControlStore.Add(c);
            }
            return c;
        }
        void IDocumentLayerManager.ResetEvents()
        {
            this.eReport = null;
            this.egetcs = null;
            this.egetrs = null;
            this.egetuc = null;
        }
        void IDocumentLayerManager.BeginTopic(Command c)
        {
            this.pCaseMap.Add(new XAttribute("subject", c.ToString()));
            this.pCaseMap.Add(new XAttribute("date", DateTime.Now));
        }
        void IDocumentLayerManager.EndTopic()
        {
            string path = Properties.Settings.Default.CaseContent;
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(this.pCaseMap.ToString());
                sw.Write(Environment.NewLine);
            }
            this.pCaseMap.RemoveAll();
            this.fCaseTasks.Clear();
            ((IDocumentLayerManager)(this)).pControlStore.Clear();
            this.pTaskCallbackDatas.Clear();
        }
        void IDocumentLayerManager.ErrorTopic(Exception e)
        {
            var xe = new XElement("exception");
            xe.Add(new XAttribute("message", e.Message), new XAttribute("source", e.Source));
            this.pCaseMap.Add(xe);
        }
        //
        #endregion
        //
        public void WaitAll()
        {
            if (this.pArel.Count > 0)
            {
                WaitHandle.WaitAll(this.pArel.ToArray());
                this.pArel.Clear();
            }
        }
        public DataTable CastToDataTable(params object[] ps)
        {
            DataRow dr = default(DataRow);
            DataTable dt = new DataTable("dt");
            for (int i = 0; i < ps.Length; i++)
            {
                dt.Columns.Add("col" + i.ToString());
            }
            dr = dt.NewRow();
            for (int i = 0; i < ps.Length; i++)
            {
                dr[i] = ps[i];
            }
            dt.Rows.Add(dr);
            return dt;
        }
        public DataTable CastToDataTable(string[] columnNames, object[][] vs)
        {
            DataTable dt = new DataTable("dt");
            if (vs == null || vs.Length < 1)
            {
                throw new Exception("内容数据不能为空");
            }
            if (columnNames.Length != vs[0].Length)
            {
                throw new Exception("列名称与数据数目不一致");
            }
            for (int i = 0; i < columnNames.Length; i++)
            {
                dt.Columns.Add(columnNames[i]);
            }
            for (int i = 0; i < vs.Length; i++)
            {
                dt.Rows.Add(vs[i]);
            }
            return dt;
        }
        //
        /// <summary>
        /// ServerName
        /// </summary>
        public static string sn { get; set; }
        public List<string> ServiceNames { get; set; }
        public TData Getsub<TData>() where TData : Data
        {
            TData td = default(TData);
            td = this as TData;
            return td;
        }
        /// <summary>
        /// 用于跨线程间操作时UI端所需要的关键参数构造
        /// </summary>
        /// <param name="sender">调用端</param>
        /// <param name="a">用于控件跨线程操作时的委托</param>
        /// <returns>需要关键参数</returns>
        public Delegate GetDelegate(object sender, Action a)
        {
            Delegate d = default(Delegate);
            d = Delegate.CreateDelegate(typeof(Action), sender, a.Method);
            return d;
        }
    }//class end border    
}
