//#define login1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework;
using Framework.Extends;
using System.Drawing;
using d = Framework.Data;
using c = Framework.Command;
using da = Framework.Datas.Class1;
using size = System.Drawing.Size;
using System.Windows.Forms.Integration;

namespace cui1
{
    partial class uipcui1
    {
        /// <summary>
        /// login
        /// </summary>
        private void Load0()
        {
            //准备工作（引入控件）
#if login1
            ucs.Login login = new ucs.Login();
            //重置面

            base.ResetUC(size.Empty,"login...",UIType.modeluf,login);
#else
            this.tlp.Controls.Clear();
            this.ResetUC(
                base.SetStyle("Login", UIType.modeluf, 1, 1),
                base.getrs(50.1f, 10.1f, 26.1f, 26.1f, 5.1f, 31.1f, 70.2f),
                base.getcs(20.1f, 60.1f, 60.1f, 60.1f, 60.1f, 40.1f),
                base.getuc(base.setc<PictureBox>("pb", "", this.BackColor, true, true, base.OneGetIcon(IconType.offline_user), ImageLayout.Zoom, null, null, null, null, null, null), 11114),
                base.getuc(base.setc<Label>("lbname", "登录名"), 13211),
                base.getuc(base.setc<Label>("lbpwd", "密码"), 14211),
                base.getuc(base.setc<TextBox>("tbname", ""), 13313),
                base.getuc(base.setc<TextBox>("tbpwd", ""), 14313),
                base.getuc(base.setc<Button>("btncancle", "取消"), 16311),
                base.getuc(base.setc<Button>("btnregistry", "注册"), 16411),
                base.getuc(base.setc<Button>("btnlogin", "登录"), 16511)
                );
#endif
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        MessageBox.Show("Test login is successed.");
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        MessageBox.Show("Test login is successed.");
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu0(this);
            //设置界面事件
            this.setcontrol0();
        }
        /// <summary>
        /// registry
        /// </summary>
        void Load1()
        {
            //准备工作（引入控件）
            ucs.Registry rgt = new ucs.Registry();
            //重置面
            base.ResetUC(size.Empty, "registry...", UIType.unmodeluf, rgt);
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        MessageBox.Show("Test registry is successed.");
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        MessageBox.Show("Test registry is successed.");
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu1(this);
            //设置界面事件
            this.setcontrol1();
        }
        void Load2()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu2(this);
            //设置界面事件
            this.setcontrol2();
        }
        void Load3()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu3(this);
            //设置界面事件
            this.setcontrol3();
        }
        void Load4()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu4(this);
            //设置界面事件
            this.setcontrol4();
        }
        void Load5()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu5(this);
            //设置界面事件
            this.setcontrol5();
        }
        void Load6()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu6(this);
            //设置界面事件
            this.setcontrol6();
        }
        void Load7()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu7(this);
            //设置界面事件
            this.setcontrol7();
        }
        void Load8()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu8(this);
            //设置界面事件
            this.setcontrol8();
        }
        void Load9()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu9(this);
            //设置界面事件
            this.setcontrol9();
        }
        void Load10()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu10(this);
            //设置界面事件
            this.setcontrol10();
        }
        //
        void Load11()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu11(this);
            //设置界面事件
            this.setcontrol11();
        }
        void Load12()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu12(this);
            //设置界面事件
            this.setcontrol12();
        }
        void Load13()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu13(this);
            //设置界面事件
            this.setcontrol13();
        }
        void Load14()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu14(this);
            //设置界面事件
            this.setcontrol14();
        }
        void Load15()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu15(this);
            //设置界面事件
            this.setcontrol15();
        }
        void Load16()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu16(this);
            //设置界面事件
            this.setcontrol16();
        }
        void Load17()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu17(this);
            //设置界面事件
            this.setcontrol17();
        }
        void Load18()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu18(this);
            //设置界面事件
            this.setcontrol18();
        }
        void Load19()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu19(this);
            //设置界面事件
            this.setcontrol19();
        }
        void Load20()
        {
            //准备工作（引入控件）
            //重置面板
            //外部状态设置
            if (this.tlp.Controls.Count == 1)
                this.tlp.getc<Control>(0, 0).MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            else
                this.tlp.MouseEnter += (s, e) =>
                {
                    this.Case.pData.SettingStateFromCmp = null;
                    this.Case.pData.SettingStateFromCmp += (ps) =>
                    {
                        //parse ps
                        //todo your setting code
                    };
                };
            //设置操作菜单
            this.setmenu20(this);
            //设置界面事件
            this.setcontrol20();
        }
    }
}
