using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeadersController : ControllerBase
    {
        public HeadersController(ILogger<HeadersController> logger)
        { }

        [HttpGet]
        public int Get()
        {
            return HttpContext.Request.Headers["custom-header"].Count();
        }
    }
}