using CurrencyConverterLibrary.Models.OpenExchangeRates;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverterLibrary.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync(CancellationToken cancellationToken = default);

        Task<double> GetConversionAsync(string fromCurrency, string toCurrency, int amount, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
    }
}
