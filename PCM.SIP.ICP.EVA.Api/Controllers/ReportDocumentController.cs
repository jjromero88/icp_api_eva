using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDocumentController : Controller
    {
        private readonly IReportDocumentService _reportService;
        private readonly IMapper _mapper;

        public ReportDocumentController(IReportDocumentService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpPost("AgrupadoPorEtapas")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> ResultadoEtapa([FromBody] ReportResultadosEtapaRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _reportService.ReporteResultadoEtapaAsync(request);
        }

        [HttpPost("AgrupadoPorGrupoEntidad")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GrupoEntidades([FromBody] ReportGrupoEntidadesRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _reportService.ReporteGrupoEntidadesAsync(request);
        }

        [HttpPost("AgrupadoPorEtapasComponentes")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Etapascomponente([FromBody] ReportEtapasComponenteRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _reportService.ReporteEtapaComponenteAsync(request);
        }

    }
}
