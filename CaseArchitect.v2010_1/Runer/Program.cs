using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Runer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configure c = new Configures.Class1();
            c.Run();
        }
    }
}
