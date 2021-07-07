using CurrencyConverterLibrary.Interfaces;
using CurrencyConverterLibrary.Models.OpenExchangeRates;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverterLibrary.CQRS.Queries
{
    public class GetConversionQuery : IRequest<double>
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public int Amount { get; set; }

        public GetConversionQuery(string fromCurrency, string toCurrency, int amount)
        {
            FromCurrency = fromCurrency ?? throw new ArgumentNullException(nameof(fromCurrency));
            ToCurrency = toCurrency ?? throw new ArgumentNullException(nameof(toCurrency));
            Amount = amount;
        }

        internal class GetConversionQueryHandler : IRequestHandler<GetConversionQuery, double>
        {
            private readonly ILogger<GetConversionQueryHandler> _logger;
            private readonly ICurrencyService _currencyService;

            public GetConversionQueryHandler(ILogger<GetConversionQueryHandler> logger, ICurrencyService currencyService)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            }

            public async Task<double> Handle(GetConversionQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Getting live currency exchange rates");
                return await _currencyService.GetConversionAsync(request.FromCurrency, request.ToCurrency, request.Amount, cancellationToken);
            }
        }
    }
}
