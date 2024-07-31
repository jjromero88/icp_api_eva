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
    public class EntidadSectorApplication : IEntidadSectorApplication
    {
        private readonly IEntidadSectorService _entidadSectorService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadSectorApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public EntidadSectorApplication(
            IEntidadSectorService entidadSectorService, 
            IMapper mapper, 
            IAppLogger<EntidadSectorApplication> logger, 
            IUserSessionService userSessionService)
        {
            _entidadSectorService = entidadSectorService;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList()
        {
            try
            {
                string token = _userSessionService.GetToken();

                var response = await _entidadSectorService.GetList(new EntidadSectorFilterRequest(), token);

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<List<EntidadSectorResponseDto>>(response), TransactionMessage.QuerySuccess
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
