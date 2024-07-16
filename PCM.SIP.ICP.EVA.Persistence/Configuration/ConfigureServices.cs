using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Persistence;
using PCM.SIP.ICP.EVA.Persistence.Context;
using PCM.SIP.ICP.EVA.Persistence.Repository;
using PCM.SIP.ICP.EVA.Persistence.Repository.Base;

namespace PCM.SIP.ICP.EVA.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();
            services.AddScoped<IPreguntaRepository, PreguntaRepository>();

            return services;
        }
    }
}
