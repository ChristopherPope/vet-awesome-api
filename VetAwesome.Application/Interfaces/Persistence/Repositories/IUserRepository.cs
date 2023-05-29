using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Interfaces.Persistence.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<User>> ReadAllAsync(CancellationToken cancellationToken);
}
