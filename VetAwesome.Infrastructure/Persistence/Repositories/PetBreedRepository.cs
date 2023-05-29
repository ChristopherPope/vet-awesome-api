using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal sealed class PetBreedRepository : Repository<PetBreed>, IPetBreedRepository
{
    public PetBreedRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.PetBreeds)
    {
    }
}
