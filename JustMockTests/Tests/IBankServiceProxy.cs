namespace Tests
{
    /// <summary>
    /// Proxy for bank service.
    /// </summary>
    public interface IBankServiceProxy
    {
        /// <summary>
        /// Gets the currencies.
        /// </summary>
        /// <returns>Currencies.</returns>
        Currency[] GetCurrencies();
    }
}
