using Juros.Domain.Entities;
using System;

namespace Juros.Domain.Tests
{
    public class TaxaJurosBuilder
    {
        private readonly TaxaJuros _taxaJuros;

        public TaxaJurosBuilder()
        {
            _taxaJuros = new TaxaJuros
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now
            };
        }


        public TaxaJurosBuilder WithTaxa(decimal taxa)
        {
            _taxaJuros.Taxa = taxa;
            return this;
        }


        public TaxaJuros Build()
        {
            return _taxaJuros;
        }
    }
}
