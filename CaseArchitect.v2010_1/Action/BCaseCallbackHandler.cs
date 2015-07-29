using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Framework;

namespace Action
{
    using d = Framework.Data;
    using c = Framework.Command;
    using System.ComponentModel;

    public class BCaseCallbackHandler
    {
        protected SynchronizationContext sc;
        protected IUI[] uis;
        protected ICase Case;
        //
        public event Action<string> pNotify;
        protected virtual void OnpNotify(string msg)
        {
            if (this.pNotify != null) this.pNotify.Invoke(msg);
        }
        //
        protected IUI this[string name]
        {
            get
            {
                foreach (var item in this.uis)
                {
                    if (name == item.pTag)
                        return item;
                }
                return null;
            }
        }

        public BCaseCallbackHandler(IUI[] uis, ICase c)
        {
            this.uis = uis;
            this.sc = SynchronizationContext.Current;
            this.Case = c;
        }
        public void CaseCallbackHandler(IUI ui, string cmd, params object[] ps)
        {
            try
            {
                if (this.Case.pData.pIsAsynchronism)
                {
                    if (ui != null)
                        sc.Post(o =>
                        {
                            this.Case.pipo.pProgressBar.Visible = false;
                            ui.CaseCallbackHandl(cmd);
                        }, null);
                    else
                    {
                        sc.Post(o =>
                        {
                            this.RealCaseCallbackHandl(cmd, ps);
                        }, null);
                    }
                }
                else
                {
                    this.RealCaseCallbackHandl(cmd, ps);
                }
            }
            catch (Exception e)
            {
                this.OnpNotify("-" + e.Message);
            }
        }
        protected virtual void RealCaseCallbackHandl(string cmd, params object[] ps)
        {
            if (ps != null && ps.Length > 0)
            {
                if (cmd == d.gcs(c._scmd_回传消息))
                {
                    this.OnpNotify(ps[0].ToString());
                }
                else if (cmd == d.gcs(c._scmd_显示回传消息))
                {
                    MessageBox.Show((string)ps[0]); return;
                }
                this.HaveParameterHandle(cmd, ps);
            }
            else
            {
                this.NonParameterHandle(cmd);
            }
        }

        protected virtual void NonParameterHandle(string cmd)
        {
            throw new NotImplementedException();
        }

        protected virtual void HaveParameterHandle(string cmd, object[] ps)
        {
            throw new NotImplementedException();
        }
    }
}
