using FluentValidation;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequestDto>
    {
        public AuthenticateRequestValidator()
        {
        RuleFor(u => u.username)
        .IsNullOrWhiteSpace()
        .WithMessage($"Debe ingresar el nombre de usuario")
        .NotContainSqlInjection();

        RuleFor(u => u.password)
        .IsNullOrWhiteSpace()
        .WithMessage($"Debe ingresar una contraseña")
        .NotContainSqlInjection();

        RuleFor(x => x.username)
        .MaximumLength(20)
        .WithMessage($"El nombre de usuario debe tener máximo 20 caracteres");

        RuleFor(x => x.password)
        .MaximumLength(15)
        .WithMessage($"La contraseña debe tener máximo 15 caracteres");
        }
    }
}
