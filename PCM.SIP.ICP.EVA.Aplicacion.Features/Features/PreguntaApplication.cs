using AutoMapper;
using System.Text.Json;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Domain.Entities;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Util.Encryptions;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class PreguntaApplication : IPreguntaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PreguntaApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public PreguntaApplication(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<PreguntaApplication> logger,
            IUserSessionService userSessionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public Task<PcmResponse> GetList(Request<PreguntaDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
