using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportDocumentService _reportService;

        public ReportController(IReportDocumentService reportService)
        {
            _reportService = reportService;
        }

        [AllowAnonymous]
        [HttpGet("GenerateReport")]
        public async Task<IActionResult> GenerateReport()
        {
            byte[] report = await _reportService.GenerateReportAsync("ReptPrueba.rdlc");
            return File(report, "application/pdf", "Reporte.pdf");
        }
    }
}
