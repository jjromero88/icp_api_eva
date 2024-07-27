using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using FluentValidation.Results;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class ReportValidationManager
    {
        private readonly ReportTotalEntidadesrequestValidator _reportTotalEntidadesrequestValidator;

        public ReportValidationManager()
        {
            _reportTotalEntidadesrequestValidator = new ReportTotalEntidadesrequestValidator();
        }
         
        public ValidationResult Validate(ReportTotalEntidadesrequest entidad)
        {
            return _reportTotalEntidadesrequestValidator.Validate(entidad);
        }
    }
}
