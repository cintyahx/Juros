using Juros.Domain.Dtos;

namespace Juros.Domain.Tests
{
    public class TaxaJurosDtoBuilder
    {
        private readonly TaxaJurosDto _taxaJurosDto;

        public TaxaJurosDtoBuilder()
        {
            _taxaJurosDto = new TaxaJurosDto();
        }


        public TaxaJurosDtoBuilder WithTaxa(decimal taxa)
        {
            _taxaJurosDto.Taxa = taxa;
            return this;
        }


        public TaxaJurosDto Build()
        {
            return _taxaJurosDto;
        }
    }
}
