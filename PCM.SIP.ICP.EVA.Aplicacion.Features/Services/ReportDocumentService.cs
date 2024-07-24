using AutoMapper;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ReportDocumentService : IReportDocumentService
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly IUserSessionService _userSessionService;
        private readonly IAppLogger<ReportDocumentService> _logger;
        public readonly IProfesionService _profesionService;

        public ReportDocumentService(
            IReportService reportService, 
            IMapper mapper, 
            IUserSessionService userSessionService,
            IProfesionService profesionService,
            IAppLogger<ReportDocumentService> logger)
        {
            _reportService = reportService;
            _mapper = mapper;
            _userSessionService = userSessionService;
            _profesionService = profesionService;
            _logger = logger;
        }

        public async Task<byte[]> GenerateReportAsync(string reportName)
        {
            // obtenemos el token de la sesion
            string token = _userSessionService.GetToken();

            List<ProfesionResponse> profesiones = await _profesionService.GetList(new ProfesionFilterRequest(), token);

            return await _reportService.GenerateReportAsync(reportName, "ReportsPath", profesiones);
        }
    }
}
