using Microsoft.AspNetCore.Mvc;

namespace VetAwesome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ILogger logger;

        public BaseController(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
