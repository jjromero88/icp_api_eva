using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDataController : Controller
    {
        private readonly IReportDataApplication _reportDataApplication;
        private readonly IMapper _mapper;

        public ReportDataController(IReportDataApplication reportDataApplication, IMapper mapper)
        {
            _reportDataApplication = reportDataApplication;
            _mapper = mapper;
        }

        [HttpGet("AgrupadoPorEtapas")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> AgrupadoPorEtapas([FromQuery] ReporteAgrupadoPorEtapasRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _reportDataApplication.ReporteAgrupadoPorEtapas(new Request<ReportDataDto>() { entidad = _mapper.Map<ReportDataDto>(request) });
        }
        [HttpGet("AgrupadoPorGrupoDeEntidad")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> AgrupadoPorGrupoDeEntidad([FromQuery] ReporteGrupoEntidadesRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _reportDataApplication.ReporteAgrupadoPorGrupoEntidad(new Request<ReportDataDto>() { entidad = _mapper.Map<ReportDataDto>(request) });
        }
    }
}
