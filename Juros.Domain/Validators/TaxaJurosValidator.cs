using FluentValidation;
using Juros.Domain.Dtos;
using Juros.Domain.Resources;

namespace Juros.Domain.Validators
{
    public class TaxaJurosValidator : AbstractValidator<TaxaJurosDto>
    {
        public TaxaJurosValidator()
        {
            RuleFor(x => x.Taxa)
                .GreaterThanOrEqualTo(0).WithMessage(string.Format(ValidationResource.FieldMustBeGreaterThanOrEqualTo, FieldResource.Taxa, 0));
        }
    }
}
