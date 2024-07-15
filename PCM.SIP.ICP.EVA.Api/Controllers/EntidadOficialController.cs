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
    public class EntidadOficialController : Controller
    {
        private readonly IEntidadOficialApplication _entidadOficialApplication;
        private readonly IMapper _mapper;

        public EntidadOficialController(IEntidadOficialApplication entidadOficialApplication, IMapper mapper)
        {
            _entidadOficialApplication = entidadOficialApplication;
            _mapper = mapper;
        }

        [HttpGet("GetById")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetById([FromQuery] EntidadOficialIdRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.GetById(new Request<EntidadOficialIdRequestDto>() { entidad = request });
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] EntidadOficialFilterRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.GetList(new Request<EntidadOficialFilterRequestDto>() { entidad = request });
        }

        [HttpPost("Insert")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Insert([FromBody] EntidadOficialInsertRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.Insert(new Request<EntidadOficialInsertRequestDto>() { entidad = request });
        }

        [HttpPut("Update")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Update([FromBody] EntidadOficialUpdateRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.Update(new Request<EntidadOficialUpdateRequestDto>() { entidad = request });
        }

        [HttpDelete("Delete")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DeleteObject([FromBody] EntidadOficialIdRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadOficialApplication.Delete(new Request<EntidadOficialIdRequestDto>() { entidad = request });
        }

    }
}
