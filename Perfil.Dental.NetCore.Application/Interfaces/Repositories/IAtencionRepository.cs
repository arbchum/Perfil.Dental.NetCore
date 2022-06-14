using Perfil.Dental.Netcore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Repositories
{
    public interface IAtencionRepository
    {
        Task<IEnumerable<AtencionDto>> GetSearchAsync();
        Task<bool> CreateAync(Atencion request);
    }
}
