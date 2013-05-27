using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace UnityInterceptionLogging
{
    [Export(typeof(ISampleInterface))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SampleClass : ISampleInterface
    {
        public void Method1(string str, int i)
        {
        	
        }
    }
}
