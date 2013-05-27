using System;
using NUnit.Framework;
using Telerik.JustMock;

namespace Tests
{
    [TestFixture]
    public class CurrencyServiceFixture
    {
        private Currency[] currencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyServiceFixture" /> class.
        /// </summary>
        public CurrencyServiceFixture()
        {
            this.currencies = new Currency[]
            {
                new Currency("USD", 1.500m),
                new Currency("PLN", 4.000m),
                new Currency("GBP", 0.800m)
            };
        }

        [TestCase("USD", "GBP", 120.0, 64.0)]
        [TestCase("USD", "PLN", 60.0, 160.0)]
        [TestCase("PLN", "USD", 200.0, 75.0)]
        [TestCase("PLN", "GBP", 200.0, 40.0)]
        [TestCase("GBP", "USD", 80.0, 150.0)]
        [TestCase("GBP", "PLN", 30.0, 150.0)]
        public void ShouldExchangeAmountBetweenCurrencies(string sourceCurrencySymbol, string destinationCurrencySymbol, decimal amount, decimal expectedAmount)
        {
            IBankServiceProxy bankServiceProxyMock = Mock.Create<IBankServiceProxy>();
            Mock.Arrange(() => bankServiceProxyMock.GetCurrencies()).Returns(currencies);

            CurrencyService currencyService = new CurrencyService(bankServiceProxyMock);
            decimal amountAfterExchange = currencyService.Exchange(sourceCurrencySymbol, destinationCurrencySymbol, amount);

            Assert.AreEqual(expectedAmount, amountAfterExchange);
        }

        [TestCase("USD", "ABC")]
        [TestCase("ABC", "USD")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowArgumentOfRangeWhenCurrencyDoesntExists(string sourceCurrencySymbol, string destinationCurrencySymbol)
        {
            IBankServiceProxy bankServiceProxyMock = Mock.Create<IBankServiceProxy>();
            Mock.Arrange(() => bankServiceProxyMock.GetCurrencies()).Returns(currencies);

            CurrencyService currencyService = new CurrencyService(bankServiceProxyMock);
            currencyService.Exchange(sourceCurrencySymbol, destinationCurrencySymbol, 100);
        }
    }
}
