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
            services.AddTransient<IValidator<AuthorizeRequestDto>, AuthorizeRequestValidator>();
            services.AddTransient<AccountValidationManager>();

            services.AddTransient<IValidator<EntidadOficialIdRequestDto>, EntidadOficialIdRequestValidator>();
            services.AddTransient<IValidator<EntidadOficialInsertRequestDto>, EntidadOficialInsertRequestValidator>();
            services.AddTransient<IValidator<EntidadOficialUpdateRequestDto>, EntidadOficialUpdateRequestValidator>();
            services.AddTransient<EntidadOficialValidationManager>();

            services.AddTransient<IValidator<EntidadCoordinadorIdRequestDto>, EntidadCoordinadorIdRequestValidator>();
            services.AddTransient<IValidator<EntidadCoordinadorInsertRequestDto>, EntidadCoordinadorInsertRequestValidator>();
            services.AddTransient<IValidator<EntidadCoordinadorUpdateRequestDto>, EntidadCoordinadorUpdateRequestValidator>();
            services.AddTransient<EntidadCoordinadorValidationManager>();

            services.AddTransient<IValidator<EntidadIdRequestDto>, EntidadIdRequestValidator>();
            services.AddTransient<EntidadValidationManager>();

            return services;
        }
    }
}
