namespace MefInterception.Interception
{
    /// <summary>
    /// Log item.
    /// </summary>
    public class LogItem
    {
        /// <summary>
        /// Full assembly name.
        /// </summary>
        public string AssemblyFullName { get; set; }

        /// <summary>
        /// Full type name.
        /// </summary>
        public string TypeFullName { get; set; }

        /// <summary>
        /// Method name.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Return type.
        /// </summary>
        public string ReturnType { get; set; }

        /// <summary>
        /// Parameters types and values.
        /// </summary>
        public ParameterItem[] Parameters { get; set; }
    }
}
