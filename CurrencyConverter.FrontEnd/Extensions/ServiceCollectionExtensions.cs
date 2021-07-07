using CurrencyConverter.FrontEnd.Interfaces;
using CurrencyConverter.FrontEnd.Models;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace CurrencyConverter.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCurrencyServiceApi(this IServiceCollection serviceCollection, CurrencyServiceApiOptions options)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));

            serviceCollection.AddRefitClient<ICurrencyConverterApi>(new RefitSettings())
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(options.BaseUrl));

            return serviceCollection;
        }
    }
}
