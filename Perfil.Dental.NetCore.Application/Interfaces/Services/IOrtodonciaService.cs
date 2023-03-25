using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Services
{
    public interface IOrtodonciaService
    {
        Task<ApiResponse<IEnumerable<OrtodonciaDto>>> GetSearchAsync();
        Task<ApiResponse<bool>> CreateAsync(Ortodoncia request);
        Task<ApiResponse<IEnumerable<DetOrtodonciaDto>>> GetDetailAsync(int nIdOrtodoncia);
        Task<ApiResponse<bool>> CreateOrUpdateDetOrtodonciaAsync(DetOrtodoncia request);
    }
}
