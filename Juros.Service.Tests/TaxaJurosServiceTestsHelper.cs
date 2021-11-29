using Juros.Domain.Entities;
using System;

namespace Juros.Service.Tests
{
    public static class TaxaJurosServiceTestsHelper
    {
        public static TaxaJuros TaxaJurosFake(decimal taxa)
        {
            return new TaxaJuros
            {
                Id = Guid.NewGuid(),
                Taxa = taxa / 100,
                CreatedDate = DateTime.Now
            };
        }
    }
}
