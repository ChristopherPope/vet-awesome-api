using VetAwesome.Dal.Entities;

namespace VetAwesome.Dal.Interfaces.Persistence.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> ReadAll();
        TEntity? ReadById(object id);
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities);
        void Delete(params TEntity[] entitiesToDelete);
        TEntity Update(TEntity entityToUpdate);
        bool IsEmpty();
    }
}
