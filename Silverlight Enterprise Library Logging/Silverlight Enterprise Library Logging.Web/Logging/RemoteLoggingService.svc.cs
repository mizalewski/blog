using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using Microsoft.Practices.EnterpriseLibrary.Logging.Service;

namespace Silverlight_Enterprise_Library_Logging.Web.Logging
{
    [AspNetCompatibilityRequirementsAttribute(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RemoteLoggingService : ILoggingService
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Adds log entries into to the server log.
        /// </summary>
        /// <param name="entries">The client log entries to log in the server.</param>
        public void Add(LogEntryMessage[] entries)
        {
            MessageProperties messageProperties = OperationContext.Current.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string clientAddress = endpoint.Address != null ? endpoint.Address : string.Empty;

            foreach (LogEntryMessage entry in entries)
            {
                this.LogEntry(entry, clientAddress);
            }
        }

        /// <summary>
        /// Logs the entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="clientAddress">The client address.</param>
        private void LogEntry(LogEntryMessage entry, string clientAddress)
        {
            switch (entry.Severity)
            {
            	case TraceEventType.Critical:
                    logger.Fatal(() => this.FormatMessage(entry.Message, clientAddress));
                    break;

                case TraceEventType.Error:
                    logger.Error(() => this.FormatMessage(entry.Message, clientAddress));
                    break;

                case TraceEventType.Warning:
                    logger.Warn(() => this.FormatMessage(entry.Message, clientAddress));
                    break;

                case TraceEventType.Information:
                    logger.Info(() => this.FormatMessage(entry.Message, clientAddress));
                    break;

                case TraceEventType.Verbose:
                    logger.Debug(() => this.FormatMessage(entry.Message, clientAddress));
                    break;
            }
        }

        /// <summary>
        /// Formats the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="clientAddress">The client address.</param>
        /// <returns>Formatted message.</returns>
        private string FormatMessage(string message, string clientAddress)
        {
            return string.Format("IP: {0}, Message: {1}", message, clientAddress);
        }
    }
}
