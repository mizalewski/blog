using System.Linq;

namespace Tests
{
    /// <summary>
    /// Currency service.
    /// </summary>
    public class CurrencyService
    {
        private readonly IBankServiceProxy bankServiceProxy;

        private Currency[] cachedCurrencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyService" /> class.
        /// </summary>
        /// <param name="bankServiceProxy">The bank service proxy.</param>
        public CurrencyService(IBankServiceProxy bankServiceProxy)
        {
            this.bankServiceProxy = bankServiceProxy;
        }

        /// <summary>
        /// Exchanges the specified amount between two currencies.
        /// </summary>
        /// <param name="sourceCurrencySymbol">The source currency symbol.</param>
        /// <param name="destinationCurrencySymbol">The destination currency symbol.</param>
        /// <param name="amount">The amount in source currency.</param>
        /// <returns>Exchanged amount in destination currency.</returns>
        public decimal Exchange(string sourceCurrencySymbol, string destinationCurrencySymbol, decimal amount)
        {
            if (this.cachedCurrencies == null)
            {
                this.cachedCurrencies = this.bankServiceProxy.GetCurrencies();
            }

            Currency sourceCurrency = this.cachedCurrencies.SingleOrDefault(c => c.Symbol.Equals(sourceCurrencySymbol));
            Currency destinationCurrency = this.cachedCurrencies.SingleOrDefault(c => c.Symbol.Equals(destinationCurrencySymbol));

            sourceCurrency.ThrowArgumentOutOfRangeIfNull("sourceCurrency", "Currency doesn't exists: " + sourceCurrencySymbol);
            destinationCurrency.ThrowArgumentOutOfRangeIfNull("destinationCurrency", "Currency doesn't exists: " + destinationCurrencySymbol);

            return (amount * destinationCurrency.Rate) / sourceCurrency.Rate;
        }
    }
}
