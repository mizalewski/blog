using System;

namespace Tests
{
    /// <summary>
    /// Object extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Throws the argument out of range exception if object is null.
        /// </summary>
        /// <param name="obj">The object that will be tested.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        public static void ThrowArgumentOutOfRangeIfNull(this object obj, string parameterName, string message)
        {
            if (obj == null)
            {
                throw new ArgumentOutOfRangeException(parameterName, message);
            }
        }
    }
}
