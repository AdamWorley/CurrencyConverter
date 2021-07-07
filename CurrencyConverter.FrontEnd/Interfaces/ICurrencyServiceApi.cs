using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.FrontEnd.Interfaces
{
    interface ICurrencyServiceApi
    {
        Task<List<string>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
    }
}
