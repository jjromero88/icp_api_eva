using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Features;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using PCM.SIP.ICP.EVA.Transversal.Common;
using PCM.SIP.ICP.EVA.Transversal.Contracts.icp;
using System.Net;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadIntegridadController : Controller
    {
        private readonly IModalidadIntegridadApplication _modalidadIntegridadApplication;
        private readonly IMapper _mapper;

        public ModalidadIntegridadController(IModalidadIntegridadApplication modalidadIntegridadApplication, IMapper mapper)
        {
            _modalidadIntegridadApplication = modalidadIntegridadApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] ModalidadIntegridadFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _modalidadIntegridadApplication.GetList(new Request<ModalidadIntegridadFilterRequest>() { entidad = request });
        }
    }
}
