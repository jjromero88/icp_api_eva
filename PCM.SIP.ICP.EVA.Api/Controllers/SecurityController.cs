using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Contracts.Seguridad.Account;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly IAccountApplication _accountApplication;
        private readonly IMapper _mapper;

        public SecurityController(IAccountApplication accountApplication, IMapper mapper)
        {
            _accountApplication = accountApplication;
            _mapper = mapper;
        }

        [HttpGet("GetAccesos")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetAccesos()
        {
            return await _accountApplication.UsuarioAccesos();
        }

        [HttpGet("GetPermisos")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetPermisos([FromQuery] UsuarioPermisosrequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _accountApplication.UsuarioPermisos(new Request<UsuarioPermisosrequestDto>() { entidad = request });
        }

        [HttpGet("ValidateToken")]
        [ValidateTokenRequest]
        public IActionResult ValidateToken()
        {
            return Ok();
        }
    }
}
