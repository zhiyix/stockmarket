using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Action;
using Case;
using System.Reflection;
using Framework;

namespace Runer
{
    class Configure
    {
        internal void Run()
        {
            Form1.Run(this.mainWindow);
        }
        protected Form1 mainWindow;
        protected Dispatch dispatch;
        protected Data data;
        public Configure()
        {
            this.mainWindow = new Form1();
            //
            SetCase();
            SetData();
            SetService();
            //
            this.mainWindow.pData = dispatch.pData = this.data;
            this.dispatch.pData.ServiceNames = new List<string>();
            foreach (var item in this.dispatch.pServers)
            {
                this.dispatch.pData.ServiceNames.Add(item.GetType().FullName);
            }
            this.mainWindow.OriginalCase = dispatch;
            //
            SetUICollection();
            SetCommandHandler();
            SetCaseCallbackHandler();
            SetCaseModelPorters();
        }

        /// <summary>
        /// this.dispatch = new Case.Dispatchs.Class1();
        /// </summary>
        protected virtual void SetCase()
        {
            this.dispatch = new Case.Dispatchs.Class1();
            this.dispatch.pipo = (IPropertyOperate)this.mainWindow;
        }
        /// <summary>
        /// this.data = new Framework.CommonCaseData.Class1();
        /// </summary>
        protected virtual void SetData()
        {
            this.data = new Framework.Datas.Class1();
        }
        /// <summary>
        /// this.dispatch.pCaseModelPorters = AutoSerachpCaseModelPorters( cmps /*添加CaseModelPorter程序集字串*/ );
        /// </summary>
        /// <param name="cmps"></param>
        protected virtual void SetCaseModelPorters(params string[] cmps)
        {
            this.dispatch.pCaseModelPorters = AutoSerachpCaseModelPorters(cmps /*添加CaseModelPorter程序集字串*/ );
        }
        /// <summary>
        /// this.mainWindow.UIs = this.AutoSerachUIs( uis/*添加UI程序集字串*/ );
        /// </summary>
        /// <param name="uis"></param>
        protected virtual void SetUICollection(params string[] uis)
        {
            this.mainWindow.UIs = this.AutoSerachUIs(uis/*添加UI程序集字串*/ );
        }
        /// <summary>
        ///  this.mainWindow.CaseCallbackHandler = new Action.CaseCallbackHandlers.Class1(this.mainWindow.UIs,this.dispatch);
        /// </summary>
        protected virtual void SetCaseCallbackHandler()
        {
            this.mainWindow.CaseCallbackHandler = new Action.CaseCallbackHandlers.Class1(this.mainWindow.UIs, this.dispatch);
        }
        /// <summary>
        /// this.mainWindow.CommandHandler = new Action.CommandHandler.Class1(this.mainWindow.UIs,this.dispatch);
        /// </summary>
        protected virtual void SetCommandHandler()
        {
            this.mainWindow.CommandHandler = new Action.CommandHandler.Class1(this.mainWindow.UIs, this.dispatch);
        }
        /// <summary>
        ///    this.dispatch.pServers = new IServer[] { 
        ///       new Case.Service.Service1(),
        ///        new WCF.Class1()
        ///    }; 
        ///    List_IServer ls = new List_IServer();
        ///    ls.AddRange(this.dispatch.pServers);
        ///    return ls;
        /// </summary>
        protected virtual List<IServer> SetService()
        {
            this.dispatch.pServers = new IServer[] { 
                new Case.Service.Service1(),
                new WCF.wcfClass1(),
                new WCF.wsClass2()
            };
            List<IServer> ls = new List<IServer>();
            ls.AddRange(this.dispatch.pServers);
            return ls;
        }

        BCaseModelPorter[] AutoSerachpCaseModelPorters(params string[] ps)
        {
            BCaseModelPorter[] cmps = default(BCaseModelPorter[]);
            List<BCaseModelPorter> ls = new List<BCaseModelPorter>();
            foreach (var item in ps)
            {
                var v = Assembly.Load(item);
                foreach (var item2 in v.GetTypes())
                {
                    if (item2.IsSubclassOf(typeof(BCaseModelPorter)))
                    {
                        var cmp = item2.GetConstructor(new Type[] { typeof(Data) }).Invoke(new object[] { this.data }) as BCaseModelPorter;
                        cmp.eCaseCallback += this.mainWindow.CaseCallbackHandler.CaseCallbackHandler;
                        cmp.GetServer += this.dispatch.GetServer;
                        ls.Add(cmp);
                    }
                }
            }
            cmps = new BCaseModelPorter[ls.Count];
            ls.CopyTo(cmps);
            return cmps;
        }

        IUI[] AutoSerachUIs(params string[] ps)
        {
            List<IUI> ls = new List<IUI>();
            foreach (var item in ps)
            {
                var v = Assembly.Load(item);
                foreach (var item2 in v.GetTypes())
                {
                    if (item2.GetInterface("IUI") != null)
                    {
                        ls.Add(item2.GetConstructor(Type.EmptyTypes).Invoke(null) as IUI);
                    }
                }
            }
            IUI[] uis = new IUI[ls.Count];
            ls.CopyTo(uis);
            return uis;
        }
    }//cofigure end border
}
