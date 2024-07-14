using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class UbigeoApplication : IUbigeoApplication
    {
        private readonly IUbigeoService _ubigeoService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UbigeoApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public UbigeoApplication(
            IUbigeoService ubigeoService, 
            IMapper mapper, 
            IAppLogger<UbigeoApplication> logger, 
            IUserSessionService userSessionService)
        {
            _ubigeoService = ubigeoService;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetListDepartamento()
        {
            try
            {
                // obtenemos el token de la sesion
                string token = _userSessionService.GetToken();

                // consumimos el servicio de seguridad para el authorize
                var response = await _ubigeoService.GetListDepartamentos(token);

                return response != null ? ResponseUtil.Ok(response, TransactionMessage.QuerySuccess
                  ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetListProvincia(Request<ProvinciaFilterRequest> request)
        {
            try
            {
                // obtenemos el token de la sesion
                string token = _userSessionService.GetToken();

                // mapeamos la clase dto al tipo request
                var requestGetList = _mapper.Map<ProvinciaFilterRequest>(request.entidad);

                // consumimos el servicio de seguridad para el authorize
                var response = await _ubigeoService.GetListProvincias(requestGetList, token);

                return response != null ? ResponseUtil.Ok(response, TransactionMessage.QuerySuccess
                  ) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> GetListDistrito(Request<DistritoFilterRequest> request)
        {
            try
            {
                // obtenemos el token de la sesion
                string token = _userSessionService.GetToken();

                // mapeamos la clase dto al tipo request
                var requestGetList = _mapper.Map<DistritoFilterRequest>(request.entidad);

                // consumimos el servicio de seguridad para el authorize
                var response = await _ubigeoService.GetListDistritos(requestGetList, token);

                return response != null ? ResponseUtil.Ok(response, TransactionMessage.QuerySuccess
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
