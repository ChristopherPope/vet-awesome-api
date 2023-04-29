using Microsoft.EntityFrameworkCore;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Persistence.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected readonly VetAwesomeDb dbContext;
    protected DbSet<T> entities;

    protected Repository(VetAwesomeDb dbContext)
    {
        this.dbContext = dbContext;
        entities = this.dbContext.Set<T>();
    }
}
