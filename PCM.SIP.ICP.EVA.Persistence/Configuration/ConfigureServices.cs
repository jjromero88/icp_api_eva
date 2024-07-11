using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.EVA.Persistence.Context;

namespace PCM.SIP.ICP.EVA.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();

            return services;
        }
    }
}
