using CurrencyConverterLibrary.CQRS.Queries;
using FluentValidation;

namespace CurrencyConverter.Library.Validators
{
    public class GetConversionQueryValidator : AbstractValidator<GetConversionQuery>
    {
        public GetConversionQueryValidator()
        {
            RuleFor(c => c.Amount).InclusiveBetween(int.MinValue, int.MaxValue);
            RuleFor(c => c.FromCurrency).Length(3);
            RuleFor(c => c.ToCurrency).Length(3);
        }
    }
}
