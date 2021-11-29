using Juros.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Juros.Infra.Context
{
    public class JurosContext : DbContext
    {
        public DbSet<TaxaJuros> TaxaJuros { get; set; }

        public JurosContext(DbContextOptions<JurosContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JurosContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
