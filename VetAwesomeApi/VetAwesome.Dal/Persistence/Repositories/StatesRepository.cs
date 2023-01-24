using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class StatesRepository : GenericRepository<StateEntity>, IStatesRepository
    {
        public StatesRepository(DbContext dbContext) : base(dbContext) { }
    }
}
