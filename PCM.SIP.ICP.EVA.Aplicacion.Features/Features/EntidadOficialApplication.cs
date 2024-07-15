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
    public class EntidadOficialApplication : IEntidadOficialApplication
    {
        private readonly IEntidadOficialService _entidadOficialService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadOficialApplication> _logger;
        private readonly EntidadOficialValidationManager _entidadOficialValidationManager;
        private readonly IUserSessionService _userSessionService;

        public EntidadOficialApplication(
            IEntidadOficialService entidadOficialService, 
            IMapper mapper, 
            IAppLogger<EntidadOficialApplication> logger, 
            EntidadOficialValidationManager entidadOficialValidationManager, 
            IUserSessionService userSessionService)
        {
            _entidadOficialService = entidadOficialService;
            _mapper = mapper;
            _logger = logger;
            _entidadOficialValidationManager = entidadOficialValidationManager;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> Insert(Request<EntidadOficialInsertRequestDto> request)
        {
            try
            {
                var validation = _entidadOficialValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestUpdate = _mapper.Map<EntidadOficialInsertRequest>(request.entidad);

                var response = await _entidadOficialService.Insert(requestUpdate, _userSessionService.GetToken());

                _logger.LogInformation(message: TransactionMessage.SaveSuccess);
                return ResponseUtil.Created(message: TransactionMessage.SaveSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> Update(Request<EntidadOficialUpdateRequestDto> request)
        {
            try
            {
                var validation = _entidadOficialValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestUpdate = _mapper.Map<EntidadOficialUpdateRequest>(request.entidad);

                var response = await _entidadOficialService.Update(requestUpdate, _userSessionService.GetToken());

                _logger.LogInformation(message: TransactionMessage.UpdateSuccess);
                return ResponseUtil.Created(message: TransactionMessage.UpdateSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> Delete(Request<EntidadOficialIdRequestDto> request)
        {
            try
            {
                var validation = _entidadOficialValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestDelete = _mapper.Map<EntidadOficialIdRequest>(request.entidad);

                var response = await _entidadOficialService.Delete(requestDelete, _userSessionService.GetToken());

                _logger.LogInformation(message: TransactionMessage.DeleteSuccess);
                return ResponseUtil.Created(message: TransactionMessage.DeleteSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetById(Request<EntidadOficialIdRequestDto> request)
        {
            try
            {
                var validation = _entidadOficialValidationManager.Validate(request.entidad);

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                var requestGetById = _mapper.Map<EntidadOficialIdRequest>(request.entidad);

                var response = await _entidadOficialService.GetById(requestGetById, _userSessionService.GetToken());

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<EntidadOficialResponseDto>(response), TransactionMessage.QuerySuccess
                  ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetList(Request<EntidadOficialFilterRequestDto> request)
        {
            try
            {
                var requestGetList = _mapper.Map<EntidadOficialFilterRequest>(request.entidad);

                var response = await _entidadOficialService.GetList(requestGetList, _userSessionService.GetToken());

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<List<EntidadOficialResponseDto>>(response), TransactionMessage.QuerySuccess
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
