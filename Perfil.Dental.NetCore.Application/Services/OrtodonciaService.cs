using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Contracts.Responses;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Services
{
    public class OrtodonciaService : IOrtodonciaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrtodonciaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<OrtodonciaDto>>> GetSearchAsync()
        {
            var apiResponse = new ApiResponse<IEnumerable<OrtodonciaDto>>()
            {
                Response = await _unitOfWork.Ortodoncia.GetSearchAsync(),
                Success = true
            };

            return apiResponse;
        }
        public async Task<ApiResponse<bool>> CreateAsync(Ortodoncia request)
        {
            var apiResponse = new ApiResponse<bool>();

            if (request?.nIdPaciente == 0)
            {
                apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "El código del paciente es requerido" });
                return apiResponse;
            }

            if (request?.dFechaInstalacion == null)
            {
                apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "La fecha de instalación es requerida" });
                return apiResponse;
            }

            request.DetOrtodoncia = request.DetOrtodoncia.OrderBy(item => item.dFechaControl).ToList();

            apiResponse.Response = await _unitOfWork.Ortodoncia.CreateAsync(request);
            apiResponse.Success = true;

            return apiResponse;
        }

        public async Task<ApiResponse<IEnumerable<DetOrtodonciaDto>>> GetDetailAsync(int nIdOrtodoncia)
        {
            var apiResponse = new ApiResponse<IEnumerable<DetOrtodonciaDto>>()
            {
                Response = await _unitOfWork.Ortodoncia.GetDetailAsync(nIdOrtodoncia),
                Success = true
            };

            return apiResponse;
        }

        public async Task<ApiResponse<bool>> CreateOrUpdateDetOrtodonciaAsync(DetOrtodoncia request)
        {
            var apiResponse = new ApiResponse<bool>();

            if (request?.nIdOrtodoncia == 0)
            {
                apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "El Id de la Ortodoncia es requerido" });
                return apiResponse;
            }

            if (request?.dFechaControl == null)
            {
                apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "La fecha de control es requerida" });
                return apiResponse;
            }

            apiResponse.Response = await _unitOfWork.Ortodoncia.CreateOrUpdateDetOrtodonciaAsync(request);
            apiResponse.Success = true;

            return apiResponse;
        }
    }
}
