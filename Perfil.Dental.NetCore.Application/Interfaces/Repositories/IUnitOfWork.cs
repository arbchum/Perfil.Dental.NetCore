namespace Perfil.Dental.NetCore.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IClienteRepository Cliente { get; }
        ITratamientoRepository Tratamiento { get; }
        IAtencionRepository Atencion { get; }
        IOrtodonciaRepository Ortodoncia { get; }
        IUtileriaRepository Utileria { get; }
    }
}
