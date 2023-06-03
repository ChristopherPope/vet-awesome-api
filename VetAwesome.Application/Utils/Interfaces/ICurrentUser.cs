using VetAwesome.Application.Dtos;

namespace VetAwesome.Application.Utils.Interfaces;
public interface ICurrentUser
{
    Task SetUserAsync(int userId, CancellationToken cancellationToken);
    UserDto User { get; }
    int UserId { get; }
}
