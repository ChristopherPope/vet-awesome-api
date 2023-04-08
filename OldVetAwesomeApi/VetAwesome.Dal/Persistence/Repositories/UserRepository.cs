using Microsoft.EntityFrameworkCore;
using System.Data;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }

        public IQueryable<UserEntity> ReadUsers()
        {
            return entities.OrderBy(u => u.Name);
        }
    }
}

