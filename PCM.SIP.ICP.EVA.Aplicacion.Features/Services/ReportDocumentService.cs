using AutoMapper;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;

namespace PCM.SIP.ICP.EVA.Aplicacion.Features
{
    public class ReportDocumentService : IReportDocumentService
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly IUserSessionService _userSessionService;
        private readonly IAppLogger<ReportDocumentService> _logger;

        public ReportDocumentService(
            IReportService reportService, 
            IMapper mapper, 
            IUserSessionService userSessionService, 
            IAppLogger<ReportDocumentService> logger)
        {
            _reportService = reportService;
            _mapper = mapper;
            _userSessionService = userSessionService;
            _logger = logger;
        }

        public async Task<byte[]> GenerateReportAsync(string reportName)
        {
            return await _reportService.GenerateReportAsync(reportName, "ReportsPath");
        }
    }
}
