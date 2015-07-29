//#define login1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Extends;
using System.Drawing;
using d = Framework.Data;
using c = Framework.Command;
using da = Framework.Datas.Class1;
using size = System.Drawing.Size;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace cui1
{
    partial class uipcui1
    {
        #region setcontrol

        void setcontrol0()
        {
#if login1
            var v = base.tlp.getc<ucs.Login>(0,0);
            v.button1cancel.Click += (s,e) => {
                throw new Exception("user exit this application");
            };
            v.button2registry.Click += (s,e) => {
                this.Case.pipo.OpenUC("uipcui1",1);
            };
            v.button3login.Click += (s,e) => {
                this.Case.CaseLogic(
                    d.gcs(c._cmp_pcm1,c._x_login),
                    v.textBox1name.Text,
                    v.textBox2pwd.Text);
            };
#else
            //取消

            this.tlp.getc<Button>("btncancle").Click += delegate
            {
                //Application.Exit();
                throw new NotImplementedException();
            };
            int mark = 0;
            //登录
            this.tlp.getc<Button>("btnlogin").Click += (s, e) =>
            {
                mark++;
                this.Case.CaseLogic(d.gcs(c._cmp_pcm1, c._x_login), this.tlp.getc<TextBox>("tbname").Text, this.tlp.getc<TextBox>("tbpwd").Text, mark);
            };
            //注册
            this.tlp.getc<Button>("btnregistry").Click += (sender, e) =>
            {
                this.Case.pipo.OpenUC("uipcui1", 1);
            };
#endif
        }
        void setcontrol1()
        {
            var v = base.tlp.getc<ucs.Registry>(0, 0);
            v.button1cfm.Click += (s, e) =>
            {
                this.Case.CaseLogic(
                    d.gcs(c._cmp_pcm1, c._x_registry),
                    v.textBox1name.Text,
                    v.textBox2pwd.Text
                    );
            };
        }
        void setcontrol2()
        {
        }
        void setcontrol3()
        {
        }
        void setcontrol4()
        {
        }
        void setcontrol5()
        {
        }
        void setcontrol6()
        {
        }
        void setcontrol7()
        {
        }
        void setcontrol8()
        {
        }
        void setcontrol9()
        {
        }
        void setcontrol10()
        {
        }
        void setcontrol11()
        {
        }
        void setcontrol12()
        {
        }
        void setcontrol13()
        {
        }
        void setcontrol14()
        {
        }
        void setcontrol15()
        {
        }
        void setcontrol16()
        {
        }
        void setcontrol17()
        {
        }
        void setcontrol18()
        {
        }
        void setcontrol19()
        {
        }
        void setcontrol20()
        {
        }
        #endregion
    }
}
