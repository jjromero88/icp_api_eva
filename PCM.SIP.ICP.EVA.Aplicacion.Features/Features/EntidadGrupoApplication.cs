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
    public class EntidadGrupoApplication : IEntidadGrupoApplication
    {
        private readonly IEntidadGrupoService _entidadGrupoService;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadGrupoApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public EntidadGrupoApplication(IEntidadGrupoService entidadGrupoService, IMapper mapper, IAppLogger<EntidadGrupoApplication> logger, IUserSessionService userSessionService)
        {
            _entidadGrupoService = entidadGrupoService;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GetList()
        {
            try
            {
                string token = _userSessionService.GetToken();

                var response = await _entidadGrupoService.GetList(new EntidadGrupoFilterRequest(), token);

                return response != null ? ResponseUtil.Ok(
                   _mapper.Map<List<EntidadGrupoResponseDto>>(response), TransactionMessage.QuerySuccess
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
