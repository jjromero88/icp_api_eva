using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadController : Controller
    {
        private readonly IEntidadApplication _entidadApplication;
        private readonly IMapper _mapper;

        public EntidadController(IEntidadApplication entidadApplication, IMapper mapper)
        {
            _entidadApplication = entidadApplication;
            _mapper = mapper;
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] GeneralidadesUpdateRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.UpdateGeneralidades(new Request<GeneralidadesUpdateRequestDto>() { entidad = request });
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] EntidadIdRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.GetByIdGeneralidades(new Request<EntidadIdRequestDto>() { entidad = request });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] GeneralidadesFilterRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadApplication.GetListGeneralidades(new Request<GeneralidadesFilterRequestDto>() { entidad = request });
        }

    }
}
