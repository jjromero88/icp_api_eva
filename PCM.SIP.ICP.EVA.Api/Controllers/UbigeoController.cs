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
    public class UbigeoController : Controller
    {
        private readonly IUbigeoApplication _ubigeoApplication;
        private readonly IMapper _mapper;

        public UbigeoController(IUbigeoApplication ubigeoApplication, IMapper mapper)
        {
            _ubigeoApplication = ubigeoApplication;
            _mapper = mapper;
        }

        [HttpGet("GetListDepartamentos")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetListDepartamentos()
        {
            return await _ubigeoApplication.GetListDepartamento();
        }

        [HttpGet("GetListProvincias")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] ProvinciaFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _ubigeoApplication.GetListProvincia(new Request<ProvinciaFilterRequest>() { entidad = request });
        }

        [HttpGet("GetListDistritos")]
        [ServiceFilter(typeof(ValidateTokenRequestAttribute))]
        [ServiceFilter(typeof(UpdateUserDataAttribute))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PcmResponse))]
        public async Task<ActionResult<PcmResponse>> GetList([FromQuery] DistritoFilterRequest request)
        {
            if (request == null)
                return BadRequest();

            return await _ubigeoApplication.GetListDistrito(new Request<DistritoFilterRequest>() { entidad = request });
        }

    }
}
