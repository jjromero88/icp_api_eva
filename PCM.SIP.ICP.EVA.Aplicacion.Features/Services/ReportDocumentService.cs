using AutoMapper;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Validator;
using PCM.SIP.ICP.EVA.Aplicacion.Interface;
using PCM.SIP.ICP.EVA.Transversal.Util.Encryptions;
using PCM.SIP.ICP.EVA.Transversal.Common.Report;
using PCM.SIP.ICP.EVA.Domain.Entities;
using System.Text.Json;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ReportDocumentService : IReportDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly IUserSessionService _userSessionService;
        private readonly IAppLogger<ReportDocumentService> _logger;
        public readonly IProfesionService _profesionService;
        private readonly ReportValidationManager _reportValidationManager;

        public ReportDocumentService(
            IUnitOfWork unitOfWork,
            IReportService reportService,
            IMapper mapper,
            IUserSessionService userSessionService,
            IProfesionService profesionService,
            IAppLogger<ReportDocumentService> logger,
            ReportValidationManager reportValidationManager)
        {
            _unitOfWork = unitOfWork;
            _reportService = reportService;
            _mapper = mapper;
            _userSessionService = userSessionService;
            _profesionService = profesionService;
            _logger = logger;
            _reportValidationManager = reportValidationManager;
        }

        // Reporte: AGRUPADO POR ETAPAS
        public async Task<PcmResponse> ReporteResultadoEtapaAsync(ReportResultadosEtapaRequest request)
        {
            try
            {
                var validation = _reportValidationManager.Validate(request);

                // verificamos si ocurrio algun error de validacion
                if (!validation.IsValid)
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);

                // si no tiene data
                if (request.data == null || !request.data.Any())
                    return ResponseUtil.NoContent();

                // generamos el reporte
                byte[] reportBytes = await _reportService.ReporteResultadoEtapaAsync(request);

                // Convierte el array de bytes a una cadena en Base64
                string? base64String = Convert.ToBase64String(reportBytes);

                var response = new ReportBase64Response
                {
                    filename = ReportUtils.GenerateFileNameDate("Grupoentidades", request.format),
                    extension = request.format,
                    base64content = base64String
                };

                // retornamos el resultado
                return (reportBytes != null && reportBytes.Length > 0) ? ResponseUtil.Ok(response, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        /* Reporte: Agrupado por Grupo de Entidad */
        public async Task<PcmResponse> ReporteGrupoEntidadesAsync(ReportGrupoEntidadesRequest request)
        {
            try
            {

                // si no tiene data
                if (request.data == null || !request.data.Any())
                    return ResponseUtil.NoContent();

                // generamos el reporte
                byte[] reportBytes = await _reportService.ReporteGrupoEntidadesAsync(request);

                // Convierte el array de bytes a una cadena en Base64
                string? base64String = Convert.ToBase64String(reportBytes);

                var response = new ReportBase64Response
                {
                    filename = ReportUtils.GenerateFileNameDate("Grupoentidades", request.format),
                    extension = request.format,
                    base64content = base64String
                };

                // retornamos el resultado
                return (reportBytes != null && reportBytes.Length > 0) ? ResponseUtil.Ok(response, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        /* Reporte: Agrupado por Etapa y Componente */
        public async Task<PcmResponse> ReporteEtapaComponenteAsync(ReportEtapasComponenteRequest request)
        {
            try
            {

                // si no tiene data
                if (request.data == null || !request.data.Any())
                    return ResponseUtil.NoContent();

                // generamos el reporte
                byte[] reportBytes = await _reportService.ReporteEtapaComponenteAsync(request);

                // Convierte el array de bytes a una cadena en Base64
                string? base64String = Convert.ToBase64String(reportBytes);

                var response = new ReportBase64Response
                {
                    filename = ReportUtils.GenerateFileNameDate("EtapaComponente", request.format),
                    extension = request.format,
                    base64content = base64String
                };

                // retornamos el resultado
                return (reportBytes != null && reportBytes.Length > 0) ? ResponseUtil.Ok(response, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        /* Reporte: Resultados por Sector */
        public async Task<PcmResponse> ReporteResultadoPorSectorAsync(ReportResultadoPorSectorRequest request)
        {
            try
            {
                // si no tiene data
                if (request == null)
                    return ResponseUtil.NoContent();

                // deserializamos los parametros de entrada
                var entidad = new ResultadoPorSectorRequest();
                entidad.evaluacion_id = string.IsNullOrEmpty(request.evaluacionkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.evaluacionkey, _userSessionService.GetUser().authkey));
                entidad.entidadsector_id = string.IsNullOrEmpty(request.entidadsectorkey) ? null : Convert.ToInt32(CShrapEncryption.DecryptString(request.entidadsectorkey, _userSessionService.GetUser().authkey));
 
                // consumimos la data del reporte
                var result = _unitOfWork.Reportes.ReporteResultadoPorSector(entidad, out string jsonResultadosTotales);

                // verificamos si ocurrio un error
                if (result.Error)
                    return ResponseUtil.BadRequest(result.Message);

                // verificamos si existe data de salida
                if (string.IsNullOrEmpty(jsonResultadosTotales))
                    return ResponseUtil.NoContent();

                // desereializamos el response
                var responseData = JsonSerializer.Deserialize<ResultadoPorSectorResponse>(jsonResultadosTotales);

                if(responseData == null)
                    return ResponseUtil.NoContent();

                // generamos el reporte
                byte[] reportBytes = await _reportService.ReporteResultadoPorSectorAsync(responseData);

                // Convierte el array de bytes a una cadena en Base64
                string? base64String = Convert.ToBase64String(reportBytes);

                var response = new ReportBase64Response
                {
                    filename = ReportUtils.GenerateFileNameDate("ResultadosPorSector", "pdf"),
                    extension = "pdf",
                    base64content = base64String
                };

                // retornamos el resultado
                return (reportBytes != null && reportBytes.Length > 0) ? ResponseUtil.Ok(response, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }
    }
}
