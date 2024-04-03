using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Contracts.Queries;
using Perfil.Dental.NetCore.Application.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Repositories
{
    public interface IOrtodonciaRepository
    {
        Task<IEnumerable<OrtodonciaDataResponse>> GetSearchAsync();
        Task<OrtodonciaGetResponse> GetOneAsync(int nIdPaciente);
        Task<bool> CreateAsync(Ortodoncia request);
        Task<bool> CreateOrUpdateDetOrtodonciaAsync(DetOrtodoncia request);
        Task<IEnumerable<DetOrtodonciaDataResponse>> GetDetailAsync(DetOrtodonciaQuery filter);
    }
}
