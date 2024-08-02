using FluentValidation.Results;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class MedioVerificacionValidationManager
    {
        private readonly MedioVerificacionDocumentUploadRequestValidator _medioVerificacionDocumentUploadRequestValidator;

        public MedioVerificacionValidationManager()
        {
            _medioVerificacionDocumentUploadRequestValidator = new MedioVerificacionDocumentUploadRequestValidator();
        }

        public ValidationResult Validate(MedioVerificacionDocumentUploadRequest entidad)
        {
            return _medioVerificacionDocumentUploadRequestValidator.Validate(entidad);
        }
    }
}
