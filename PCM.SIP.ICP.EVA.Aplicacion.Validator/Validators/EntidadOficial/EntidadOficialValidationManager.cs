using FluentValidation.Results;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class EntidadOficialValidationManager
    {
        private readonly EntidadOficialIdRequestValidator _entidadOficialIdRequestValidator;
        private readonly EntidadOficialInsertRequestValidator _entidadOficialInsertRequestValidator;
        private readonly EntidadOficialUpdateRequestValidator _entidadOficialUpdateRequestValidator;

        public EntidadOficialValidationManager()
        {
            _entidadOficialIdRequestValidator = new EntidadOficialIdRequestValidator();
            _entidadOficialInsertRequestValidator = new EntidadOficialInsertRequestValidator();
            _entidadOficialUpdateRequestValidator = new EntidadOficialUpdateRequestValidator();
        }

        public ValidationResult Validate(EntidadOficialIdRequestDto entidad)
        {
            return _entidadOficialIdRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadOficialInsertRequestDto entidad)
        {
            return _entidadOficialInsertRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(EntidadOficialUpdateRequestDto entidad)
        {
            return _entidadOficialUpdateRequestValidator.Validate(entidad);
        }
    }
}
