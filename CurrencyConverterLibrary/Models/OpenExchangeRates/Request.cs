namespace CurrencyConverterLibrary.Models.OpenExchangeRates
{
    public class Request
    {
        public string Query { get; set; }
        public double Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
