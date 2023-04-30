using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Repositories;

internal sealed class PetTypeRepository : Repository<PetType>, IPetTypeRepository
{
    public PetTypeRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.PetTypes)
    {
    }
}
