using AutoMapper;
using Juros.Domain.Dtos;
using Juros.Domain.Entities;

namespace Juros.Domain.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TaxaJurosDto, TaxaJuros>()
                .ForMember(x => x.Taxa, opt => opt.MapFrom(y => y.Taxa / 100));
        }
    }
}
