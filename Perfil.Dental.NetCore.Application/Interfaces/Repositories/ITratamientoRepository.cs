using Perfil.Dental.Netcore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Repositories
{
    public interface ITratamientoRepository
    {
        Task<IEnumerable<Tratamiento>> GetSearchAsync();
        Task<bool> CreateOrUpdateAync(Tratamiento request);
    }
}
