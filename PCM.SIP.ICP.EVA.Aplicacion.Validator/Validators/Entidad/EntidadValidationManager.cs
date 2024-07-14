using FluentValidation.Results;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class EntidadValidationManager
    {
        private readonly EntidadIdRequestValidator _entidadIdRequestValidator;
        private readonly GeneralidadesUpdateRequestValidator _generalidadesUpdateRequestValidator;

        public EntidadValidationManager()
        {
            _entidadIdRequestValidator = new EntidadIdRequestValidator();
            _generalidadesUpdateRequestValidator = new GeneralidadesUpdateRequestValidator();
        }

        public ValidationResult Validate(EntidadIdRequestDto entidad)
        {
            return _entidadIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(GeneralidadesUpdateRequestDto entidad)
        {
            return _generalidadesUpdateRequestValidator.Validate(entidad);
        }

    }
}
