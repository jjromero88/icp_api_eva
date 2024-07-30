using AutoMapper;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ComponenteApplication : IComponenteApplication
    {
        private readonly IComponenteService _componenteService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ComponenteApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public ComponenteApplication(IComponenteService componenteService, IMapper mapper, IAppLogger<ComponenteApplication> logger, IUserSessionService userSessionService)
        {
            _componenteService = componenteService;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList()
        {
            try
            {
                string token = _userSessionService.GetToken();

                var response = await _componenteService.GetList(new ComponenteIcpFilterRequest(), token);

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<List<ComponenteIcpResponseDto>>(response), TransactionMessage.QuerySuccess
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
