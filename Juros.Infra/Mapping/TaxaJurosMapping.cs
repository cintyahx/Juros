using Juros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Juros.Infra.Mapping
{
    public class TaxaJurosMapping : IEntityTypeConfiguration<TaxaJuros>
    {
        public void Configure(EntityTypeBuilder<TaxaJuros> builder)
        {
            builder.ToTable("TaxaJuros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Taxa)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();
        }
    }
}
