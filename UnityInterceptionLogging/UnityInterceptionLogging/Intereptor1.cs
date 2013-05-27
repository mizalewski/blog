using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MefContrib.Hosting.Interception;

namespace UnityInterceptionLogging
{
    public class Intereptor1 : IExportedValueInterceptor
    {
        /// <summary>
        /// Intercepts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public object Intercept(object value)
        {
            return value;
        }
    }
}
