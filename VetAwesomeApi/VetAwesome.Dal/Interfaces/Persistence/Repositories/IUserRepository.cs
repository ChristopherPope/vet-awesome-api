using VetAwesome.Dal.Entities;

namespace VetAwesome.Dal.Interfaces.Persistence.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        IQueryable<UserEntity> ReadUsers();
    }
}
