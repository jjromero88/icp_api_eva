using FluentValidation;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{

    public class ReportTotalEntidadesrequestValidator : AbstractValidator<ReportTotalEntidadesrequest>
    {
        public ReportTotalEntidadesrequestValidator()
        {
            RuleFor(u => u.format)
            .IsNullOrWhiteSpace()
            .WithMessage($"Debe ingresar el nombre del formato del documento. Ejempolo: pdf, word, excel")
            .NotContainSqlInjection();

            RuleFor(x => x.format)
            .MaximumLength(5)
            .WithMessage($"El nombre del formato no debe ser mayor que 5 caracteres");

        }
    }
}
