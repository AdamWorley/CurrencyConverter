using System.Collections.Generic;

namespace CurrencyConverterLibrary.Models.OpenExchangeRates
{
    public class ExchangeRates
    {
        public string Disclaimer { get; set; }
        public string License { get; set; }
        public long Timestamp { get; set; }
        public string Base { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
