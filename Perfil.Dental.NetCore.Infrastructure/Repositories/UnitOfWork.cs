using Perfil.Dental.NetCore.Application.Interfaces.Repositories;

namespace Perfil.Dental.NetCore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IClienteRepository clienteRepository,
            ITratamientoRepository tratamientoRepository,
            IAtencionRepository atencionRepository,
            IOrtodonciaRepository ortodonciaRepository
        )
        {
            Cliente = clienteRepository;
            Tratamiento = tratamientoRepository;
            Atencion = atencionRepository;
            Ortodoncia = ortodonciaRepository;
        }
        public IClienteRepository Cliente { get; }
        public ITratamientoRepository Tratamiento { get; }
        public IAtencionRepository Atencion { get; }
        public IOrtodonciaRepository Ortodoncia { get; }
    }
}
