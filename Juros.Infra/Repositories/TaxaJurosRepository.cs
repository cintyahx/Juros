using Juros.Domain.Entities;
using Juros.Domain.Interfaces;
using Juros.Infra.Context;
using System.Linq;

namespace Juros.Infra.Repositories
{
    public class TaxaJurosRepository : BaseRepository<TaxaJuros>, ITaxaJurosRepository
    {
        public TaxaJurosRepository(JurosContext context) : base(context)
        {
        }

        public TaxaJuros GetLast()
        {
            return _context.TaxaJuros.OrderByDescending(x => x.CreatedDate).SingleOrDefault();
        }
    }
}
