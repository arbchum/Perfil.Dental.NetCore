using Perfil.Dental.NetCore.Application.Interfaces.Repositories;

namespace Perfil.Dental.NetCore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IClienteRepository clienteRepository,
            ITratamientoRepository tratamientoRepository,
            IAtencionRepository atencionRepository
        )
        {
            Cliente = clienteRepository;
            Tratamiento = tratamientoRepository;
            Atencion = atencionRepository;
        }
        public IClienteRepository Cliente { get; }
        public ITratamientoRepository Tratamiento { get; }
        public IAtencionRepository Atencion { get; }
    }
}
