using CurrencyConverterLibrary.Interfaces;
using CurrencyConverterLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Threading.Tasks;

namespace CurrencyConverterLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenExchangeRatesApi(this IServiceCollection serviceCollection, OpenExchangeRatesApiOptions options)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));

            serviceCollection.AddRefitClient<IOpenExchangeRatesApi>(new RefitSettings { AuthorizationHeaderValueGetter = () => Task.FromResult(options.ApiKey) })
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(options.BaseUrl));

            return serviceCollection;
        }
    }
}
