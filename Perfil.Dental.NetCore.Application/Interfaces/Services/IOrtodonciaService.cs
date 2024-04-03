using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Contracts.Queries;
using Perfil.Dental.NetCore.Application.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Services
{
    public interface IOrtodonciaService
    {
        Task<ApiResponse<IEnumerable<OrtodonciaDataResponse>>> GetSearchAsync();
        Task<ApiResponse<OrtodonciaGetResponse>> GetOneAsync(int nIdPaciente);
        Task<ApiResponse<bool>> CreateAsync(Ortodoncia request);
        Task<ApiResponse<IEnumerable<DetOrtodonciaDataResponse>>> GetDetailAsync(DetOrtodonciaQuery filter);
        Task<ApiResponse<bool>> CreateOrUpdateDetOrtodonciaAsync(DetOrtodoncia request);
    }
}
