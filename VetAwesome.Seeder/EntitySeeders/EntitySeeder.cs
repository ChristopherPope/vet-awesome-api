using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VetAwesome.Domain.Entities;
using VetAwesome.Infrastructure.Persistence;

namespace VetAwesome.Seeder.EntitySeeders;

internal abstract class EntitySeeder<T> where T : Entity
{
    protected List<T>? entityList = null;
    protected readonly Random rand = new();
    private readonly ILogger logger;
    protected readonly VetAwesomeDb vetDb;
    protected readonly string tableName;

    protected EntitySeeder(ILogger logger
        , VetAwesomeDb vetDb)
    {
        this.logger = logger;
        this.vetDb = vetDb;

        tableName = vetDb.Model.FindEntityType(typeof(T))?.GetSchemaQualifiedTableName() ?? string.Empty;
    }

    protected IReadOnlyCollection<T> EntityList
    {
        get
        {
            Guard.IsNotNull(entityList);

            return entityList;
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

        await vetDb.Database.ExecuteSqlRawAsync($"delete from {tableName}", cancellationToken);
        await vetDb.SaveChangesAsync(cancellationToken);
        logger.LogInformation($"Deleted all in {tableName}.");
        entityList = null;
    }

    protected async Task CreateAllEntitiesAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        Guard.IsNotNull(entityList);
        var set = vetDb.Set<T>();
        await set.AddRangeAsync(EntityList, cancellationToken);
        await vetDb.SaveChangesAsync(cancellationToken);
        logger.LogInformation($"Created {entityList.Count:N0} entities in {tableName}.");
    }
}
