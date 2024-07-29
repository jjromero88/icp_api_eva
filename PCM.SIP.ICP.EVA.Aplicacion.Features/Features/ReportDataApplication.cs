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
    public class ReportDataApplication : IReportDataApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ReportDataApplication> _logger;
        private readonly IUserSessionService _userSessionService;

        public ReportDataApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IAppLogger<ReportDataApplication> logger, 
            IUserSessionService userSessionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userSessionService = userSessionService;
        }

        public async Task<PcmResponse> ReporteAgrupadoPorEtapas(Request<ReportDataDto> request)
        {
            try
            {
                var entidad = new TotalEntidadesRequest();
                
                // deserializamos los parametros de entrada
                entidad.evaluacion_id = string.IsNullOrEmpty(request.entidad.evaluacionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.evaluacionkey, _userSessionService.GetUser().authkey));
                entidad.etapa_id = string.IsNullOrEmpty(request.entidad.etapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.etapakey, _userSessionService.GetUser().authkey));
                entidad.entidad_id = string.IsNullOrEmpty(request.entidad.entidadkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadkey, _userSessionService.GetUser().authkey));

                // consultamos a base de datos
                var result = _unitOfWork.Reportes.ReporteAgrupadoPorEtapas(entidad, out string jsonTotalEntidadesResponse);

                // verificamos si ocurrio un error
                if (result.Error)
                    return ResponseUtil.BadRequest(result.Message);

                // verificamos si existe data de salida
                if(string.IsNullOrEmpty(jsonTotalEntidadesResponse))
                    return ResponseUtil.NoContent();

                // desereializamos el response
                var response = JsonSerializer.Deserialize<List<TotalEntidadesResponse>>(jsonTotalEntidadesResponse);

                // mapeamos el resultado
                var mapResponse = _mapper.Map<List<ReporteAgrupadoPorEtapasResponse>>(response);

                // retornamos el resultado
                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return ResponseUtil.Ok(mapResponse, result.Message ?? TransactionMessage.QuerySuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> ReporteAgrupadoPorGrupoEntidad(Request<ReportDataDto> request)
        {
            try
            {
                var entidad = new GrupoEntidadesRequest();

                // deserializamos los parametros de entrada
                entidad.evaluacion_id = string.IsNullOrEmpty(request.entidad.evaluacionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.evaluacionkey, _userSessionService.GetUser().authkey));
                entidad.etapa_id = string.IsNullOrEmpty(request.entidad.etapakey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.etapakey, _userSessionService.GetUser().authkey));
                entidad.entidadgrupo_id = string.IsNullOrEmpty(request.entidad.entidadgrupokey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidad.entidadgrupokey, _userSessionService.GetUser().authkey));

                // consultamos a base de datos
                var result = _unitOfWork.Reportes.ReporteAgrupadoPorGrupoEntidad(entidad, out string jsonGrupoEntidadesResponse);

                // verificamos si ocurrio un error
                if (result.Error)
                    return ResponseUtil.BadRequest(result.Message);

                // verificamos si existe data de salida
                if (string.IsNullOrEmpty(jsonGrupoEntidadesResponse))
                    return ResponseUtil.NoContent();

                // desereializamos el response
                var response = JsonSerializer.Deserialize<List<GrupoEntidadesResponse>>(jsonGrupoEntidadesResponse);

                // mapeamos el resultado
                var mapResponse = _mapper.Map<List<ReporteGrupoEntidadesResponse>>(response);

                // retornamos el resultado
                _logger.LogInformation(TransactionMessage.QuerySuccess);
                return ResponseUtil.Ok(mapResponse, result.Message ?? TransactionMessage.QuerySuccess);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
    }
}
