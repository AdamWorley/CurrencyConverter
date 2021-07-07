using CurrencyConverterLibrary.CQRS.Queries;
using CurrencyConverterLibrary.Models.OpenExchangeRates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : BaseController
    {
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("/currencies")]
        public async Task<IEnumerable<string>> GetCurrencies()
        {
            return await Mediator.Send(new AvailableCurrencyQuery());
        }

        [HttpGet("/rates")]
        public async Task<IEnumerable<ExchangeRate>> Get()
        {
            return await Mediator.Send(new CurrentExchangeRatesQuery());
        }

        [HttpPost("/convert")]
        public async Task<double> GetConversionRequest([FromBody]GetConversionQuery conversionQuery)
        {
            return await Mediator.Send(conversionQuery);
        }
    }
}
