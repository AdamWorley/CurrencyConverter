using CurrencyConverterLibrary.Interfaces;
using CurrencyConverterLibrary.Models.OpenExchangeRates;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverterLibrary.CQRS.Queries
{
    public class CurrentExchangeRatesQuery : IRequest<IEnumerable<ExchangeRate>>
    {
        public CurrentExchangeRatesQuery() { }

        internal class CurrentExchangeRatesQueryHandler : IRequestHandler<CurrentExchangeRatesQuery, IEnumerable<ExchangeRate>>
        {
            private readonly ILogger<CurrentExchangeRatesQueryHandler> _logger;
            private readonly ICurrencyService _currencyService;

            public CurrentExchangeRatesQueryHandler(ILogger<CurrentExchangeRatesQueryHandler> logger, ICurrencyService currencyService)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            }

            public async Task<IEnumerable<ExchangeRate>> Handle(CurrentExchangeRatesQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Getting live currency exchange rates");
                return await _currencyService.GetExchangeRatesAsync(cancellationToken);
            }
        }
    }

    public class AvailableCurrencyQuery : IRequest<IEnumerable<string>>
    {
        public AvailableCurrencyQuery(){ }

        internal class AvailableCurrencyQueryHandler : IRequestHandler<AvailableCurrencyQuery, IEnumerable<string>>
        {
            private readonly ILogger<AvailableCurrencyQueryHandler> _logger;
            private readonly ICurrencyService _currencyService;

            public AvailableCurrencyQueryHandler(ILogger<AvailableCurrencyQueryHandler> logger, ICurrencyService currencyService)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            }

            public async Task<IEnumerable<string>> Handle(AvailableCurrencyQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Getting available currencies");
                return await _currencyService.GetCurrenciesAsync(cancellationToken);
            }
        }
    }
}
