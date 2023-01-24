using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class RoleRepository : GenericRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext) { }
    }
}
