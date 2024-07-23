using AutoMapper;
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
    public class EntidadEtapaApplication : IEntidadEtapaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntidadEtapaApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public EntidadEtapaApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<EntidadEtapaApplication> logger, 
            IUserSessionService userSessionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> GenerarFicha(Request<EntidadEtapaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<EntidadEtapa>(request.entidad);

                entidad.entidadetapa_id = string.IsNullOrEmpty(request.entidad.serialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.serialKey, _userSessionService.GetUser().authkey));
                entidad.evaluacionetapa_id = string.IsNullOrEmpty(request.entidad.evaluacionetapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.evaluacionetapakey, _userSessionService.GetUser().authkey));
                entidad.fichahistorico.usuario_id = string.IsNullOrEmpty(_userSessionService.GetUser().usuariokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(_userSessionService.GetUser().usuariokey, _userSessionService.GetUser().authkey));
                entidad.fichahistorico.perfil_id = string.IsNullOrEmpty(_userSessionService.GetUser().perfilkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(_userSessionService.GetUser().perfilkey, _userSessionService.GetUser().authkey));
                entidad.usuario_act = _userSessionService.GetUser().username;

                var result = _unitOfWork.EntidadEtapa.GenerarFicha(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
                }

                _logger.LogInformation(result.Message ?? TransactionMessage.SaveSuccess);
                return ResponseUtil.Created(message: result.Message ?? TransactionMessage.SaveSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> AprobarFicha(Request<EntidadEtapaDto> request)
        {
            try
            {
                var entidad = _mapper.Map<EntidadEtapa>(request.entidad);

                entidad.entidadetapa_id = string.IsNullOrEmpty(request.entidad.serialKey) ? 0 : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.serialKey, _userSessionService.GetUser().authkey));
                entidad.evaluacionetapa_id = string.IsNullOrEmpty(request.entidad.evaluacionetapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.evaluacionetapakey, _userSessionService.GetUser().authkey));
                entidad.fichahistorico.usuario_id = string.IsNullOrEmpty(_userSessionService.GetUser().usuariokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(_userSessionService.GetUser().usuariokey, _userSessionService.GetUser().authkey));
                entidad.fichahistorico.perfil_id = string.IsNullOrEmpty(_userSessionService.GetUser().perfilkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(_userSessionService.GetUser().perfilkey, _userSessionService.GetUser().authkey));
                entidad.usuario_act = _userSessionService.GetUser().username;

                var result = _unitOfWork.EntidadEtapa.AprobarFicha(entidad);

                if (result.Error)
                {
                    _logger.LogError(result.Message);
                    return ResponseUtil.BadRequest(message: result.Message, error: null);
                }

                _logger.LogInformation(result.Message ?? TransactionMessage.SaveSuccess);
                return ResponseUtil.Created(message: result.Message ?? TransactionMessage.SaveSuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
    }
}
