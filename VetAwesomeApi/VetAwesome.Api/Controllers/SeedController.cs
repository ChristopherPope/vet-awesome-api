using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation("Delete all data and re-create new data.")]
        public IActionResult Seed()
        {
            seedSvc.Seed();

            return NoContent();
        }

        [HttpPost]
        [Route("Appointments")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation("Delete and re-create appointment data.")]
        public IActionResult SeedAppointments()
        {
            seedSvc.Seed();

            return NoContent();
        }
    }
}
