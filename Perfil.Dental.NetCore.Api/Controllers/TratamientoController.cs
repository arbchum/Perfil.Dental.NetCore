using Microsoft.AspNetCore.Mvc;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private readonly ITratamientoService _tratamientoService;
        public TratamientoController(ITratamientoService tratamientoService)
        {
            _tratamientoService = tratamientoService;
        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<Tratamiento>> GetSearch()
        {
            var response = await _tratamientoService.GetSearchAsync();
            return response;
        }

        [HttpPost("[action]")]
        public async Task<bool> CreateOrUpdate([FromBody] Tratamiento request)
        {
            var response = await _tratamientoService.CreateOrUpdateAync(request);
            return response;
        }
    }
}
