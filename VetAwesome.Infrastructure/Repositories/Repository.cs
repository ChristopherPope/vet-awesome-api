using Microsoft.EntityFrameworkCore;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;

namespace VetAwesome.Infrastructure.Repositories;

internal abstract class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly VetAwesomeDb dbContext;
    protected DbSet<T> entities;

    public string TableName { get; init; }

    protected Repository(VetAwesomeDb dbContext, string tableName)
    {
        this.dbContext = dbContext;
        TableName = tableName;
        entities = this.dbContext.Set<T>();
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await dbContext.Database.ExecuteSqlRawAsync($"delete from {TableName}", cancellationToken);
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        try
        {
            await entities.AddAsync(entity, cancellationToken);
        }
        catch (Exception ex)
        {
            var s = ex.Message;
        }

        return entity;
    }

    public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> newEntities, CancellationToken cancellationToken)
    {
        await entities.AddRangeAsync(newEntities, cancellationToken);

        return newEntities;
    }
}
