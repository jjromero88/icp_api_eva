using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class EntidadCoordinadorController : Controller
    {
        private readonly IEntidadCoordinadorApplication _entidadCoordinadorApplication;
        private readonly IMapper _mapper;

        public EntidadCoordinadorController(IEntidadCoordinadorApplication entidadCoordinadorApplication, IMapper mapper)
        {
            _entidadCoordinadorApplication = entidadCoordinadorApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] EntidadCoordinadorIdRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.GetById(new Request<EntidadCoordinadorIdRequestDto>() { entidad = request });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EntidadCoordinadorFilterRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.GetList(new Request<EntidadCoordinadorFilterRequestDto>() { entidad = request });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] EntidadCoordinadorInsertRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.Insert(new Request<EntidadCoordinadorInsertRequestDto>() { entidad = request });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] EntidadCoordinadorUpdateRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.Update(new Request<EntidadCoordinadorUpdateRequestDto>() { entidad = request });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] EntidadCoordinadorIdRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadCoordinadorApplication.Delete(new Request<EntidadCoordinadorIdRequestDto>() { entidad = request });
        }

    }
}
