using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetAwesome.Application.CommandsAndQueries.Users.Queries.GetAllUsers;
using VetAwesome.Application.Dtos;

namespace VetAwesome.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class UsersController : ApiController
{
    public UsersController(ISender mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(CancellationToken cancellationToken)
    {
        var request = new GetAllUsersQuery();
        var users = await mediator.Send(request, cancellationToken);

        return Ok(users);
    }
}
