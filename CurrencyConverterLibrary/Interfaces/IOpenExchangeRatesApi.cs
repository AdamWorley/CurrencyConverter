using CurrencyConverterLibrary.Models.OpenExchangeRates;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverterLibrary.Interfaces
{
    [Headers("Authorization: Bearer")]
    public interface IOpenExchangeRatesApi
    {
        [Get("/latest.json")]
        Task<ExchangeRates> GetExchangeRatesAsync(CancellationToken cancellationToken = default);

        [Get("/convert/{amount}/{fromCurrency}/{toCurrency}")]
        Task<ConversionResponse> GetConversion(string fromCurrency, string toCurrency, int amount, CancellationToken cancellationToken = default);
    }
}
