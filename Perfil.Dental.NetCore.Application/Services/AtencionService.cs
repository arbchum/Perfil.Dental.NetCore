using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Services
{
    public class AtencionService: IAtencionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AtencionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AtencionDto>> GetSearchAsync()
        {
            var response = await _unitOfWork.Atencion.GetSearchAsync();
            return response;
        }
        public async Task<bool> CreateAync(Atencion request)
        {
            var response = await _unitOfWork.Atencion.CreateAync(request);
            return response;
        }
        public async Task<IEnumerable<AtencionHistorico>> GetHistoricalAsync(int nIdCliente)
        {
            var response = await _unitOfWork.Atencion.GetHistoricalAsync(nIdCliente);
            return response;
        }
    }
}
