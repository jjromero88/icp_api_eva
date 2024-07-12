using Microsoft.AspNetCore.Mvc;
using PCM.SIP.ICP.EVA.Api.Filters;

namespace PCM.SIP.ICP.EVA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        [HttpGet("ValidateToken")]
        [ValidateTokenRequest]
        public IActionResult ValidateToken()
        {
            return Ok();
        }
    }
}
