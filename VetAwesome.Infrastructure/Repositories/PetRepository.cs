using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Repositories;

internal sealed class PetRepository : Repository<Pet>, IPetRepository
{
    public PetRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.Pets)
    {
    }
}
