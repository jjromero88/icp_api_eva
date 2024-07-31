using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadSectorController : Controller
    {
        private readonly IEntidadSectorApplication _entidadSectorApplication;
        private readonly IMapper _mapper;

        public EntidadSectorController(IEntidadSectorApplication entidadSectorApplication, IMapper mapper)
        {
            _entidadSectorApplication = entidadSectorApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList()
        {
            return await _entidadSectorApplication.GetList();
        }

    }
}
