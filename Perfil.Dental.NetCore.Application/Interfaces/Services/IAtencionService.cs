using Perfil.Dental.Netcore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Services
{
    public interface IAtencionService
    {
        Task<IEnumerable<AtencionDto>> GetSearchAsync();
        Task<bool> CreateAync(Atencion request);
    }
}
