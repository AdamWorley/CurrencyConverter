using CurrencyConverterLibrary.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.FrontEnd.Interfaces;
using System.Linq;

namespace CurrencyConverter.FrontEnd.Services
{
    public class CurrencyServiceApi : ICurrencyServiceApi
    {
        private readonly ICurrencyConverterApi _currencyServiceApi;
        private readonly IMemoryCache _cache;
        private const string _key = "exchangeRates";

        public CurrencyServiceApi(IMemoryCache cache, ICurrencyConverterApi currencyServiceApi)
        {
            _currencyServiceApi = currencyServiceApi;
            _cache = cache;
        }

        public async Task<List<string>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var foo =  await _currencyServiceApi.GetCurrenciesAsync(cancellationToken);
                return new List<string> { "USD", "EUR", foo };
            }
            catch (System.Exception ex)
            {
                return new List<string> { ex.Message };
            }
        }
    }
}
