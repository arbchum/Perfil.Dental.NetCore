using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Services
{
    public class ClienteService: IClienteService
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
            var response = await _unitOfWork.Cliente.GetOneAsync(nIdCliente);
            return response;
        }
    }
}
