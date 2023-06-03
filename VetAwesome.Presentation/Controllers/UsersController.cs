using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetAwesome.Application.CommandsAndQueries.Users.Queries.GetAllUsers;
using VetAwesome.Application.Dtos;
using VetAwesome.Application.Utils.Interfaces;

namespace VetAwesome.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class UsersController : ApiController
{
    private ICurrentUser currentUser;

    public UsersController(ISender mediator, ICurrentUser currentUser)
        : base(mediator)
    {
        this.currentUser = currentUser;
    }

    [HttpPost]
    [Route("{userId}")]
    public async Task<ActionResult> Authenticate(int userId, CancellationToken cancellationToken)
    {
        await currentUser.SetUserAsync(userId, cancellationToken);

        return Ok();
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
