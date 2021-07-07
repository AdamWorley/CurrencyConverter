namespace CurrencyConverter.FrontEnd.Models
{
    public class GetConversionRequest
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
