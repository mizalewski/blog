using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace UnityInterceptionLogging
{
    //[PartCreationPolicy(CreationPolicy.NonShared)]
    public class GenericClass<T> : IGenericInterface<T>
    {
        /// <summary>
        /// Method1s the specified param.
        /// </summary>
        /// <param name="param">The param.</param>
        public void Method1(T param)
        {
        }
    }
}
