using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cm1
{
    using Framework;
    using Framework.Extends;
    using d = Framework.Data;
    using c = Framework.Command;
    using da = Framework.Datas.Class1;
    using bcmp = Framework.BCaseModelPorter;
    using System.Reflection;
    using h = help;
    using oml;
    public class pcm1 : BCaseModelPorter
    {
        top ftop;
        public pcm1(d data)
            : base(data)
        {
            this.ftop = new top();
            this.ftop.pData = data;
        }

        void v_CaseCallback(string cmd, params object[] ps)
        {
            base.OnCaseCallback(cmd, ps);
        }
        public override void ServerSelected()
        {
            this.ftop.pServer = this.OnGetServer(d.sn);
            this.ftop.CaseCallback += new casecallback(tp_CaseCallback);
            //
            this.ftop.prule.pData = this.ftop.pData;
            this.ftop.prule.pServer = this.ftop.pServer;
        }

        void tp_CaseCallback(string cmd, params object[] ps)
        {
            this.OnCaseCallback(cmd, ps);
        }
        /// <summary>
        /// Case功能分派接口
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="ps"></param>
        public override void Port(string cmd, params object[] ps)
        {
            // todo 
            switch (d.gcc(cmd).Last())
            {
                case Command._scmd_回传消息:
                    break;
                case Command._scmd_显示回传消息:
                    break;
                case Command._scmd_简单服务:
                    break;
                case Command._scmd_sn赋值完毕:
                    break;
                case Command._ccmd_title:
                    break;
                case Command._cmp_pcm1:
                    break;
                case Command._x_login:
                    this.ftop._x_login((string)ps[0], (string)ps[1]);
                    break;
                case c._x_registry:
                    this.ftop._x_registry(ps);
                    break;
                default:
                    break;
            }
            // base.Port(cmd,ps);
        }
    }//ceb
}
