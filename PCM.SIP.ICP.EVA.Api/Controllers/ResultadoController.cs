using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Features;
using System.Collections.Generic;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : Controller
    {
        private readonly IResultadoApplication _resultadoApplication;
        private readonly IMapper _mapper;

        public ResultadoController(IResultadoApplication resultadoApplication, IMapper mapper)
        {
            _resultadoApplication = resultadoApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] ResultadoFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _resultadoApplication.GetList(new Request<ResultadoDto>() { entidad = _mapper.Map<ResultadoDto>(request) });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] List<ResultadoInsertRequest> request)
        {
            if (request == null)
                return BadRequest();

            return await _resultadoApplication.Insert(new Request<List<ResultadoDto>>() { entidad = _mapper.Map<List<ResultadoDto>>(request) });
        }

    }
}
