using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;
using PCM.SIP.ICP.EVA.Aplicacion.Dto;
using PCM.SIP.ICP.EVA.Aplicacion.Interface.Features;
using PCM.SIP.ICP.EVA.Transversal.Common.Generics;
using System.Net;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpPost("Upload")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> UploadDocument([FromBody] UploadDocumentRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _documentService.UploadDocumentAsync(request);
        }

        [HttpPost("Download")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> DownloadDocument([FromBody] DownloadDocumentRequestDto request)
        {
            if (request == null)
                return BadRequest();

            return await _documentService.DownloadDocumentAsync(request);
        }
    }
}
