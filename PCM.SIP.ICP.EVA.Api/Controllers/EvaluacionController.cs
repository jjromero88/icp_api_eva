using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    public class EvaluacionController : Controller
    {
        private readonly IEvaluacionApplication _evaluacionApplication;
        private readonly IMapper _mapper;

        public EvaluacionController(IEvaluacionApplication evaluacionApplication, IMapper mapper)
        {
            _evaluacionApplication = evaluacionApplication;
            _mapper = mapper;
        }

        [HttpGet("GetListEvaluaciones")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetListEvaluaciones()
        {
            return await _evaluacionApplication.GetListEvaluaciones();
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EvaluacionFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _evaluacionApplication.GetList(new Request<EvaluacionDto>() { entidad = _mapper.Map<EvaluacionDto>(request) });
        }
    }
}
