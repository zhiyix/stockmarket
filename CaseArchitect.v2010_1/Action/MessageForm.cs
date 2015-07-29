using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Action
{
    public partial class MessageForm : Form
    {
        MessageForm()
        {
            InitializeComponent();
            //
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.timer2.Tick += new EventHandler(timer2_Tick);
            this.timer3.Tick += new EventHandler(timer3_Tick);
            this.Load += new EventHandler(Form2_Load);
            this.label1.MouseEnter += new EventHandler(label1_MouseEnter);
            this.label1.MouseLeave += new EventHandler(label1_MouseLeave);
        }
        static MessageForm mf;
        public static MessageForm pMessageForm
        {
            get { if (mf == null)mf = new MessageForm(); return mf; }
        }
        void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.BackColor = Color.LightCyan;
            this.st = 2000;
            this.timer2.Interval = this.st;
            this.timer2.Start();
        }

        void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.BackColor = Color.LightYellow;
            this.st = 5000;
            this.timer2.Interval = this.st;
            this.timer2.Stop();
        }


        void Form2_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.AllScreens[0];
            this.Location = new Point(screen.WorkingArea.Width - this.WidthMax - 20, screen.WorkingArea.Height - 6);
            //WorkingArea为Windows桌面的工作区
            this.timer2.Interval = this.StayTime = 5000;

        }

        void timer3_Tick(object sender, EventArgs e)
        {
            this.ScrollDown();
        }

        void ScrollDown()
        {
            if (Height > 5)
            {
                this.Height -= 5;
                this.Location = new Point(this.Location.X, this.Location.Y + 5);
            }
            else
            {
                this.timer3.Enabled = false;
                this.Visible = false;
            }
        }
        public void Show(string msg)
        {
            this.Visible = true;
            this.label1.Text = msg;
            this.ForeColor = Color.Navy;
            this.Width = this.WidthMax;
            this.Height = 0;
            base.Show();
            this.timer1.Enabled = true;
        }
        public void Show(string msg, Color fontColor)
        {
            this.Visible = true;
            this.label1.Text = msg;
            this.ForeColor = fontColor;
            this.Width = this.WidthMax;
            this.Height = 0;
            base.Show();
            this.timer1.Enabled = true;
        }
        void timer2_Tick(object sender, EventArgs e)
        {
            this.timer2.Enabled = false;
            this.timer3.Enabled = true;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            this.ScrollUp();
        }

        void ScrollUp()
        {
            if (this.Height < this.HeightMax)
            {
                this.Height += 5;
                this.Location = new Point(this.Location.X, this.Location.Y - 5);
            }
            else
            {
                this.timer1.Enabled = false;
                this.timer2.Enabled = true;
            }
        }
        /// <summary>
        /// 窗口显示消息
        /// </summary>
        public new string Text { get { return this.label1.Text; } set { this.label1.Text = value; } }
        int st;
        /// <summary>
        /// 窗口停留时间
        /// </summary>
        public int StayTime
        {
            get
            {
                if (this.st < 2000)
                    st = 5000;
                return st;
            }
            set { this.st = value; }
        }
        int HeightMax { get { return 167; } }
        int WidthMax { get { return 253; } }

    }
}
