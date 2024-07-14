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
    public class EntidadApplication : IEntidadApplication
    {
        private readonly IEntidadService _entidadService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadApplication> _logger;
        private readonly EntidadValidationManager _entidadValidationManager;
        private readonly IUserSessionService _userSessionService;

        public EntidadApplication(IEntidadService entidadService, IMapper mapper, IAppLogger<EntidadApplication> logger, EntidadValidationManager entidadValidationManager, IUserSessionService userSessionService)
        {
            _entidadService = entidadService;
            _mapper = mapper;
            _logger = logger;
            _entidadValidationManager = entidadValidationManager;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> UpdateGeneralidades(Request<GeneralidadesUpdateRequestDto> request)
        {
            try
            {
                //ejecutamos las validaciones
                var validation = _entidadValidationManager.Validate(request.entidad);

                //verificamos si ocurrio un error de validacion
                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                // mapeamos la clase dto al tipo request
                var requestUpdate = _mapper.Map<GeneralidadesUpdateRequest>(request.entidad);

                // consumimos el servicio de update entidad
                var response = await _entidadService.UpdateGeneralidades(requestUpdate, _userSessionService.GetToken());

                _logger.LogInformation(message: TransactionMessage.UpdateSuccess);
                return ResponseUtil.Created(message: TransactionMessage.UpdateSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetByIdGeneralidades(Request<EntidadIdRequestDto> request)
        {
            try
            {
                //ejecutamos las validaciones
                var validation = _entidadValidationManager.Validate(request.entidad);

                //verificamos si ocurrio un error de validacion
                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                // mapeamos la clase dto al tipo request
                var requestGetById = _mapper.Map<EntidadIdRequest>(request.entidad);

                // consumimos el servicio de GetById entidad
                var response = await _entidadService.GetByIdGeneralidades(requestGetById, _userSessionService.GetToken());

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<GeneralidadesResponseDto>(response), TransactionMessage.QuerySuccess
                  ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetListGeneralidades(Request<GeneralidadesFilterRequestDto> request)
        {
            try
            {
                // obtenemos el token de la sesion
                string token = _userSessionService.GetToken();

                // mapeamos la clase dto al tipo request
                var requestGetList = _mapper.Map<GeneralidadesFilterRequest>(request.entidad);

                // seteamos el id de la enidad
                requestGetList.serialKey = _userSessionService.GetUser().entidadkey;

                // si no se encuentra el id de la entidad
                if (string.IsNullOrEmpty(requestGetList.serialKey))
                {
                    _logger.LogError("GetListGeneralidades: No se encontró el id de la entidad");
                    return ResponseUtil.BadRequest("No se pudo encontrar el identificador de la entidad, intentelo nuevamente");
                }

                // consumimos el servicio de seguridad para el authorize
                var response = await _entidadService.GetListGeneralidades(requestGetList, token);

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<List<GeneralidadesResponseDto>>(response), TransactionMessage.QuerySuccess
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
