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

    public class AuthorizeRequestValidator : AbstractValidator<AuthorizeRequestDto>
    {
        public AuthorizeRequestValidator()
        {
            RuleFor(u => u.idsession)
                 .IsNullOrWhiteSpace()
                 .WithMessage("Debe ingresar el id de sesion");

            RuleFor(u => u.codigo_perfil)
                .IsNullOrWhiteSpace()
                .WithMessage("Debe seleccionar un perfil");

            RuleFor(x => x.idsession)
                .MaximumLength(100)
                .WithMessage("El codigo debe tener máximo 100 caracteres");

            RuleFor(x => x.codigo_perfil)
               .MaximumLength(10)
               .WithMessage("La abreviatura debe tener máximo 10 caracteres");
        }
    }
}
