using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Questioner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefaultController : ControllerBase
    {
        // GET: DefaultController
        [HttpGet]
        public string Get()
        {
            return "Application Running... ";
        }


    }
}
