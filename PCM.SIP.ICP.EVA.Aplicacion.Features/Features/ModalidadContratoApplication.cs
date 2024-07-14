using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ModalidadContratoApplication : IModalidadContratoApplication
    {
        private readonly IModalidadContratoService _modalidadContratoService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ModalidadContratoApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public ModalidadContratoApplication(
            IModalidadContratoService modalidadContratoService, 
            IMapper mapper, 
            IAppLogger<ModalidadContratoApplication> logger, 
            IUserSessionService userSessionService)
        {
            _modalidadContratoService = modalidadContratoService;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList(Request<ModalidadContratoFilterRequest> request)
        {
            try
            {
                // obtenemos el token de la sesion
                string token = _userSessionService.GetToken();

                // consumimos el servicio de seguridad para el authorize
                var response = await _modalidadContratoService.GetList(request.entidad, token);

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
