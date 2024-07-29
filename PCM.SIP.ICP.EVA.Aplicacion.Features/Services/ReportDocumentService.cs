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

        // Tipo de reporte: AGRUPADO POR ETAPAS
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

                // retornamos el resultado
                return reportBytes != null ? ResponseUtil.Ok(reportBytes, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> ReporteGrupoEntidadesAsync(ReportGrupoEntidadesRequest request)
        {
            try
            {
 
                // si no tiene data
                if (request.data == null || !request.data.Any())
                    return ResponseUtil.NoContent();

                // generamos el reporte
                byte[] reportBytes = await _reportService.ReporteGrupoEntidadesAsync(request);

                // retornamos el resultado
                return reportBytes != null ? ResponseUtil.Ok(reportBytes, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

        public async Task<PcmResponse> ReporteEtapaComponenteAsync(ReportEtapasComponenteRequest request)
        {
            try
            {

                // si no tiene data
                if (request.data == null || !request.data.Any())
                    return ResponseUtil.NoContent();

                // generamos el reporte
                byte[] reportBytes = await _reportService.ReporteEtapaComponenteAsync(request);

                // retornamos el resultado
                return reportBytes != null ? ResponseUtil.Ok(reportBytes, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

      
    }
}
