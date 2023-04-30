using VetAwesome.Domain.Repositories;

namespace VetAwesome.Infrastructure;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly VetAwesomeDb dbContext;

    public UnitOfWork(VetAwesomeDb dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
