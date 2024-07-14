using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IEntidadApplication, EntidadApplication>();
            services.AddScoped<IUbigeoApplication, UbigeoApplication>();
            services.AddScoped<IDocumentoEstructuraApplication, DocumentoEstructuraApplication>();

            return services;
        }
    }
}
