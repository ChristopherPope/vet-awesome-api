using Microsoft.EntityFrameworkCore;
using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal sealed class PetRepository : Repository<Pet>, IPetRepository
{
    public PetRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.Pets)
    {
    }

    public async Task<IEnumerable<Pet>> ReadAllAsync(CancellationToken cancellationToken)
    {
        return await (from p in Entities
                      .Include(p => p.Customer)
                      select p)
                .ToListAsync(cancellationToken);
    }
}
