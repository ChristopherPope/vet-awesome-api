using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal sealed class PetTypeRepository : Repository<PetType>, IPetTypeRepository
{
    public PetTypeRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.PetTypes)
    {
    }
}
