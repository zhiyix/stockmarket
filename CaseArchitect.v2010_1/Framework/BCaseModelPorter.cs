using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framework
{
    public class BCaseModelPorter
    {
        public BCaseModelPorter(Data data)
        {
            this.data = data;
        }
        protected Data data;
        public event CaseCallbackEventHandler eCaseCallback;
        public virtual void Port(string cmd, params object[] ps) { }
        protected virtual void OnCaseCallback(string cmd, params object[] ps)
        {
            if (this.eCaseCallback != null)
            {
                this.eCaseCallback.Invoke(null, cmd, ps);
            }
        }
        public event Func<string, IServer> GetServer;
        protected virtual IServer OnGetServer(string copName)
        {
            IServer s = default(IServer);
            if (this.GetServer != null) s = this.GetServer.Invoke(copName);
            return s;
        }
        public virtual void ServerSelected() { }
        #region static members
        public static Func<object, object> CmRelevancyHandle;
        #endregion
    }//class end border
}
