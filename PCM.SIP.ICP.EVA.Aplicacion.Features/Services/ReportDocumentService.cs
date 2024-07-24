using AutoMapper;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Validator;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ReportDocumentService : IReportDocumentService
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly IUserSessionService _userSessionService;
        private readonly IAppLogger<ReportDocumentService> _logger;
        public readonly IProfesionService _profesionService;
        private readonly ReportValidationManager _reportValidationManager;

        public ReportDocumentService(
            IReportService reportService, 
            IMapper mapper, 
            IUserSessionService userSessionService,
            IProfesionService profesionService,
            IAppLogger<ReportDocumentService> logger,
            ReportValidationManager reportValidationManager)
        {
            _reportService = reportService;
            _mapper = mapper;
            _userSessionService = userSessionService;
            _profesionService = profesionService;
            _logger = logger;
            _reportValidationManager = reportValidationManager;
        }

        public async Task<PcmResponse> GenerateReportAsync(Request<ReportDto> request)
        {
            try
            {
                var validation = _reportValidationManager.Validate(_mapper.Map<ReportRequest>(request.entidad));

                if (!validation.IsValid)
                {
                    _logger.LogError(Validation.InvalidMessage);
                    return ResponseUtil.BadRequest(validation.Errors != null ? validation.Errors : null, Validation.InvalidMessage);
                }

                // obtenemos el token de la sesion
                string token = _userSessionService.GetToken();

                // traemos la data
                List<ProfesionResponse> profesiones = await _profesionService.GetList(new ProfesionFilterRequest(), token);

                // obtenemos el formato de la peticion
                string rptFormat = request.entidad.format ?? string.Empty;

                // generamos el report
                var (fileName, base64Content) = await _reportService.GenerateReportAsync(rptFormat, "ReportsPath", profesiones);

                // formamos la estructura de respuesta del reporte
                var result = new ReportBase64Response
                {
                    filename = fileName,
                    base64content = base64Content,
                    extension = rptFormat
                };

                return result != null ? ResponseUtil.Ok(result, TransactionMessage.QuerySuccess) : ResponseUtil.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResponseUtil.InternalError(message: ex.Message);
            }
        }

 
    }
}
