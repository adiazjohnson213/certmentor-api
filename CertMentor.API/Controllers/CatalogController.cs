using CertMentor.Application.Interfaces.Catalog;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CertMentor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var certifications = await _catalogService.GetAllAsync(cancellationToken);
            return Ok(certifications);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code, CancellationToken cancellationToken)
        {
            var certification = await _catalogService.GetByCodeAsync(code, cancellationToken);
            if (certification == null)
            {
                return NotFound();
            }
            return Ok(certification);
        }

        [HttpPost("sync")]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            await _catalogService.SyncAsync(cancellationToken);
            return Ok();
        }
    }
}
