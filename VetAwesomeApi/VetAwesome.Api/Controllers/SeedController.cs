using Microsoft.AspNetCore.Mvc;
using VetAwesome.Bll.Interfaces.Services;

namespace VetAwesome.Api.Controllers
{
    public class SeedController : BaseController
    {
        private readonly ISeedService seedSvc;

        public SeedController(ILogger<SeedController> logger, ISeedService seedSvc)
            : base(logger)
        {
            this.seedSvc = seedSvc;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Seed()
        {
            seedSvc.Seed();

            return NoContent();
        }


    }
}
