using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Perfil.Dental.NetCore.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClienteDto>> GetSearchAsync()
        {
            var response = await _unitOfWork.Cliente.GetSearchAsync();
            return response;
        }

        public async Task<bool> CreateOrUpdateAync(Cliente request)
        {
            var response = await _unitOfWork.Cliente.CreateOrUpdateAync(request);
            return response;
        }

        public async Task<Cliente> GetOneAsync(int nIdCliente)
        {
            var response = await _unitOfWork.Cliente.GetOneAsync(nIdCliente, null);
            return response;
        }

        public async Task<Cliente> GetOneByDocumentAsync(string sNroDocumento)
        {
            var response = await _unitOfWork.Cliente.GetOneAsync(null, sNroDocumento);
            return response;
        }
        public async Task<IEnumerable<Provincia>> GetUbigeoAll()
        {
            var listado = await _unitOfWork.Cliente.GetUbigeoAll();
            var provinciasGrouped = listado.GroupBy(item => item.nIdProv).Select(g => g.First()).ToList();

            var provincias = provinciasGrouped
                .Select(item => new Provincia()
                {
                    nIdUbigeo = item.nIdProv,
                    sNombre = item.sNomProv,
                    Distritos = listado
                    .Where(x => x.nIdProv == item.nIdProv)
                    .Select(item => new Distrito() { nIdUbigeo = item.nIdDist, sNombre = item.sNomDist })
                    .ToList()
                })
                .ToList();
            return provincias;
        }

    }
}
