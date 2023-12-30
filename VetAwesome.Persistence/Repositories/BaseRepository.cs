using Microsoft.EntityFrameworkCore;

namespace VetAwesome.Persistence.Repositories;
internal abstract class BaseRepository<T>(DbContext context) where T : class
{
    protected DbContext Context { get; init; } = context;
    protected DbSet<T> Entities { get; init; } = context.Set<T>();
}
