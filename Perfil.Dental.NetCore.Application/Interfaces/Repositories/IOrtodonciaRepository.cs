using Perfil.Dental.Netcore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Repositories
{
    public interface IOrtodonciaRepository
    {
        Task<IEnumerable<OrtodonciaDto>> GetSearchAsync();
        Task<bool> CreateAsync(Ortodoncia request);
        Task<IEnumerable<DetOrtodonciaDto>> GetDetailAsync(int nIdOrtodoncia);
        Task<bool> CreateOrUpdateDetOrtodonciaAsync(DetOrtodoncia request);
    }
}
