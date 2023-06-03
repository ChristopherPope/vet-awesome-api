using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using VetAwesome.Application.CommandsAndQueries.Users.Queries.GetUser;
using VetAwesome.Application.Dtos;
using VetAwesome.Application.Utils.Interfaces;

namespace VetAwesome.Application.Utils;

internal class CurrentUser : ICurrentUser
{
    private const string SessionKey_UserObject = "session-key-user-object";
    private UserDto? user;
    private readonly ISender mediator;
    private readonly ISession session;

    public CurrentUser(IHttpContextAccessor httpAccessor, ISender mediator)
    {
        session = httpAccessor.HttpContext?.Session ?? throw new InvalidOperationException("The Http Session does not exist.");
        this.mediator = mediator;
    }

    public async Task SetUserAsync(int userId, CancellationToken cancellationToken)
    {
        if (session.Keys.Contains(SessionKey_UserObject))
        {
            throw new InvalidOperationException("Cannot perform operation because the current user has already been set.");
        }

        user = await mediator.Send(new GetUserQuery(userId), cancellationToken)
            ?? throw new InvalidOperationException($"Cannot find a user with the id {userId}.");

        var userJson = JsonSerializer.Serialize(user);
        session.SetString(SessionKey_UserObject, userJson);
    }

    public UserDto User
    {
        get
        {
            user ??= GetCurrentUserFromSession();
            return user;
        }
    }

    public int UserId
    {
        get
        {
            return User.Id;
        }
    }

    private UserDto GetCurrentUserFromSession()
    {
        var userJson = session.GetString(SessionKey_UserObject) ?? string.Empty;
        var user = JsonSerializer.Deserialize<UserDto>(userJson);
        if (user == null)
        {
            throw new InvalidOperationException("Cannot access current user in session because it does not exist.");
        }

        return user;
    }
}
