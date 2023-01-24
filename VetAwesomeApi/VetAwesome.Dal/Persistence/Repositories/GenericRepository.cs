using Microsoft.EntityFrameworkCore;
using VetAwesome.Dal.Entities;
using VetAwesome.Dal.Interfaces.Persistence.Repositories;

namespace VetAwesome.Dal.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> entities;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }

        public virtual TEntity? ReadById(object id)
        {
            return entities.Find(id);
        }

        public IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities)
        {
            var createdEntities = new List<TEntity>();
            foreach (var entity in entities)
            {
                createdEntities.Add(Create(entity));
            }

            return createdEntities;
        }

        public virtual TEntity Create(TEntity entity)
        {
            return entities.Add(entity).Entity;
        }

        public virtual void Delete(params TEntity[] entitiesToDelete)
        {
            foreach (var entityToDelete in entitiesToDelete)
            {
                if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
                {
                    entities.Attach(entityToDelete);
                }

                entities.Remove(entityToDelete);
            }
        }

        public virtual TEntity Update(TEntity entityToUpdate)
        {
            entities.Attach(entityToUpdate);
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;

            return entityToUpdate;
        }

        public bool IsEmpty()
        {
            return (!entities.Any());
        }

        public IQueryable<TEntity> ReadAll()
        {
            return entities;
        }
    }
}
