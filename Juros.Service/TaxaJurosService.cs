using AutoMapper;
using FluentValidation;
using Juros.Domain.Dtos;
using Juros.Domain.Entities;
using Juros.Domain.Interfaces;
using Juros.Util;
using System.Threading.Tasks;

namespace Juros.Service
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly ITaxaJurosRepository _taxaJurosRepository;
        private readonly IValidator<TaxaJurosDto> _validator;
        private readonly IMapper _mapper;

        public TaxaJurosService(ITaxaJurosRepository taxaJurosRepository, IValidator<TaxaJurosDto> validator, IMapper mapper)
        {
            _taxaJurosRepository = taxaJurosRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<TaxaJuros>> AddAsync(TaxaJurosDto taxaJurosDto)
        {
            var validationResult = await _validator.ValidateAsync(taxaJurosDto);

            var result = new Result<TaxaJuros>();
            if (validationResult.IsValid)
            {
                var taxaJurosMap = _mapper.Map<TaxaJuros>(taxaJurosDto);
                result.Data = await _taxaJurosRepository.AddAsync(taxaJurosMap);
            }
            else
            {
                result.Error = true;
                result.Errors = validationResult.Errors;
            }

            return result;
        }

        public TaxaJuros GetLast()
        {
            return _taxaJurosRepository.GetLast();
        }
    }
}
