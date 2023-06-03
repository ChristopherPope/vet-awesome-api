using VetAwesome.Application.Dtos;

namespace VetAwesome.Application.CurrentUser;
internal interface ICurrentUser
{
    Task SetUserAsync(int userId, CancellationToken cancellationToken);
    UserDto User { get; }
    int UserId { get; }
}
