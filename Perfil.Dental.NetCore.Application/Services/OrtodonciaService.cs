using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.Netcore.Domain.Enums;
using Perfil.Dental.NetCore.Application.Contracts.Queries;
using Perfil.Dental.NetCore.Application.Contracts.Responses;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System;
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

        public async Task<ApiResponse<IEnumerable<OrtodonciaDataResponse>>> GetSearchAsync()
        {
            var apiResponse = new ApiResponse<IEnumerable<OrtodonciaDataResponse>>()
            {
                Response = await _unitOfWork.Ortodoncia.GetSearchAsync(),
                Success = true
            };

            return apiResponse;
        }
        public async Task<ApiResponse<OrtodonciaGetResponse>> GetOneAsync(int nIdPaciente)
        {
            var apiResponse = new ApiResponse<OrtodonciaGetResponse>()
            {
                Response = await _unitOfWork.Ortodoncia.GetOneAsync(nIdPaciente),
                Success = true
            };

            return apiResponse;
        }
        public async Task<ApiResponse<bool>> CreateAsync(Ortodoncia request)
        {
            try
            {
                //throw new InvalidOperationException("Logfile cannot be read-only");
                var apiResponse = new ApiResponse<bool>();

                if (request?.nIdPaciente == 0)
                    apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "El código del paciente es requerido" });

                if (request?.nIdEstado == 0)
                    apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "El estado de la ortodoncia es requerido" });

                if (apiResponse.Errors.Count > 0)
                    return apiResponse;

                apiResponse.Response = await _unitOfWork.Ortodoncia.CreateAsync(request);
                apiResponse.Success = true;

                return apiResponse;
            }
            catch (Exception ex)
            {
                await _unitOfWork.Utileria.ExcepcionesSistema(ex, "OrtodonciaService: CreateAsync");
                throw ex;
            }
        }

        public async Task<ApiResponse<bool>> CreateOrUpdateDetOrtodonciaAsync(DetOrtodoncia request)
        {
            var apiResponse = new ApiResponse<bool>();

            if (request?.nIdPaciente == 0)
                apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "El Id del Paciente es requerido" });

            if (request?.dFechaControl == null)
                apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.BadRequest, Message = "La fecha de control es requerida" });

            if (apiResponse.Errors.Count > 0)
                return apiResponse;

            apiResponse.Response = await _unitOfWork.Ortodoncia.CreateOrUpdateDetOrtodonciaAsync(request);

            //if (!request.nIdDetOrtodoncia.HasValue)
            //{
            //    var resDetail = await _unitOfWork.Ortodoncia.GetDetailAsync(request.nIdOrtodoncia.Value);
            //    var cantidad = resDetail.Count();

            //    var requestOrtodoncia = new Ortodoncia()
            //    {
            //        nIdOrtodoncia = request.nIdOrtodoncia.Value,
            //        nIdEstado = EAtencionEstado.EnTratamiento,
            //        sNroSesion = cantidad
            //    };

            //    var resOrtodoncia = await _unitOfWork.Ortodoncia.CreateAsync(requestOrtodoncia);
            //    if (!resOrtodoncia)
            //    {
            //        apiResponse.Errors.Add(new ErrorResponse() { Code = HttpStatusCode.InternalServerError, Message = "No se pudo actualizar el estado de la Ortodoncia" });
            //        return apiResponse;
            //    }
            //}

            apiResponse.Success = true;
            return apiResponse;
        }

        public async Task<ApiResponse<IEnumerable<DetOrtodonciaDataResponse>>> GetDetailAsync(DetOrtodonciaQuery filter)
        {
            var apiResponse = new ApiResponse<IEnumerable<DetOrtodonciaDataResponse>>()
            {
                Response = await _unitOfWork.Ortodoncia.GetDetailAsync(filter),
                Success = true
            };

            return apiResponse;
        }

    }
}
