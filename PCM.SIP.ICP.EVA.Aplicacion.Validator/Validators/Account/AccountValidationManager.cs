using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using FluentValidation.Results;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class AccountValidationManager
    {
        private readonly AuthenticateRequestValidator _authenticateRequestValidator;

        public AccountValidationManager()
        {
            _authenticateRequestValidator = new AuthenticateRequestValidator();
        }

        public ValidationResult Validate(AuthenticateRequestDto entidad)
        {
            return _authenticateRequestValidator.Validate(entidad);
        }
    }
}
