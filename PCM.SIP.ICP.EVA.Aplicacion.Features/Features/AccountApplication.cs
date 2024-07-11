using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Aplicacion.Validator;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<AccountApplication> _logger;
        private readonly AccountValidationManager _accountValidationManager;
        private readonly IAccountService _accountService;

        public AccountApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<AccountApplication> logger, 
            AccountValidationManager accountValidationManager, 
            IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _accountValidationManager = accountValidationManager;
            _accountService = accountService;
        }

        public async Task<PcmResponse> Authenticate(Request<AuthenticateRequestDto> request)
        {
            try
            {
                //ejecutamos las validaciones
                var validation = _accountValidationManager.Validate(request.entidad);

                //verificamos si ocurrio un error de validacion
                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                // mapeamos la clase dto al tipo request
                var requestAuthenticate = _mapper.Map<AuthenticateRequest>(request.entidad);

                // consumimos el servicio de seguridad para el login
                var response = await _accountService.AuthenticateAsync(requestAuthenticate);

                return response != null ? ResponseUtil.Ok(
                    _mapper.Map<AuthenticateResponseDto>(response), AuthenticateMessage.AuthenticateSuccess
                   ) : ResponseUtil.Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }

        }

        public async Task<PcmResponse> Authorize(Request<AuthorizeRequestDto> request)
        {
            try
            {
                //ejecutamos las validaciones
                var validation = _accountValidationManager.Validate(request.entidad);

                //verificamos si ocurrio un error de validacion
                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                // mapeamos la clase dto al tipo request
                var requestAuthorize = _mapper.Map<AuthorizeRequest>(request.entidad);

                // consumimos el servicio de seguridad para el authorize
                var response = await _accountService.AuthorizeAsync(requestAuthorize);

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<AuthorizeResponseDto>(response), AuthenticateMessage.AuthenticateSuccess
                  ) : ResponseUtil.Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
    }
}
