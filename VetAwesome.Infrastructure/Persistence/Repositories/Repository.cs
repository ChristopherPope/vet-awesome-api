using Microsoft.EntityFrameworkCore;
using VetAwesome.Application.Interfaces.Persistence.Repositories;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Infrastructure.Persistence.Repositories;

internal abstract class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly VetAwesomeDb dbContext;
    private readonly Lazy<DbSet<T>> entities;

    protected DbSet<T> Entities => entities.Value;

    public string TableName { get; init; }

    protected Repository(VetAwesomeDb dbContext, string tableName)
    {
        this.dbContext = dbContext;
        TableName = tableName;
        entities = new Lazy<DbSet<T>>(() => this.dbContext.Set<T>());
    }

    public async ValueTask<T?> ReadByIdAsync(int id)
    {
        return await Entities.FindAsync(id);
    }

    public async ValueTask DeleteByIdAsync(int id)
    {
        var entity = await ReadByIdAsync(id);
        if (entity == null)
        {
            return;
        }

        Entities.Remove(entity);
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await dbContext.Database.ExecuteSqlRawAsync($"delete from {TableName}", cancellationToken);
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        try
        {
            await Entities.AddAsync(entity, cancellationToken);
        }
        catch (Exception ex)
        {
            var s = ex.Message;
        }

        return entity;
    }

    public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> newEntities, CancellationToken cancellationToken)
    {
        await Entities.AddRangeAsync(newEntities, cancellationToken);

        return newEntities;
    }
}
