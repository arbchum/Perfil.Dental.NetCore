using Microsoft.AspNetCore.Mvc;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtencionController : ControllerBase
    {
        private readonly IAtencionService _atencionService;
        public AtencionController(IAtencionService atencionService)
        {
            _atencionService = atencionService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<AtencionDto>> GetSearch()
        {
            var response = await _atencionService.GetSearchAsync();
            return response;
        }

        [HttpPost("[action]")]
        public async Task<bool> Create([FromBody] Atencion request)
        {
            var response = await _atencionService.CreateAync(request);
            return response;
        }

        [HttpGet("[action]/{nIdCliente}")]
        public async Task<ActionResult<IEnumerable<AtencionHistorico>>> GetHistorical(int nIdCliente)
        {
            var response = await _atencionService.GetHistoricalAsync(nIdCliente);
            return Ok(response);
        }
    }
}
