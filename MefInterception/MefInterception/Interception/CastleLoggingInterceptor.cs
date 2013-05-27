using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using NLog;
using Newtonsoft.Json;

namespace MefInterception.Interception
{
    /// <summary>
    /// Castle logging interceptor.
    /// </summary>
    public class CastleLoggingInterceptor : IInterceptor
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

        public void Intercept(IInvocation invocation)
        {
            logger.Trace(() => this.WriteMethodNameWithParameters(invocation));
            invocation.Proceed();
        }

        /// <summary>
        /// Writes method name with parameters types and values.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Serialized to JSON method name with parameters types and values.</returns>
        private string WriteMethodNameWithParameters(IInvocation invocation)
        {
            LogItem item = new LogItem();
            item.AssemblyFullName = invocation.TargetType.Assembly.FullName;
            item.TypeFullName = invocation.TargetType.FullName;
            item.MethodName = invocation.Method.Name;
            item.ReturnType = invocation.Method.ReturnType.FullName;
            item.Parameters = this.GetParameters(invocation);
            this.UpdateGenericTypes(item, invocation);

            return JsonConvert.SerializeObject(item);
        }

        /// <summary>
        /// Gets method parameters types and values.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>Parameters types and values.</returns>
        private ParameterItem[] GetParameters(IInvocation invocation)
        {
            ParameterInfo[] parameters = invocation.Method.GetParameters();
            IList<ParameterItem> parametersTypes = new List<ParameterItem>();
            for (int i = 0; i < parameters.Length; ++i)
            {
                parametersTypes.Add(new ParameterItem(parameters[i].Name, parameters[i].ParameterType.FullName, invocation.GetArgumentValue(i)));
            }

            return parametersTypes.ToArray();
        }

        /// <summary>
        /// Updates method name with generic parameters if exists.
        /// </summary>
        /// <param name="item">The log item.</param>
        /// <param name="invocation">The invocation.</param>
        private void UpdateGenericTypes(LogItem item, IInvocation invocation)
        {
            if (invocation.GenericArguments != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (Type genericType in invocation.GenericArguments)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(genericType.FullName);
                }

                if (builder.Length > 0)
                {
                    item.TypeFullName = string.Format("{0}<{1}>", item.TypeFullName, builder);
                }
            }
        }
    }
}