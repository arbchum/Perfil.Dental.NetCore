using Microsoft.Extensions.DependencyInjection;
using Perfil.Dental.NetCore.Application.Interfaces.Services;
using Perfil.Dental.NetCore.Application.Services;

namespace Perfil.Dental.NetCore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITratamientoService, TratamientoService>();
            services.AddScoped<IAtencionService, AtencionService>();
            services.AddScoped<IOrtodonciaService, OrtodonciaService>();
            return services;
        }
    }
}
