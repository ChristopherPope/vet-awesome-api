using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class PetTypeRepository : GenericRepository<PetTypeEntity>, IPetTypeRepository
    {
        public PetTypeRepository(DbContext dbContext) : base(dbContext) { }
    }
}
