using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using System.Net;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountApplication _accountApplication;
        private readonly IMapper _mapper;

        public AccountController(IAccountApplication accountApplication, IMapper mapper)
        {
            _accountApplication = accountApplication;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> Authenticate([FromBody] AuthenticateRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _accountApplication.Authenticate(new Request<AuthenticateRequestDto>() { entidad = request });
        }

    }
}
