using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using System.Net;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadEtapaController : Controller
    {
        private readonly IEntidadEtapaApplication _entidadEtapaApplication;
        private readonly IMapper _mapper;

        public EntidadEtapaController(IEntidadEtapaApplication entidadEtapaApplication, IMapper mapper)
        {
            _entidadEtapaApplication = entidadEtapaApplication;
            _mapper = mapper;
        }

        [HttpPost("GenerarFicha")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GenerarFicha([FromBody] GenerarFichaRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadEtapaApplication.GenerarFicha(new Request<EntidadEtapaDto>() { entidad = _mapper.Map<EntidadEtapaDto>(request) });
        }

        [HttpPost("AprobarFicha")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> AprobarFicha([FromBody] AprobarFichaRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _entidadEtapaApplication.AprobarFicha(new Request<EntidadEtapaDto>() { entidad = _mapper.Map<EntidadEtapaDto>(request) });
        }

    }
}
