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
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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
