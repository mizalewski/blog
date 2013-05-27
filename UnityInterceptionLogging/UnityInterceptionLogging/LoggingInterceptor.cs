using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LinFu.DynamicProxy;

namespace UnityInterceptionLogging
{
    public class LoggingInterceptor : IInterceptor
    {
        /// <summary>
        /// Intercepts the specified info.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        object IInterceptor.Intercept(InvocationInfo info)
        {
            Debug.WriteLine("-- LOG: {0}.{1} --", info.Target.GetType().Name, info.TargetMethod.Name);
            return info;
        }
    }
}
