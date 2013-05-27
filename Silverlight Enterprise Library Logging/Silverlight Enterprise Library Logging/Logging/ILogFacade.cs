using System;

namespace Silverlight_Enterprise_Library_Logging.Logging
{
    /// <summary>
    /// Log facade.
    /// </summary>
    public interface ILogFacade
    {
        /// <summary>
        /// Logs the debug message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        void Debug(Func<string> getMessage, params string[] categories);

        /// <summary>
        /// Logs the information message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        void Info(Func<string> getMessage, params string[] categories);

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        void Warn(Func<string> getMessage, params string[] categories);

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        void Error(Func<string> getMessage, params string[] categories);

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="getMessage">The get message function.</param>
        /// <param name="categories">The categories.</param>
        void Fatal(Func<string> getMessage, params string[] categories);
    }
}
