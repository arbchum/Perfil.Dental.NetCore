using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Contracts.Responses;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrtodonciaController : ControllerBase
    {
        private readonly IOrtodonciaService _ortodonciaService;
        public OrtodonciaController(IOrtodonciaService ortodonciaService)
        {
            _ortodonciaService = ortodonciaService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<IEnumerable<OrtodonciaDto>>>> GetSearch()
        {
            var response = await _ortodonciaService.GetSearchAsync();
            if(!response.Success)
            {
                return BadRequest(response.Errors);
            }
            return response;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<bool>>> Create([FromBody] Ortodoncia request)
        {
            var response = await _ortodonciaService.CreateAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }
            return response;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DetOrtodonciaDto>>>> GetDetail(int nIdOrtodoncia)
        {
            var response = await _ortodonciaService.GetDetailAsync(nIdOrtodoncia);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }
            return response;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<bool>>> CreateOrUpdateDetOrtodoncia([FromBody] DetOrtodoncia request)
        {
            var response = await _ortodonciaService.CreateOrUpdateDetOrtodonciaAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }
            return response;
        }
    }
}
