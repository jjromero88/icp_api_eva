using Microsoft.Extensions.DependencyInjection;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Infraestructure.Services;
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
            services.AddSingleton<IUserSessionService, UserSessionService>();
            services.AddSingleton<IEntidadService, EntidadService>();
            services.AddSingleton<IUbigeoService, UbigeoService>();
            services.AddSingleton<IDocumentoEstructuraService, DocumentoEstructuraService>();
            services.AddSingleton<IModalidadIntegridadService, ModalidadIntegridadService>();
            services.AddSingleton<IProfesionService, ProfesionService>();
            services.AddSingleton<IModalidadContratoService, ModalidadContratoService>();
            services.AddSingleton<IEntidadOficialService, EntidadOficialService>();
            services.AddSingleton<IEntidadCoordinadorService, EntidadCoordinadorService>();
            services.AddSingleton<IReportService, ReportService>();

            return services;
        }
    }
}
