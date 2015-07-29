using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Framework;

namespace Case
{
    using d = Framework.Data;
    using c = Framework.Command;
    //using Framework.Extends;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;

    public class Dispatch : ICase
    {

        #region ICase 成员

        public void CaseLogic(string cmd, params object[] ps)
        {
            try
            {
                var cmdtype = d.gct(d.gcc(cmd)[0]);
                var cmdcontent = d.gcc(d.gcc(cmd)[0]);
                if (cmdtype == "cmp")
                {
                    this.GetCaseModelPorter(cmdcontent).Port(d.gcs(d.gcc(cmd)[1]), ps);
                }
                else if (cmdtype == "scmd")
                {
                    if (cmd == d.gcs(c._scmd_sn赋值完毕))
                        foreach (var item in this.pCaseModelPorters)
                        {
                            item.ServerSelected();
                        }
                    this.OnCaseCallback(cmd, ps);
                }
                else if (cmdtype == "ccmd")
                {
                    var cs = d.gcc(cmd);
                    foreach (var item in cs)
                    {
                        if (d.gct(item) == "cmp")
                        {
                            this.GetCaseModelPorter(d.gcc(item)).Port(d.gcs(cs.Last()), ps);
                        }
                    }
                }
                else
                {
                    this.CaseService(cmd, ps);
                }
                if (this.pData.Message != null && this.pData.Message != string.Empty)
                {
                    this.OnCaseCallback(d.gcs(c._scmd_回传消息), this.pData.Message);
                    this.pData.Message = string.Empty;
                }
            }
            catch (Exception e)
            {
                this.OnCaseCallback(d.gcs(c._scmd_回传消息), "-" + e.Message);
            }
        }

        protected virtual void CaseService(string cmd, object[] ps)
        {
            throw new NotImplementedException();
        }
        object _lock = new object();
        public AutoResetEvent AsynCaseLogic(IUI ui, string cmd, params object[] ps)
        {
            AutoResetEvent are = new AutoResetEvent(false);
            Thread t = default(Thread);
            lock (_lock)
            {
                t = new Thread(() =>
                {
                    this.pipo.ShowPrograssBarState();
                    this.pData.pIsAsynchronism = true;
                    this.CaseLogic(cmd, ps);
                    this.eCaseCallback.Invoke(ui, cmd, null);
                    are.Set();
                    this.pData.pIsAsynchronism = false;
                });
                t.Start();
            }
            return are;
        }

        public event CaseCallbackEventHandler eCaseCallback;
        public IPropertyOperate pipo { get; set; }

        #endregion
        /// <summary>
        /// 同步时sender为空，异步时sender=Data.CurrentAsynUI ;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="cmd"></param>
        /// <param name="ps"></param>
        protected virtual void OnCaseCallback(string cmd, params object[] ps)
        {
            if (this.eCaseCallback != null)
            {
                this.eCaseCallback.Invoke(null, cmd, ps);
            }
        }
        public Data pData { get; set; }
        public IServer[] pServers { get; set; }
        public BCaseModelPorter[] pCaseModelPorters { get; set; }
        //
        public IServer GetServer(string name)
        {
            IServer s = default(IServer);
            foreach (var item in this.pServers)
            {
                if (item.GetType().Name == name)
                {
                    s = item;
                    break;
                }
            }
            return s;
        }
        protected BCaseModelPorter GetCaseModelPorter(string name)
        {
            BCaseModelPorter bco = default(BCaseModelPorter);
            foreach (var item in this.pCaseModelPorters)
            {
                if (item.GetType().Name == name)
                {
                    bco = item;
                    break;
                }
            }
            return bco;
        }
    }//class end border
    static class ex
    {
        public static object[] getsub(this object[] os, int start, int end)
        {
            if (os == null || start == end || os.Length < end) return null;
            object[] rs = new object[end - start];
            for (int i = 0; i < rs.Length; i++)
            {
                rs[i] = os.GetValue(i + start);
            }
            return rs;
        }
    }
}
