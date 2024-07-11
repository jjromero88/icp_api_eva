using FluentValidation;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Validator;

namespace PCM.SIP.ICP.EVA.Api.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AuthenticateRequestDto>, AuthenticateRequestValidator>();
            services.AddTransient<AccountValidationManager>();

            return services;
        }
    }
}
