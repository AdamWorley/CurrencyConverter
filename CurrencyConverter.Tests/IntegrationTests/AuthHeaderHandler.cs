using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.Tests.IntegrationTests
{
    /// <summary>
    /// Only used to provide Auth header for testing
    /// </summary>
    internal class AuthHeaderHandler : DelegatingHandler
    {
        private readonly string _authToken;

        public AuthHeaderHandler(string authToken)
        {
            if (string.IsNullOrWhiteSpace(authToken))
            {
                throw new ArgumentException($"'{nameof(authToken)}' cannot be null or whitespace.", nameof(authToken));
            }

            _authToken = authToken;

            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
