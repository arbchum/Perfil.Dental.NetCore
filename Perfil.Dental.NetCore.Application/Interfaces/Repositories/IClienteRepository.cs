using Perfil.Dental.Netcore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteDto>> GetSearchAsync();
        Task<bool> CreateOrUpdateAync(Cliente request);
        Task<Cliente> GetOneAsync(int nIdCliente);
        Task<IEnumerable<UbigeoDto>> GetUbigeoAll();
    }
}
