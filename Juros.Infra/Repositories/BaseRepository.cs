using Juros.Domain.Entities;
using Juros.Domain.Interfaces;
using Juros.Infra.Context;
using System.Threading.Tasks;

namespace Juros.Infra.Repositories
{

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly JurosContext _context;

        public BaseRepository(JurosContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity model)
        {
            await _context.Set<TEntity>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
