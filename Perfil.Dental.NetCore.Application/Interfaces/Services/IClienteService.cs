using Perfil.Dental.Netcore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetSearchAsync();
        Task<bool> CreateOrUpdateAync(Cliente request);
        Task<Cliente> GetOneAsync(int nIdCliente);
        Task<IEnumerable<Provincia>> GetUbigeoAll();
    }
}
