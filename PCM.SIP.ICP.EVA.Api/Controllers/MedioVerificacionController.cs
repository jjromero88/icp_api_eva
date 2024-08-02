using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedioVerificacionController : Controller
    {
        private readonly IMedioVerificacionApplication _medioVerificacionApplication;
        private readonly IMapper _mapper;

        public MedioVerificacionController(IMedioVerificacionApplication medioVerificacionApplication, IMapper mapper)
        {
            _medioVerificacionApplication = medioVerificacionApplication;
            _mapper = mapper;
        }

        [HttpPost("UploadDocument")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> UploadDocument([FromBody] MedioVerificacionDocumentUploadRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _medioVerificacionApplication.UploadDocument(request);
        }

    }
}
