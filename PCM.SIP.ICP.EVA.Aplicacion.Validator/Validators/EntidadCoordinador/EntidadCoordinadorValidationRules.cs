using FluentValidation;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class EntidadCoordinadorIdRequestValidator : AbstractValidator<EntidadCoordinadorIdRequestDto>
    {
        public EntidadCoordinadorIdRequestValidator()
        {
            RuleFor(u => u.serialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la EntidadCoordinador");
        }
    }
    public class EntidadCoordinadorInsertRequestValidator : AbstractValidator<EntidadCoordinadorInsertRequestDto>
    {
        public EntidadCoordinadorInsertRequestValidator()
        {
            RuleFor(u => u.entidadkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar una entidad");

            RuleFor(u => u.modalidadkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar la modalidad de contrato");

            RuleFor(u => u.profesionkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe selecionar una profesión");

            RuleFor(u => u.nombres)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar los nombres");

            RuleFor(u => u.apellidos)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar los apellidos");

            RuleFor(u => u.fecha_inicio)
            .NotNull().WithMessage("Debe ingresar la fecha de inicio")
            .Must(fecha => fecha != DateTime.MinValue)
            .WithMessage("Debe ingresar una fecha válida");

            RuleFor(u => u.correo_institucional)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar la cuenta de correo");

            RuleFor(u => u.correo_institucional)
            .EmailAddress()
            .WithMessage("Debe ingresar un formato valido para el correo electróncio");

            RuleFor(x => x.nombres)
            .MaximumLength(80)
            .WithMessage("Los nombres debe tener máximo 80 caracteres");

            RuleFor(x => x.apellidos)
            .MaximumLength(80)
            .WithMessage("Los apellidos debe tener máximo 80 caracteres");

            RuleFor(x => x.nombres)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.apellidos)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("Los apellidos solo puede contener letras y espacios");

            RuleFor(x => x.correo_institucional)
            .MaximumLength(80)
            .WithMessage("El correo de documento debe tener máximo 80 caracteres");

            RuleFor(x => x.numero_celular)
            .MaximumLength(20)
            .WithMessage("El télefono móvil debe tener máximo 20 caracteres");
        }
    }
    public class EntidadCoordinadorUpdateRequestValidator : AbstractValidator<EntidadCoordinadorUpdateRequestDto>
    {
        public EntidadCoordinadorUpdateRequestValidator()
        {
            RuleFor(u => u.serialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la EntidadCoordinador");

            RuleFor(u => u.entidadkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar una entidad");

            RuleFor(u => u.modalidadkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar la modalidad de contrato");

            RuleFor(u => u.profesionkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe selecionar una profesión");

            RuleFor(u => u.nombres)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar los nombres");

            RuleFor(u => u.apellidos)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar los apellidos");

            RuleFor(u => u.fecha_inicio)
            .NotNull().WithMessage("Debe ingresar la fecha de inicio")
            .Must(fecha => fecha != DateTime.MinValue)
            .WithMessage("Debe ingresar una fecha válida");

            RuleFor(u => u.correo_institucional)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar la cuenta de correo");

            RuleFor(u => u.correo_institucional)
            .EmailAddress()
            .WithMessage("Debe ingresar un formato valido para el correo electróncio");

            RuleFor(x => x.nombres)
            .MaximumLength(80)
            .WithMessage("Los nombres debe tener máximo 80 caracteres");

            RuleFor(x => x.apellidos)
            .MaximumLength(80)
            .WithMessage("Los apellidos debe tener máximo 80 caracteres");

            RuleFor(x => x.nombres)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("El nombre solo puede contener letras y espacios");

            RuleFor(x => x.apellidos)
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
            .WithMessage("Los apellidos solo puede contener letras y espacios");

            RuleFor(x => x.correo_institucional)
            .MaximumLength(80)
            .WithMessage("El correo de documento debe tener máximo 80 caracteres");

            RuleFor(x => x.numero_celular)
            .MaximumLength(20)
            .WithMessage("El télefono móvil debe tener máximo 20 caracteres");
        }
    }
}
