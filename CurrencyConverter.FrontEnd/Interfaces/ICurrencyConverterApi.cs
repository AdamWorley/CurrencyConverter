﻿using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.FrontEnd.Interfaces
{
    public interface ICurrencyConverterApi
    {
        [Get("/currencies")]
        Task<List<string>> GetCurrenciesAsync(CancellationToken cancellationToken = default);
    }
}
