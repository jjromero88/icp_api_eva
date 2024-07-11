using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using FluentValidation.Results;

namespace PCM.SIP.ICP.EVA.Aplicacion.Validator
{
    public class AccountValidationManager
    {
        private readonly AuthenticateRequestValidator _authenticateRequestValidator;
        private readonly AuthorizeRequestValidator _authorizeRequestValidator;

        public AccountValidationManager()
        {
            _authenticateRequestValidator = new AuthenticateRequestValidator();
            _authorizeRequestValidator = new AuthorizeRequestValidator();
        }

        public ValidationResult Validate(AuthenticateRequestDto entidad)
        {
            return _authenticateRequestValidator.Validate(entidad);
        }
        public ValidationResult Validate(AuthorizeRequestDto entidad)
        {
            return _authorizeRequestValidator.Validate(entidad);
        }
    }
}
