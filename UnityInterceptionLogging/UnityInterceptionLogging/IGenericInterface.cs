using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace UnityInterceptionLogging
{
    [InheritedExport]
    public interface IGenericInterface<T>
    {
        void Method1(T param);
    }
}
