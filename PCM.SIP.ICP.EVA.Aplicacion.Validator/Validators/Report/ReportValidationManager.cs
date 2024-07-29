using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using FluentValidation.Results;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class ReportValidationManager
    {
        private readonly ReportResultadosEtapaRequestValidator _reportResultadosEtapaRequestValidator;
        private readonly ReportGrupoEntidadesRequestValidator _reportGrupoEntidadesRequestValidator;
        private readonly ReportEtapasComponenteRequestValidator _reportEtapasComponenteRequestValidator;

        public ReportValidationManager()
        {
            _reportResultadosEtapaRequestValidator = new ReportResultadosEtapaRequestValidator();
            _reportGrupoEntidadesRequestValidator = new ReportGrupoEntidadesRequestValidator();
            _reportEtapasComponenteRequestValidator = new ReportEtapasComponenteRequestValidator();
        }
         
        public ValidationResult Validate(ReportResultadosEtapaRequest entidad)
        {
            return _reportResultadosEtapaRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(ReportGrupoEntidadesRequest entidad)
        {
            return _reportGrupoEntidadesRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(ReportEtapasComponenteRequest entidad)
        {
            return _reportEtapasComponenteRequestValidator.Validate(entidad);
        }
    }
}
