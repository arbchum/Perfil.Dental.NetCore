using Perfil.Dental.Netcore.Domain.Entities;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Services
{
    public class TratamientoService: ITratamientoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TratamientoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tratamiento>> GetSearchAsync()
        {
            var response = await _unitOfWork.Tratamiento.GetSearchAsync();
            return response;
        }
        public async Task<bool> CreateOrUpdateAync(Tratamiento request)
        {
            var response = await _unitOfWork.Tratamiento.CreateOrUpdateAync(request);
            return response;
        }
    }
}
