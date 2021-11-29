using System;

namespace Juros.Domain.Entities
{
    public class TaxaJuros : BaseEntity
    {
        public decimal Taxa { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
