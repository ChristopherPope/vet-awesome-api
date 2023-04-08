using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRoleEntity>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext dbContext) : base(dbContext) { }
    }
}
