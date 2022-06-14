using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Perfil.Dental.NetCore.Application.Interfaces.Repositories;
using Perfil.Dental.NetCore.Infrastructure.ExecuteCommands;
using Perfil.Dental.NetCore.Infrastructure.Infrastructure.ExecuteCommands;
using Perfil.Dental.NetCore.Infrastructure.Repositories;

namespace Perfil.Dental.NetCore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IExecuters>((provider) => new Executers(configuration.GetConnectionString("Default")));
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ITratamientoRepository, TratamientoRepository>(); 
                services.AddTransient<IAtencionRepository, AtencionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
