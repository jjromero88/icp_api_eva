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
    public class PreguntaEtapaController : Controller
    {
        private readonly IPreguntaEtapaApplication _preguntaEtapaApplication;
        private readonly IMapper _mapper;

        public PreguntaEtapaController(IPreguntaEtapaApplication preguntaEtapaApplication, IMapper mapper)
        {
            _preguntaEtapaApplication = preguntaEtapaApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] PreguntaEtapaFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _preguntaEtapaApplication.GetList(new Request<PreguntaEtapaDto>() { entidad = _mapper.Map<PreguntaEtapaDto>(request) });
        }
    }
}
