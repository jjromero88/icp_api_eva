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
    public class PreguntaController : Controller
    {
        private readonly IPreguntaApplication _preguntaApplication;
        private readonly IMapper _mapper;

        public PreguntaController(IPreguntaApplication preguntaApplication, IMapper mapper)
        {
            _preguntaApplication = preguntaApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] PreguntaFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _preguntaApplication.GetList(new Request<PreguntaDto>() { entidad = _mapper.Map<PreguntaDto>(request) });
        }
    }
}
