using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
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
    public class ModalidadContratoController : Controller
    {
        private readonly IModalidadContratoApplication _modalidadContratoApplication;
        private readonly IMapper _mapper;

        public ModalidadContratoController(IModalidadContratoApplication modalidadContratoApplication, IMapper mapper)
        {
            _modalidadContratoApplication = modalidadContratoApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] ModalidadContratoFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _modalidadContratoApplication.GetList(new Request<ModalidadContratoFilterRequest>() { entidad = request });
        }

    }
}
