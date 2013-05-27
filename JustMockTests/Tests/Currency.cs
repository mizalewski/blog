namespace Tests
{
    /// <summary>
    /// Currency.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <param name="symbol">The currency symbol.</param>
        /// <param name="rate">The rate.</param>
        public Currency(string symbol, decimal rate)
        {
            this.Symbol = symbol;
            this.Rate = rate;
        }

        /// <summary>
        /// Gets the currency symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol { get; private set; }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public decimal Rate { get; private set; }
    }
}
