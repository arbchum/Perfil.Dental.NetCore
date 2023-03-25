using Microsoft.AspNetCore.Mvc;
using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<ClienteDto>> GetSearch()
        {
            var response = await _clienteService.GetSearchAsync();
            return response;
        }

        [HttpPost("[action]")]
        public async Task<bool> CreateOrUpdate([FromBody] Cliente request)
        {
            var response = await _clienteService.CreateOrUpdateAync(request);
            return response;
        }

        [HttpGet("[action]/{nIdCliente}")]
        public async Task<Cliente> GetOne(int nIdCliente)
        {
            var response = await _clienteService.GetOneAsync(nIdCliente);
            return response;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Provincia>> GetUbigeoAll()
        {
            var response = await _clienteService.GetUbigeoAll();
            return response;
        }
    }
}
