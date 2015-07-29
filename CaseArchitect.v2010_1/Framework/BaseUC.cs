using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Framework
{
    using d = Framework.Data;
    using c = Framework.Command;

    public partial class BaseUC : UserControl, IUI
    {
        public BaseUC()
        {
            InitializeComponent();
            InitialUserCom();
        }

        #region IUI 成员
        ICase icase;
        public ICase Case
        {
            get { return this.icase; }
            set
            {
                this.icase = value;
                IDocumentLayerManager idlm = this.icase.pData;
                idlm.ResetEvents();
                idlm.egetcs += this.getcs;
                idlm.egetrs += this.getrs;
                idlm.egetuc += this.getuc;
                idlm.eReport += this.Report;
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="state">参数表明，加载时可能访问不同的表或其它数据源，而载入控件时的数据不同</param>
        public void Open(int state)
        {
            this.UIState = state;
            this.LocalSetting();
            this.OnLoad();
            if (this.pIsNotDisplayPanel)
            {
                this.Case.pipo.ClearAllPanel();
                this.pIsNotDisplayPanel = false;
            }
            this.Show();
        }
        public void Close()
        {
            OneClose();
        }
        public IUI Clone()
        {
            IUI ui = this.GetSubui();
            if (ui != null)
            {
                ui.pIsClone = true;
                ui.Case = this.Case;
                ui.pType = this.pType;
                ui.eClose += this.eClose;
                ui.eLoad += this.eLoad;
                ui.pNotify += this.pNotify;
                ui.eGetIcon += this.eGetIcon;
            }
            return ui;
        }
        public virtual void CaseCallbackHandl(string cmd) { }
        public event Action<IUI> eClose;
        public event Action<IUI> eLoad;
        public event Action<string> pNotify;
        public event GetIconEventHandler eGetIcon;

        public UIType pType { get; set; }
        public string pTag { get; set; }
        public bool pIsClone { get; set; }

        #endregion

        #region 基本支持

        protected virtual void OneClose()
        {
            if (this.eClose != null)
            {
                this.eClose.Invoke(this);
            }
        }
        protected virtual void OnLoad()
        {
            if (this.eLoad != null)
            {
                this.eLoad.Invoke(this);
            }
        }
        protected virtual void OnpNotify(string msg)
        {
            if (this.pNotify != null)
            {
                this.pNotify.Invoke(msg);
            }
        }
        protected virtual Bitmap OneGetIcon(IconType it)
        {
            Bitmap b = default(Bitmap);
            if (this.eGetIcon != null)
            {
                b = this.eGetIcon.Invoke(it);
            }
            return b;
        }
        //
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.OneClose();
        }
        //
        protected static Form singalParent;
        protected void LocalSetting()
        {
            this.LocalSettingExtend();
            switch (this.pType)
            {
                case UIType.navigate:
                    this.ClearData();
                    break;
                case UIType.modeluf:
                    this.toolStripButton1.Visible = false;
                    break;
                case UIType.signal:
                    singalParent = (Form)this.Parent;
                    break;
                default:
                    break;
            }
        }
        protected virtual void LocalSettingExtend() { }
        protected virtual void ClearData() { }
        protected virtual void InitialUserCom()
        {
            this.toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            this.pIsClone = false;
        }
        /// <summary>
        /// 重置UC
        /// </summary>
        /// <param name="size">若为Size.Empty则表明尺寸维持原状否则的话this.Size=size;</param>
        /// <param name="tag">ui标签,特别注意首字母为‘-’时关闭按钮将不显示</param>
        /// <param name="type">ui类型</param>
        protected void ResetUC(Size size, string tag, UIType type, Control c)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            //
            if (size != System.Drawing.Size.Empty)
                this.Size = size;
            else if (c != null)
                this.ClientSize = c.Size;
            if (tag == string.Empty || tag == null)
                this.pTag = c.GetType().Name;
            else
            {
                if (tag[0] == '-')
                {
                    this.toolStripButton1.Visible = false;
                    this.pTag = tag.Substring(1, tag.Length - 1);
                }
                else
                {
                    this.pTag = tag;
                }
            }
            this.pType = type;
            if (c != null)
            {
                c.Dock = DockStyle.Fill;
                this.tlp.Controls.Add(c);
                this.tlp.SetCellPosition(c, new TableLayoutPanelCellPosition(0, 0));
            }
        }
        protected virtual IUI GetSubui() { return null; }
        /// <summary>
        /// UIState 是控制状态，为单一控件担任多种角色用途提供了可能。例如用于，根据不同的UIState值而产生不同的事件处理应答.
        /// </summary>
        protected int UIState { get; set; }
        protected ToolStrip pToolStrip { get { return this.toolStrip1; } set { this.toolStrip1 = value; } }
        /// <summary>
        /// 是否不显示面版，用于打开时显示空环境等需求所设置，这时仅影响菜单，等命令方面。
        /// </summary>
        protected bool pIsNotDisplayPanel { get; set; }

        #region layout


        protected RowStyle[] getrs(params float[] ps)
        {
            RowStyle[] rss = default(RowStyle[]);
            List<RowStyle> rsl = new List<RowStyle>();
            foreach (var item in ps)
            {
                int p = (int)(item);
                int x = (int)Math.Round((item - p) * 10);
                switch (x % 3)
                {
                    case 0: rsl.Add(new RowStyle(SizeType.AutoSize, p)); break;
                    case 1: rsl.Add(new RowStyle(SizeType.Absolute, p)); break;
                    case 2: rsl.Add(new RowStyle(SizeType.Percent, p)); break;
                    default:
                        break;
                }
            }
            rss = new RowStyle[rsl.Count];
            rsl.CopyTo(rss);
            return rss;
        }
        protected ColumnStyle[] getcs(params float[] ps)
        {
            ColumnStyle[] rss = default(ColumnStyle[]);
            List<ColumnStyle> rsl = new List<ColumnStyle>();
            foreach (var item in ps)
            {
                int p = (int)(item);
                int x = (int)Math.Round((item - p) * 10);
                switch (x % 3)
                {
                    case 0: rsl.Add(new ColumnStyle(SizeType.AutoSize, p)); break;
                    case 1: rsl.Add(new ColumnStyle(SizeType.Absolute, p)); break;
                    case 2: rsl.Add(new ColumnStyle(SizeType.Percent, p)); break;
                    default:
                        break;
                }
            }
            rss = new ColumnStyle[rsl.Count];
            rsl.CopyTo(rss);
            return rss;
        }

        protected ucontrol getuc(Control c, int rowPosition, int columnPosition, int rowSpan, int columnSpan)
        {
            ucontrol uc = new ucontrol() { c = c, rowPosition = rowPosition, columnPosition = columnPosition, rowSpan = rowSpan, columnSpan = columnSpan };
            return uc;
        }
        /// <summary>
        /// 简单构造ucontrol对象
        /// </summary>
        /// <param name="c"></param>
        /// <param name="rc">是一个5位整型数字，后4位为有效设置分别对应为rowPosition,columnPosition,rowSpan,columnSpan</param>
        /// <returns></returns>
        protected ucontrol getuc(Control c, int rc)
        {
            ucontrol uc = new ucontrol() { c = c };
            if (rc >= 10011 && rc <= 99999)
            {
                var v = (int)rc / 10000;
                uc.rowPosition = (int)(rc - v * 10000) / 1000;
                uc.columnPosition = (int)(rc - (v * 10000 + uc.rowPosition * 1000)) / 100;
                uc.rowSpan = (int)(rc - (v * 10000 + uc.rowPosition * 1000 + uc.columnPosition * 100)) / 10;
                uc.columnSpan = (int)(rc - (v * 10000 + uc.rowPosition * 1000 + uc.columnPosition * 100 + uc.rowSpan * 10));
            }
            else
            {
                throw new ArgumentOutOfRangeException("rc,要求范围为，10011～99999");
            }
            return uc;
        }

        protected T setc<T>(string name, string text) where T : Control, new()
        {
            T t = default(T);
            t = new T();
            t.Name = name;
            t.Text = text;
            return t;
        }
        /// <param name="b">多义bool值:label.autosize,textbox.mutiline,listview.checkboxs</param>
        protected T setc<T>(string name, string text, Color bc, bool enable, DockStyle? ds, bool? b, BorderStyle? bs, FlatStyle? fs, ContentAlignment? ca) where T : Control, new()
        {
            T t = default(T);
            t = new T();
            t.Name = name;
            t.Text = text;
            if (ds != null) t.Dock = ds.Value;
            t.BackColor = bc;
            t.Enabled = enable;
            if (t is Label) { if (b != null)(t as Label).AutoSize = b.Value; if (fs != null)(t as Label).FlatStyle = fs.Value; if (ca != null)(t as Label).TextAlign = ca.Value; } else if (t is Button) { if (fs != null)(t as Button).FlatStyle = fs.Value; } else if (t is TextBox) { if (b != null)(t as TextBox).Multiline = b.Value; if (bs != null)(t as TextBox).BorderStyle = bs.Value; } else if (t is ComboBox) { if (fs != null)(t as ComboBox).FlatStyle = fs.Value; } else if (t is ListView) { if (b != null)(t as ListView).CheckBoxes = b.Value; if (bs != null)(t as ListView).BorderStyle = bs.Value; } else if (t is ListBox) { if (bs != null)(t as ListBox).BorderStyle = bs.Value; } else if (t is TreeView) { if (bs != null)(t as TreeView).BorderStyle = bs.Value; } else if (t is PictureBox) { if (bs != null)(t as PictureBox).BorderStyle = bs.Value; } else if (t is ListBox) { if (bs != null)(t as ListBox).BorderStyle = bs.Value; }
            return t;
        }
        /// <summary>
        /// set control
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <param name="ds"></param>
        /// <param name="bc"></param>
        /// <param name="enable"></param>
        /// <param name="visiable"></param>
        /// <param name="backgroundimg"></param>
        /// <param name="backgroundimglayout"></param>
        /// <param name="b">多义bool值:label.autosize,textbox.mutiline,listview.checkboxs</param>
        /// <param name="bs"></param>
        /// <param name="fs"></param>
        /// <param name="ca"></param>
        /// <returns></returns>
        protected T setc<T>(string name, string text, Color bc, bool enable, bool visiable, Image backgroundimg, ImageLayout backgroundimglayout, DockStyle? ds, bool? b, bool? readOnly, BorderStyle? bs, FlatStyle? fs, ContentAlignment? ca) where T : Control, new()
        {
            T t = default(T);
            t = new T();
            t.Name = name;
            t.Text = text;
            if (ds != null) t.Dock = ds.Value;
            t.BackColor = bc;
            t.Enabled = enable;
            t.Visible = visiable;
            t.BackgroundImage = backgroundimg;
            t.BackgroundImageLayout = backgroundimglayout;
            if (t is Label) { if (b != null)(t as Label).AutoSize = b.Value; if (fs != null)(t as Label).FlatStyle = fs.Value; if (ca != null)(t as Label).TextAlign = ca.Value; } else if (t is Button) { if (fs != null)(t as Button).FlatStyle = fs.Value; } else if (t is TextBox) { if (b != null)(t as TextBox).Multiline = b.Value; if (bs != null)(t as TextBox).BorderStyle = bs.Value; if (readOnly != null)(t as TextBox).ReadOnly = readOnly.Value; } else if (t is ComboBox) { if (fs != null)(t as ComboBox).FlatStyle = fs.Value; } else if (t is ListView) { if (b != null)(t as ListView).CheckBoxes = b.Value; if (bs != null)(t as ListView).BorderStyle = bs.Value; } else if (t is ListBox) { if (bs != null)(t as ListBox).BorderStyle = bs.Value; } else if (t is TreeView) { if (bs != null)(t as TreeView).BorderStyle = bs.Value; } else if (t is PictureBox) { if (bs != null)(t as PictureBox).BorderStyle = bs.Value; } else if (t is ListBox) { if (bs != null)(t as ListBox).BorderStyle = bs.Value; }

            return t;
        }

        protected bool SetStyle(string tag, UIType type)
        {
            bool b = default(bool);
            try
            {
                this.pTag = tag;
                this.pType = type;
                this.tlp.RowStyles[0] = new RowStyle(SizeType.Absolute, 1);
                this.tlp.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 1);
                this.tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
        protected bool SetStyle(string tag, UIType type, int row0h, int column0w)
        {
            bool b = default(bool);
            try
            {
                this.pTag = tag;
                this.pType = type;
                this.tlp.RowStyles[0] = new RowStyle(SizeType.Absolute, row0h);
                this.tlp.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, column0w);
                this.tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
        protected bool SetStyle(string tag, UIType type, SizeType row0SizeType, int row0Hight, SizeType column0SizeType, int column0Width, TableLayoutPanelCellBorderStyle tlpcs)
        {
            bool b = default(bool);
            try
            {
                this.pTag = tag;
                this.pType = type;
                this.tlp.RowStyles[0] = new RowStyle(row0SizeType, row0Hight);
                this.tlp.ColumnStyles[0] = new ColumnStyle(column0SizeType, column0Width);
                this.tlp.CellBorderStyle = tlpcs;
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
        //
        protected void ResetUC(bool invoke_SetStyle, RowStyle[] rss, ColumnStyle[] css, params ucontrol[] ucs)
        {
            if (invoke_SetStyle)
            {
                this.tlp.Controls.Clear();
                float w, h;
                w = this.tlp.ColumnStyles[0].Width;
                h = this.tlp.RowStyles[0].Height;
                foreach (var item in rss)
                {
                    this.tlp.RowStyles.Add(item);
                    h += item.Height;
                }
                foreach (var item in css)
                {
                    this.tlp.ColumnStyles.Add(item);
                    w += item.Width;
                }
                this.tlp.RowCount = rss.Length + 1;
                this.tlp.ColumnCount = css.Length + 1;
                foreach (var item in ucs)
                {
                    if (item.c.Dock == DockStyle.None)
                        item.c.Dock = DockStyle.Fill;
                    this.tlp.Controls.Add(item.c);
                    this.tlp.SetRowSpan(item.c, item.rowSpan);
                    this.tlp.SetColumnSpan(item.c, item.columnSpan);
                    this.tlp.SetCellPosition(item.c, new TableLayoutPanelCellPosition(item.columnPosition, item.rowPosition));
                }
                this.ClientSize = new Size((int)w + 1, (int)h + 1);
            }
        }
        private void Report(string tag, UIType uiType, RowStyle[] arg2, ColumnStyle[] arg3, ucontrol[] arg4)
        {
            var v = this.Clone();
            var currentui = v as BaseUC;
            d.pCurrentUC = currentui;
            currentui.ResetUC(currentui.SetStyle(tag, uiType), arg2, arg3, arg4);
            currentui.OnLoad();
        }
        #endregion end layout
        //
        #endregion
    }
}
