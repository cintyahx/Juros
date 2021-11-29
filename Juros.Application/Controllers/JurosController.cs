using Juros.Domain.Dtos;
using Juros.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Juros.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JurosController : Controller
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public JurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        [HttpGet("taxaJuros")]
        public decimal Get()
        {
            var lastInterest = _taxaJurosService.GetLast();

            if (lastInterest == null)
                return 0;

            return lastInterest.Taxa;
        }

        [HttpPost("taxaJuros")]
        public async Task<IActionResult> AddAsync([FromBody] TaxaJurosDto taxaJurosDto)
        {
            var result = await _taxaJurosService.AddAsync(taxaJurosDto);

            if (!result.Error)
                return Created(Url.RouteUrl(result.Data.Id), result);

            return BadRequest(result);
        }
    }
}
