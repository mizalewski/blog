using System;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Diagnostics;

namespace Silverlight_Enterprise_Library_Logging.Logging
{
    /// <summary>
    /// Enterprise library logger facade.
    /// </summary>
    public class EnterpriseLibraryLoggerFacade : ILogFacade
    {
        private readonly LogWriter logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseLibraryLoggerFacade" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public EnterpriseLibraryLoggerFacade(LogWriter logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        public void Debug(Func<string> getMessage, params string[] categories)
        {
            this.Log(TraceEventType.Verbose, getMessage, categories);
        }

        /// <summary>
        /// Logs the information message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        public void Info(Func<string> getMessage, params string[] categories)
        {
            this.Log(TraceEventType.Information, getMessage, categories);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        public void Warn(Func<string> getMessage, params string[] categories)
        {
            this.Log(TraceEventType.Warning, getMessage, categories);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        public void Error(Func<string> getMessage, params string[] categories)
        {
            this.Log(TraceEventType.Error, getMessage, categories);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        public void Fatal(Func<string> getMessage, params string[] categories)
        {
            this.Log(TraceEventType.Critical, getMessage, categories);
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="getMessage">The get message.</param>
        /// <param name="categories">The categories.</param>
        private void Log(TraceEventType severity, Func<string> getMessage, string[] categories)
        {
            LogEntry entry = PrepareLogEntry(severity, categories);
            if (this.logger.ShouldLog(entry))
            {
                entry.Message = getMessage();
                this.logger.Write(entry);
            }
        }

        /// <summary>
        /// Prepares the log entry.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="categories">The categories.</param>
        /// <returns>Prepared log entry.</returns>
        private LogEntry PrepareLogEntry(TraceEventType severity, string[] categories)
        {
            LogEntry entry = new LogEntry();
            entry.Severity = severity;
            if (categories != null)
            {
                foreach (string category in categories)
                {
                    entry.Categories.Add(category);
                }
            }
            else
            {
                entry.Categories.Add("General");
            }

            return entry;
        }
    }
}
