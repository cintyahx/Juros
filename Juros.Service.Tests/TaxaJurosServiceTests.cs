using AutoMapper;
using FluentAssertions;
using Juros.Domain.Dtos;
using Juros.Domain.Entities;
using Juros.Domain.Interfaces;
using Juros.Domain.Validators;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace Juros.Service.Tests
{
    public class TaxaJurosServiceTests
    {
        private readonly ITaxaJurosService _taxaJurosService;
        private readonly ITaxaJurosRepository _taxaJurosRepository;
        private readonly IMapper _mapper;

        public TaxaJurosServiceTests()
        {
            _taxaJurosRepository = Substitute.For<ITaxaJurosRepository>();
            _mapper = Substitute.For<IMapper>();
            var validator = new TaxaJurosValidator();

            _taxaJurosService = new TaxaJurosService(_taxaJurosRepository, validator, _mapper);

        }


        [Theory]
        [InlineData(17.78)]
        public async Task ShouldAddWithSuccess(decimal taxa)
        {
            var taxajurosFake = TaxaJurosServiceTestsHelper.TaxaJurosFake(taxa);
            _taxaJurosRepository.AddAsync(Arg.Any<TaxaJuros>()).Returns(taxajurosFake);

            var taxaJurosDto = new TaxaJurosDto
            {
                Taxa = taxa
            };

            var result = await _taxaJurosService.AddAsync(taxaJurosDto);

            result.Should().NotBeNull();
            result.Error.Should().BeFalse();
            result.Data.Should().NotBeNull();
            result.Data.Taxa.Should().Be(taxajurosFake.Taxa);
        }
    }
}
