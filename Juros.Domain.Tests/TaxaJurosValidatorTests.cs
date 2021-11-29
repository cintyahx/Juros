using FluentAssertions;
using Juros.Domain.Validators;
using Xunit;

namespace Juros.Domain.Tests
{
    public class TaxaJurosValidatorTests
    {
        private readonly TaxaJurosDtoBuilder _taxaJurosDtoBuilder;
        private readonly TaxaJurosValidator _taxaJurosValidator;

        public TaxaJurosValidatorTests()
        {
            _taxaJurosDtoBuilder = new TaxaJurosDtoBuilder();
            _taxaJurosValidator = new TaxaJurosValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(15)]
        [InlineData(17.78)]
        [InlineData(1857.78)]
        [InlineData(18570446)]
        [InlineData(15.5488955)]
        public void TaxaJurosDtoShouldBeValid(decimal taxa)
        {
            var taxaJurosDto = _taxaJurosDtoBuilder.WithTaxa(taxa).Build();

            var resultValidation = _taxaJurosValidator.Validate(taxaJurosDto);

            resultValidation.Should().NotBeNull();
            resultValidation.IsValid.Should().BeTrue();
            resultValidation.Errors.Should().BeEmpty();

        }

        [Theory]
        [InlineData(-5480)]
        [InlineData(-54.9980)]
        public void TaxaJurosDtoShouldBeInvalid(decimal taxa)
        {
            var taxaJurosDto = _taxaJurosDtoBuilder.WithTaxa(taxa).Build();

            var resultValidation = _taxaJurosValidator.Validate(taxaJurosDto);

            resultValidation.Should().NotBeNull();
            resultValidation.IsValid.Should().BeFalse();
            resultValidation.Errors.Should().HaveCount(1);
            //resultValidation.Errors.Should().BeEquivalentTo(new List<ValidationFailure> { new ValidationFailure("", string.Format(ValidationResource.FieldMustBeGreaterThanOrEqualTo, FieldResource.Taxa, 0))) });
        }
    }
}
