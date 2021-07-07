using CurrencyConverter.FrontEnd.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.FrontEnd.Interfaces
{
    interface ICurrencyServiceApi
    {
        Task<double> GetConversionAsync(GetConversionRequest request, CancellationToken cancellationToken = default);
        Task<List<string>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
    }
}
