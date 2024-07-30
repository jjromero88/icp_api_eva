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
    public class EtapaApplication : IEtapaApplication
    {
        private readonly IEtapaService _etapaService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EtapaApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public EtapaApplication(IEtapaService etapaService, IMapper mapper, IAppLogger<EtapaApplication> logger, IUserSessionService userSessionService)
        {
            _etapaService = etapaService;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList()
        {
            try
            {
                string token = _userSessionService.GetToken();

                var response = await _etapaService.GetList(new EtapaIcpFilterRequest(), token);

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<List<EtapaIcpResponseDto>>(response), TransactionMessage.QuerySuccess
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
