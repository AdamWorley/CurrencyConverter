using CurrencyConverter.Library.Models.OpenExchangeRates;
using CurrencyConverterLibrary.Interfaces;
using CurrencyConverterLibrary.Services;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CurrencyConverter.Tests.IntegrationTests
{
    public class CurrencyServiceTests
    {
        private readonly ICurrencyService _sut;

        public CurrencyServiceTests()
        {
            var logger = new NullLogger<CurrencyService>();

            var configuration = new ConfigurationBuilder()
            .AddUserSecrets<CurrencyServiceTests>()
            .Build();

            var openExchangeRatesApiOptions = new OpenExchangeRatesApiOptions();
            configuration.GetSection("OpenExchangeRates").Bind(openExchangeRatesApiOptions);

            var api = RestService.For<IOpenExchangeRatesApi>(new HttpClient(new AuthHeaderHandler(openExchangeRatesApiOptions.ApiKey)) { BaseAddress = new Uri(openExchangeRatesApiOptions.BaseUrl) });

            var memoryCache = Substitute.For<IMemoryCache>();

            memoryCache.TryGetValue(Arg.Any<object>(), out Arg.Any<object>()).Returns(c => { c[1] = null; return false; });

            _sut = new CurrencyService(logger, memoryCache, api);
        }

        [Fact]
        public async Task GetExchangeRatesAsync()
        {
            var response = await _sut.GetExchangeRatesAsync();

            response.Should().NotBeEmpty();
        }
    }
}
