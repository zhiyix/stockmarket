using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runer.Configures
{
    internal class Class1 : Configure
    {
        protected override void SetUICollection(params string[] uis)
        {
            base.SetUICollection("cui1");
        }
        protected override void SetCaseModelPorters(params string[] cmps)
        {
            base.SetCaseModelPorters("cm1");
        }
    }
}
