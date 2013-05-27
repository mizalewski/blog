namespace MefInterception.Interception
{
    /// <summary>
    /// Parameter item contains parameter name, type and value.
    /// </summary>
    public class ParameterItem
    {
        /// <summary>
        /// Parameter name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parameter type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Argument value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">Type type name.</param>
        /// <param name="value">The argument value.</param>
        public ParameterItem(string name, string type, object value)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
        }
    }
}
