using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class HouseholdRepository : GenericRepository<HouseholdEntity>, IHouseholdRepository
    {
        public HouseholdRepository(DbContext dbContext) : base(dbContext) { }
    }
}
