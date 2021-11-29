using Juros.Domain.Entities;

namespace Juros.Domain.Interfaces
{
    public interface ITaxaJurosRepository : IBaseRepository<TaxaJuros>
    {
        TaxaJuros GetLast();
    }
}
