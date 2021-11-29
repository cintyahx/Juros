using FluentAssertions;
using Juros.Application.Controllers;
using Juros.Domain.Entities;
using Juros.Domain.Tests;
using Juros.Service;
using Juros.Util;
using NSubstitute;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Juros.Application.Tests
{
    public class JurosControllerTests
    {
        private readonly ITaxaJurosService _taxaJurosService;
        private readonly JurosController _jurosController;
        private readonly TaxaJurosDtoBuilder _taxaJurosDtoBuilder;
        private readonly TaxaJurosBuilder _taxaJurosBuilder;

        public JurosControllerTests()
        {
            _taxaJurosService = Substitute.For<ITaxaJurosService>();

            _jurosController = new JurosController(_taxaJurosService);
            _taxaJurosDtoBuilder = new TaxaJurosDtoBuilder();
            _taxaJurosBuilder = new TaxaJurosBuilder();
        }

        [Fact]
        public void ShouldGetDefaultValueWhenNoExistsAnyTaxaJuros()
        {
            var result = _jurosController.Get();

            result.Should().Be(0);

        }

        [Theory]
        [InlineData(0.68)]
        [InlineData(588.84)]
        [InlineData(1)]
        [InlineData(0)]
        public void ShouldGetLastTaxaJurosTaxa(decimal taxa)
        {
            _taxaJurosService.GetLast().Returns(new TaxaJuros { Taxa = taxa });

            var result = _jurosController.Get();

            result.Should().Be(taxa);
        }

        [Theory]
        [InlineData(0.68)]
        [InlineData(588.84)]
        [InlineData(1)]
        [InlineData(0)]
        public async Task ShouldAddTaxaJurosWithSuccess(decimal taxa)
        {
            var taxajurosDtoFake =_taxaJurosDtoBuilder.WithTaxa(taxa).Build();

            var returnFake = new Result<TaxaJuros>
            {
                Data = _taxaJurosBuilder.WithTaxa(taxa).Build()
            };

            _taxaJurosService.AddAsync(taxajurosDtoFake).Returns(returnFake);

            var result = await _jurosController.AddAsync(taxajurosDtoFake);

        }
    }
}
