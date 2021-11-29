using Juros.Domain.Dtos;
using Juros.Domain.Entities;
using Juros.Util;
using System.Threading.Tasks;

namespace Juros.Service
{
    public interface ITaxaJurosService
    {
        Task<Result<TaxaJuros>> AddAsync(TaxaJurosDto jurosDto);
        TaxaJuros GetLast();
    }
}
