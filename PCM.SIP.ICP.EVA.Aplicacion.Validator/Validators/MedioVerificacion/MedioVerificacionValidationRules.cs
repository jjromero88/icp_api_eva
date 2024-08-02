using FluentValidation;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class MedioVerificacionDocumentUploadRequestValidator : AbstractValidator<MedioVerificacionDocumentUploadRequest>
    {
        public MedioVerificacionDocumentUploadRequestValidator()
        {
            RuleFor(x => x.filename)
           .NotEmpty().WithMessage("Debe ingresar el filename")
           .MaximumLength(500).WithMessage("El filename no puede ser mayor que 500 caracteres.");

            RuleFor(x => x.base64content)
            .NotEmpty().WithMessage("Debe ingresar el stringbase64 del documento");
        }
    }
}
