using VetAwesome.Domain.Entities;

namespace VetAwesome.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    string TableName { get; }
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
    Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> newEntities, CancellationToken cancellationToken);
    Task DeleteAllAsync(CancellationToken cancellationToken);
}
