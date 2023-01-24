using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class PetRepository : GenericRepository<PetEntity>, IPetRepository
    {
        public PetRepository(DbContext dbContext) : base(dbContext) { }
    }
}
