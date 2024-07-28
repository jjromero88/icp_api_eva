using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common.Constants;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportDocumentService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportDocumentService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpPost("TotalEntidades")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> TotalEntidades([FromBody] ReportTotalEntidadesrequest request)
        {
            if (request == null)
                return BadRequest();

            return await _reportService.ReporteTotalEntidadesAsync(request);
        }

        [AllowAnonymous]
        [HttpPost("GrupoEntidades")]
        //[ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        //[ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GrupoEntidades([FromBody] ReportGrupoEntidadesRequest request)
        {
            if (request == null)
                return BadRequest();

            var response = await _reportService.ReporteGrupoEntidadesAsync(request);


            if (response.Code == (int)HttpStatusCodeEnum.OK && response.Payload is byte[] reportBytes)
            {
                return new FileContentResult(reportBytes, "application/pdf")
                {
                    FileDownloadName = "ReporteGrupoEntidades.pdf"
                };
            }

            if (response.Code == (int)HttpStatusCodeEnum.NoContent)
                return NoContent();

            return StatusCode(response.Code, response.Message);
        }

        [AllowAnonymous]
        [HttpPost("Etapascomponente")]
        //[ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        //[ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Etapascomponente([FromBody] ReportEtapasComponenteRequest request)
        {
            if (request == null)
                return BadRequest();

            var response = await _reportService.ReporteEtapaComponenteAsync(request);


            if (response.Code == (int)HttpStatusCodeEnum.OK && response.Payload is byte[] reportBytes)
            {
                return new FileContentResult(reportBytes, "application/pdf")
                {
                    FileDownloadName = "ReporteEtapasComponente.pdf"
                };
            }

            if (response.Code == (int)HttpStatusCodeEnum.NoContent)
                return NoContent();

            return StatusCode(response.Code, response.Message);
        }
    }
}
