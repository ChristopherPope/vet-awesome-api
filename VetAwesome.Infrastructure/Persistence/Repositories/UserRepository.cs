using Microsoft.EntityFrameworkCore;
using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.Users)
    {
    }

    public async Task<IEnumerable<User>> ReadAllAsync(CancellationToken cancellationToken)
    {
        return await (from u in Entities
                      orderby u.Name
                      select u)
                .ToListAsync(cancellationToken);
    }

    public async Task<User?> ReadUserAsync(int userId, CancellationToken cancellationToken)
    {
        return await (from u in Entities
                      where u.Id == userId
                      select u).FirstOrDefaultAsync(cancellationToken);
    }
}
