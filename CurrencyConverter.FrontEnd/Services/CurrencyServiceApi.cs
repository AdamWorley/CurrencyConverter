using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.FrontEnd.Interfaces;
using CurrencyConverterLibrary.CQRS.Queries;
using CurrencyConverter.FrontEnd.Models;
using System;

namespace CurrencyConverter.FrontEnd.Services
{
    public class CurrencyServiceApi : ICurrencyServiceApi
    {
        private readonly ICurrencyConverterApi _currencyServiceApi;

        public CurrencyServiceApi(ICurrencyConverterApi currencyServiceApi)
        {
            _currencyServiceApi = currencyServiceApi;
        }

        public async Task<List<string>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _currencyServiceApi.GetCurrenciesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //TODO: Handle Error Response In UI
                return new List<string> { ex.Message };
            }
        }

        public async Task<double> GetConversionAsync(GetConversionRequest request, CancellationToken cancellationToken = default)
        {
            var query = new GetConversionQuery(request.FromCurrency, request.ToCurrency, Convert.ToInt32(Math.Round(request.Amount * 100, 0)));

            var response = await _currencyServiceApi.GetConversionAsync(query, cancellationToken);

            return Math.Round(response / 100,2);
        }
    }
}
