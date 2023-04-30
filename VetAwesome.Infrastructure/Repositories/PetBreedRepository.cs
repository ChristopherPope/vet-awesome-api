using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;
using VetAwesome.Infrastructure.Constants;

namespace VetAwesome.Infrastructure.Repositories;

internal sealed class PetBreedRepository : Repository<PetBreed>, IPetBreedRepository
{
    public PetBreedRepository(VetAwesomeDb dbContext)
        : base(dbContext, TableNames.PetBreeds)
    {
    }
}
