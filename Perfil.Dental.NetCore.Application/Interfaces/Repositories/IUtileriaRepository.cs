using System;
using System.Threading.Tasks;

namespace Perfil.Dental.NetCore.Application.Interfaces.Repositories
{
    public interface IUtileriaRepository
    {
        Task<bool> ExcepcionesSistema(Exception info, string metodo);
    }
}
