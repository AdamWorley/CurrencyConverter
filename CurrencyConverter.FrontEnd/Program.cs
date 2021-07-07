using CurrencyConverter.Api.Extensions;
using CurrencyConverter.FrontEnd.Interfaces;
using CurrencyConverter.FrontEnd.Models;
using CurrencyConverter.FrontEnd.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.FrontEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var currencyServiceApiOptions = new CurrencyServiceApiOptions { BaseUrl = "http://localhost:5000" };

            builder.Services.AddCurrencyServiceApi(currencyServiceApiOptions);

            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<ICurrencyServiceApi, CurrencyServiceApi>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
