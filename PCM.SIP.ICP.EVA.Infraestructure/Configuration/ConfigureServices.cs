using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Infraestructure.Services.Account;
using PCM.SIP.ICP.EVA.Infraestructure.Services.Security;

namespace PCM.SIP.ICP.EVA.Infraestructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<ISecurityService, SecurityService>();

            return services;
        }
    }
}
