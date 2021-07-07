using CurrencyConverterLibrary.Models.OpenExchangeRates;
using CurrencyConverterLibrary.Services;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CurrencyConverter.Tests
{
    public class CurrencyServiceTests
    {
        [Theory]
        [MemberData(nameof(GetExchangeRates))]
        public void ConvertCurrencies_GivenExchangeRates_ReturnsExpected(ExchangeRate fromExchangeRate, ExchangeRate toExchangeRate, int amount, double expected)
        {
            var result = CurrencyService.ConvertCurrencies(fromExchangeRate, toExchangeRate, amount);

            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetExchangeRates() =>
        new List<object[]>
        {
            new object[] { new ExchangeRate { FromCurrency = "USD", ToCurrency = "GBP", Rate = 0.725725 }, new ExchangeRate { FromCurrency = "USD", ToCurrency = "GBP", Rate = 0.725725 }, 0, 0 },
            new object[] { new ExchangeRate { FromCurrency = "USD", ToCurrency = "GBP", Rate = 0.725725 }, new ExchangeRate { FromCurrency = "USD", ToCurrency = "GBP", Rate = 0.725725 }, 5, 5 },
            new object[] { new ExchangeRate { FromCurrency = "USD", ToCurrency = "GBP", Rate = 0.725725 }, new ExchangeRate { FromCurrency = "USD", ToCurrency = "EUR", Rate = 0.846403 }, 1, 1.17 },
        };
    }
}
