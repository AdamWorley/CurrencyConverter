namespace CurrencyConverterLibrary.Models.OpenExchangeRates
{
    public class ConversionResponse
    {
        public string Disclaimer { get; set; }
        public string License { get; set; }
        public Request Request { get; set; }
        public Meta Meta { get; set; }
        public double Response { get; set; }
    }


}
