using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Aplicacion.Validator;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class EntidadCoordinadorApplication : IEntidadCoordinadorApplication
    {
        private readonly IEntidadCoordinadorService _entidadCoordinadorService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadCoordinadorApplication> _logger;
        private readonly EntidadCoordinadorValidationManager _entidadCoordinadorValidationManager;
        private readonly IUserSessionService _userSessionService;

        public EntidadCoordinadorApplication(
            IEntidadCoordinadorService entidadCoordinadorService, 
            IMapper mapper, 
            IAppLogger<EntidadCoordinadorApplication> logger, 
            EntidadCoordinadorValidationManager entidadCoordinadorValidationManager, 
            IUserSessionService userSessionService)
        {
            _entidadCoordinadorService = entidadCoordinadorService;
            _mapper = mapper;
            _logger = logger;
            _entidadCoordinadorValidationManager = entidadCoordinadorValidationManager;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> Insert(Request<EntidadCoordinadorInsertRequestDto> request)
        {
            try
            {
                var validation = _entidadCoordinadorValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestUpdate = _mapper.Map<EntidadCoordinadorInsertRequest>(request.entidad);

                var response = await _entidadCoordinadorService.Insert(requestUpdate, _userSessionService.GetToken());

                _logger.LogInformation(message: TransactionMessage.SaveSuccess);
                return ResponseUtil.Created(message: TransactionMessage.SaveSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> Update(Request<EntidadCoordinadorUpdateRequestDto> request)
        {
            try
            {
                var validation = _entidadCoordinadorValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestUpdate = _mapper.Map<EntidadCoordinadorUpdateRequest>(request.entidad);

                var response = await _entidadCoordinadorService.Update(requestUpdate, _userSessionService.GetToken());

                _logger.LogInformation(message: TransactionMessage.UpdateSuccess);
                return ResponseUtil.Created(message: TransactionMessage.UpdateSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> Delete(Request<EntidadCoordinadorIdRequestDto> request)
        {
            try
            {
                var validation = _entidadCoordinadorValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestDelete = _mapper.Map<EntidadCoordinadorIdRequest>(request.entidad);

                var response = await _entidadCoordinadorService.Delete(requestDelete, _userSessionService.GetToken());

                _logger.LogInformation(message: TransactionMessage.DeleteSuccess);
                return ResponseUtil.Created(message: TransactionMessage.DeleteSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetById(Request<EntidadCoordinadorIdRequestDto> request)
        {
            try
            {
                var validation = _entidadCoordinadorValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestGetById = _mapper.Map<EntidadCoordinadorIdRequest>(request.entidad);

                var response = await _entidadCoordinadorService.GetById(requestGetById, _userSessionService.GetToken());

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<EntidadCoordinadorResponseDto>(response), TransactionMessage.QuerySuccess
                  ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetList(Request<EntidadCoordinadorFilterRequestDto> request)
        {
            try
            {
                var requestGetList = _mapper.Map<EntidadCoordinadorFilterRequest>(request.entidad);

                var response = await _entidadCoordinadorService.GetList(requestGetList, _userSessionService.GetToken());

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<List<EntidadCoordinadorResponseDto>>(response), TransactionMessage.QuerySuccess
                  ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
    }
}
