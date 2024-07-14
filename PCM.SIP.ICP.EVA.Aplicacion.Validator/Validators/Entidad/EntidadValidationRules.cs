using FluentValidation;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class EntidadIdRequestValidator : AbstractValidator<EntidadIdRequestDto>
    {
        public EntidadIdRequestValidator()
        {
            RuleFor(u => u.serialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe ingresar el Id de la Entidad");
        }
    }
    public class GeneralidadesUpdateRequestValidator : AbstractValidator<GeneralidadesUpdateRequestDto>
    {
        public GeneralidadesUpdateRequestValidator()
        {
            RuleFor(u => u.serialKey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar una entidad");

            RuleFor(u => u.ubigeokey)
           .IsNullOrWhiteSpace()
           .WithMessage("Debe seleccionar el distirto");

            RuleFor(u => u.documentoestructurakey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar el documento que aprueba la estructura orgánica");

            RuleFor(u => u.modalidadintegridadkey)
            .IsNullOrWhiteSpace()
            .WithMessage("Debe seleccionar el Tipo de modalidad con la que incorporan la funcion de integridad");

            RuleFor(x => x.num_servidores)
              .Must(CustomValidators.BeValidInteger)
              .WithMessage("El Número de servidores debe ser un número entero.");

        }
    }
}
