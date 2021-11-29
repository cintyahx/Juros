using Juros.Domain.Entities;
using System.Threading.Tasks;

namespace Juros.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity model);
    }
}
