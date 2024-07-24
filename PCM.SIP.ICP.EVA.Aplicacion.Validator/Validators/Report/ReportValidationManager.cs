using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using FluentValidation.Results;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class ReportValidationManager
    {
        private readonly ReportRequestValidator _reportRequestValidator;

        public ReportValidationManager()
        {
            _reportRequestValidator = new ReportRequestValidator();
        }

        public ValidationResult Validate(ReportRequest entidad)
        {
            return _reportRequestValidator.Validate(entidad);
        }
    }
}
