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
    public class DocumentoEstructuraController : Controller
    {
        private readonly IDocumentoEstructuraApplication _documentoEstructuraApplication;
        private readonly IMapper _mapper;

        public DocumentoEstructuraController(IDocumentoEstructuraApplication documentoEstructuraApplication, IMapper mapper)
        {
            _documentoEstructuraApplication = documentoEstructuraApplication;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] DocumentoEstructuraFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _documentoEstructuraApplication.GetList(new Request<DocumentoEstructuraFilterRequest>() { entidad = request });
        }
    }
}
