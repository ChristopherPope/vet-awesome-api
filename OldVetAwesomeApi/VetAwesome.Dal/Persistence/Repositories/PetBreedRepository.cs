using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class PetBreedRepository : GenericRepository<PetBreedEntity>, IPetBreedRepository
    {
        public PetBreedRepository(DbContext dbContext) : base(dbContext) { }
    }
}
