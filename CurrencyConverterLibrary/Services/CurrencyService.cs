using CurrencyConverterLibrary.Interfaces;
using CurrencyConverterLibrary.Models.OpenExchangeRates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace CurrencyConverterLibrary.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ILogger<CurrencyService> _logger;
        private readonly IOpenExchangeRatesApi _currencyExchangeApi;
        private readonly IMemoryCache _cache;
        private const string _key = "exchangeRates";

        public CurrencyService(ILogger<CurrencyService> logger, IMemoryCache cache, IOpenExchangeRatesApi currencyLayerApi)
        {
            _logger = logger;
            _currencyExchangeApi = currencyLayerApi;
            _cache = cache;
        }

        public async Task<double> GetConversionAsync(string fromCurrency, string toCurrency, int amount, CancellationToken cancellationToken = default)
        {
            if(amount == 0)
            {
                return 0;
            }

            var exchangeRates = await GetExchangeRatesAsync(cancellationToken);

            var fromCurrencyRate = exchangeRates.First(x => x.ToCurrency.Equals(fromCurrency, StringComparison.InvariantCultureIgnoreCase));

            var toCurrencyRate = exchangeRates.First(x => x.ToCurrency.Equals(toCurrency, StringComparison.InvariantCultureIgnoreCase));

            return ConvertCurrencies(fromCurrencyRate, toCurrencyRate, amount);

        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync(CancellationToken cancellationToken = default)
        {
            if (_cache.TryGetValue(_key, out IEnumerable<ExchangeRate> exchangeRates))
            {
                _logger.LogInformation("Cache is still valid, returning cached exchange rates");
                return await Task.FromResult(exchangeRates);
            }

            var apiResponse = await _currencyExchangeApi.GetExchangeRatesAsync(cancellationToken);

            exchangeRates = apiResponse.Rates.Select(x => new ExchangeRate { FromCurrency = apiResponse.Base, ToCurrency = x.Key, Rate = x.Value });

            _logger.LogInformation("Refreshing cache");
            _cache.Set(_key, exchangeRates, TimeSpan.FromHours(1));

            return exchangeRates;
        }

        public static double ConvertCurrencies(ExchangeRate fromExchangeRate, ExchangeRate toExchangeRate, int amount)
        {
            if (amount == 0)
            {
                return 0;
            }

            // Doesn't exactly work with currencies that don't have decimals such a Japanese Yen - But produces the same result as the Google currency converter
            return Math.Round(( toExchangeRate.Rate / fromExchangeRate.Rate) * amount, 2);
        }

        public async Task<IEnumerable<string>> GetCurrenciesAsync(CancellationToken cancellationToken)
        {
            var exchangeRates = await GetExchangeRatesAsync(cancellationToken);

            return exchangeRates.Select(x => x.ToCurrency);
        }
    }
}
