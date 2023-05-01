using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Repositories;

namespace VetAwesome.Seeder.EntitySeeders;

internal abstract class EntitySeeder<T> where T : Entity
{
    protected List<T>? entities = null;
    protected readonly Random rand = new();
    protected readonly IRepository<T> entityRepo;
    protected readonly IUnitOfWork unitOfWork;
    private readonly ILogger logger;

    protected EntitySeeder(IUnitOfWork unit, IRepository<T> entityRepo, ILogger logger)
    {
        this.unitOfWork = unit;
        this.entityRepo = entityRepo;
        this.logger = logger;
    }

    protected IReadOnlyCollection<T> Entities
    {
        get
        {
            Guard.IsNotNull(entities);

            return entities;
        }
    }

    protected E GetRandomElement<E>(IEnumerable<E> elements)
    {
        return elements.ElementAt(rand.Next(0, elements.Count()));
    }

    protected async Task DeleteAllEntitiesAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        await entityRepo.DeleteAllAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation($"Deleted all {entityRepo.TableName}.");
        entities = null;
    }

    protected async Task CreateAllEntitiesAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        Guard.IsNotNull(entities);
        await entityRepo.CreateRangeAsync(entities, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation($"Created {entities.Count:N0} {entityRepo.TableName}.");
    }
}
