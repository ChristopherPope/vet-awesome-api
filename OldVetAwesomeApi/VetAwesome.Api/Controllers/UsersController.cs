using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VetAwesome.Bll.Dtos;
using VetAwesome.Bll.Interfaces.Services;

namespace VetAwesome.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersService usersSvc;

        public UsersController(ILogger<UsersController> logger, IUsersService usersSvc)
            : base(logger)
        {
            this.usersSvc = usersSvc;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Authenticate(int userId)
        {
            usersSvc.Authenticate(userId);

            return NoContent();
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "A list of all Users.")]
        [SwaggerOperation("Returns a list of all Users in the system.")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return usersSvc.GetUsers().ToList();
        }
    }
}
