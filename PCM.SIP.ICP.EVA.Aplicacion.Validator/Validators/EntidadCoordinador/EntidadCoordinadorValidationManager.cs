using FluentValidation.Results;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class EntidadCoordinadorValidationManager
    {
        private readonly EntidadCoordinadorIdRequestValidator _EntidadCoordinadorIdRequestValidator;
        private readonly EntidadCoordinadorInsertRequestValidator _EntidadCoordinadorInsertRequestValidator;
        private readonly EntidadCoordinadorUpdateRequestValidator _EntidadCoordinadorUpdateRequestValidator;

        public EntidadCoordinadorValidationManager()
        {
            _EntidadCoordinadorIdRequestValidator = new EntidadCoordinadorIdRequestValidator();
            _EntidadCoordinadorInsertRequestValidator = new EntidadCoordinadorInsertRequestValidator();
            _EntidadCoordinadorUpdateRequestValidator = new EntidadCoordinadorUpdateRequestValidator();
        }

        public ValidationResult Validate(EntidadCoordinadorIdRequestDto entidad)
        {
            return _EntidadCoordinadorIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadCoordinadorInsertRequestDto entidad)
        {
            return _EntidadCoordinadorInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadCoordinadorUpdateRequestDto entidad)
        {
            return _EntidadCoordinadorUpdateRequestValidator.Validate(entidad);
        }
    }
}
