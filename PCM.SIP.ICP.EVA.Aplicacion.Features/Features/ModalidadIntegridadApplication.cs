using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ModalidadIntegridadApplication : IModalidadIntegridadApplication
    {
        private readonly IModalidadIntegridadService _modalidadIntegridadService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<DocumentoEstructuraApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public ModalidadIntegridadApplication(
            IModalidadIntegridadService modalidadIntegridadService, 
            IMapper mapper, 
            IAppLogger<DocumentoEstructuraApplication> logger, 
            IUserSessionService userSessionService)
        {
            _modalidadIntegridadService = modalidadIntegridadService;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList(Request<ModalidadIntegridadFilterRequest> request)
        {
            try
            {
                // obtenemos el token de la sesion
                string token = _userSessionService.GetToken();


                // consumimos el servicio de seguridad para el authorize
                var response = await _modalidadIntegridadService.GetList(request.entidad, token);

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
